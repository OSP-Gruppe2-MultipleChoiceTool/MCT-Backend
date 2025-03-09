using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

/// <summary>
/// Controller for managing questionnaires.
/// </summary>
[ApiController]
[Route("api/questionaires")]
public class QuestionaireController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionaireController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public QuestionaireController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new questionnaire.
    /// </summary>
    /// <param name="statementTypeId">The ID of the statement type (optional).</param>
    /// <param name="request">The request containing the title of the questionnaire.</param>
    /// <returns>The created questionnaire.</returns>
    [HttpPost]
    public async Task<ActionResult<QuestionaireResponseDto>> CreateQuestionaireAsync(
        [FromQuery] Guid? statementTypeId,
        [FromBody] CreateQuestionaireRequestDto request)
    {
        var questionaireModel = statementTypeId == null ?
            await _mediator.Send(new CreateQuestionaireCommand(request.Title)) :
            await _mediator.Send(new CreateStatementTypeQuestionaireCommand(request.Title, statementTypeId.Value));

        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }

    /// <summary>
    /// Gets all questionnaires.
    /// </summary>
    /// <returns>A list of questionnaires.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionaireResponseDto>>> GetAllQuestionairesAsync()
    {
        var questionaireModels = await _mediator.Send(new GetAllQuestionairesQuery());
        var questionaireDtos = _mapper.Map<IEnumerable<QuestionaireResponseDto>>(questionaireModels);
        return Ok(questionaireDtos);
    }

    /// <summary>
    /// Gets a questionnaire by its ID.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <returns>The questionnaire with the specified ID.</returns>
    [HttpGet("{questionaireId}")]
    public async Task<ActionResult<QuestionaireResponseDto>> GetQuestionaireByIdAsync(
        [FromRoute] Guid questionaireId)
    {
        var questionaireModel = await _mediator.Send(new GetQuestionaireByIdQuery(questionaireId));
        if (questionaireModel == null)
        {
            return NotFound();
        }

        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }

    /// <summary>
    /// Updates a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="request">The request containing the updated title of the questionnaire.</param>
    /// <returns>The updated questionnaire.</returns>
    [HttpPatch("{questionaireId}")]
    public async Task<ActionResult<QuestionaireResponseDto>> UpdateQuestionaireAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] UpdateQuestionaireRequestDto request)
    {
        var questionaireModel = await _mediator.Send(new UpdateQuestionaireCommand(questionaireId, request.Title));
        
        if (questionaireModel == null)
        {
            return NotFound();
        }

        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }

    /// <summary>
    /// Deletes a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <returns>No content if the deletion was successful.</returns>
    [HttpDelete("{questionaireId}")]
    public async Task<ActionResult> DeleteQuestionaireAsync(
        [FromRoute] Guid questionaireId)
    {
        var questionaireModel = await _mediator.Send(new DeleteQuestionaireCommand(questionaireId));
        if (questionaireModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Exports a questionnaire to Html format.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <returns>The Html formatted questionnaire.</returns>
    [HttpGet("{questionaireId}/export")]
    public async Task<ActionResult<string>> ExportQuestionaireAsync(
        [FromRoute] Guid questionaireId)
    {
        var richText = await _mediator.Send(new ExportQuestionaireToHtmlCommand(questionaireId));
        if (richText == null)
        {
            return NotFound();
        }
        return Ok(richText);
    }
}
