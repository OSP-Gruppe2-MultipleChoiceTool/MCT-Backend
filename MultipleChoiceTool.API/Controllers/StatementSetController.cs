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
/// Controller for managing statement sets.
/// </summary>
[ApiController]
[Route("api/questionaires/{questionaireId}/statement-sets")]
public class StatementSetController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementSetController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public StatementSetController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new statement set.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="request">The request containing the details of the statement set.</param>
    /// <returns>The created statement set.</returns>
    [HttpPost]
    public async Task<ActionResult<StatementSetResponseDto>> CreateStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] CreateStatementSetRequestDto request)
    {
        var statementModels = _mapper.Map<IEnumerable<StatementModel>>(request.Statements);

        var statementSetModel = await _mediator.Send(new CreateStatementSetCommand(
            questionaireId, request.Explaination, request.StatementImage, request.StatementTypeId, statementModels));
        
        if (statementSetModel == null)
        {
            return NotFound();
        }

        var statementSetDto = _mapper.Map<StatementSetResponseDto>(statementSetModel);
        return Ok(statementSetDto);
    }

    /// <summary>
    /// Gets all statement sets for a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <returns>A list of statement sets.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatementSetResponseDto>>> GetAllStatementSetsAsync(
        [FromRoute] Guid questionaireId)
    {
        var statementSetModels = await _mediator.Send(new GetAllStatementSetsQuery(questionaireId));
        if (statementSetModels == null)
        {
            return NotFound();
        }

        var statementSetDtos = _mapper.Map<IEnumerable<StatementSetResponseDto>>(statementSetModels);
        return Ok(statementSetDtos);
    }

    /// <summary>
    /// Updates a statement set.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="statementSetId">The ID of the statement set.</param>
    /// <param name="request">The request containing the updated details of the statement set.</param>
    /// <returns>The updated statement set.</returns>
    [HttpPatch("{statementSetId}")]
    public async Task<ActionResult<IEnumerable<StatementSetResponseDto>>> UpdateStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromBody] UpdateStatementSetRequestDto request)
    {
        var statementModels = _mapper.Map<IEnumerable<StatementModel>>(request.Statements);

        var statementSetModel = await _mediator.Send(new UpdateStatementSetCommand(
            statementSetId, request.Explaination, request.StatementImage, request.StatementTypeId, statementModels));

        if (statementSetModel == null)
        {
            return NotFound();
        }

        var statementSetDto = _mapper.Map<StatementSetResponseDto>(statementSetModel);
        return Ok(statementSetDto);
    }

    /// <summary>
    /// Deletes a statement set.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="statementSetId">The ID of the statement set.</param>
    /// <returns>No content if the deletion was successful.</returns>
    [HttpDelete("{statementSetId}")]
    public async Task<ActionResult> DeleteStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId)
    {
        var questionaireModel = await _mediator.Send(new DeleteStatementSetCommand(statementSetId));
        if (questionaireModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
