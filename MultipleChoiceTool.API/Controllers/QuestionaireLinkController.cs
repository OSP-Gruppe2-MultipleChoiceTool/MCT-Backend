using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

/// <summary>
/// Controller for managing questionnaire links.
/// </summary>
[ApiController]
[Route("api/questionaires/{questionaireId}/links")]
public class QuestionaireLinkController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestionaireLinkController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public QuestionaireLinkController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new link for a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="request">The request containing the expiration date of the link.</param>
    /// <returns>The created link.</returns>
    [HttpPost]
    public async Task<ActionResult<QuestionaireLinkResponseDto>> CreateLinkAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] CreateQuestionaireLinkRequestDto request)
    {
        var linkModel = await _mediator.Send(new CreateLinkCommand(questionaireId, request.ExpirationDate));
        if (linkModel == null)
        {
            return NotFound();
        }

        var linkDto = _mapper.Map<QuestionaireLinkResponseDto>(linkModel);
        return Ok(linkDto);
    }

    /// <summary>
    /// Gets all links for a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <returns>A list of links.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionaireLinkResponseDto>>> GetAllLinksAsync(
        [FromRoute] Guid questionaireId)
    {
        var linkModels = await _mediator.Send(new GetAllLinksQuery(questionaireId));
        if (linkModels == null)
        {
            return NotFound();
        }

        var linkDtos = _mapper.Map<IEnumerable<QuestionaireLinkResponseDto>>(linkModels);
        return Ok(linkDtos);
    }

    /// <summary>
    /// Updates a link for a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="linkId">The ID of the link.</param>
    /// <param name="request">The request containing the updated expiration date of the link.</param>
    /// <returns>The updated link.</returns>
    [HttpPatch("{linkId}")]
    public async Task<ActionResult<QuestionaireLinkResponseDto>> UpdateLinkAsync(
        [FromRoute] Guid questionaireId, 
        [FromRoute] Guid linkId, 
        [FromBody] UpdateQuestionaireLinkRequestDto request)
    {
        var linkModel = await _mediator.Send(new UpdateLinkCommand(linkId, request.ExpirationDate));
        if (linkModel == null)
        {
            return NotFound();
        }

        var linkDto = _mapper.Map<QuestionaireLinkResponseDto>(linkModel);
        return Ok(linkDto);
    }

    /// <summary>
    /// Deletes a link for a questionnaire.
    /// </summary>
    /// <param name="questionaireId">The ID of the questionnaire.</param>
    /// <param name="linkId">The ID of the link.</param>
    /// <returns>No content if the deletion was successful.</returns>
    [HttpDelete("{linkId}")]
    public async Task<ActionResult> DeleteLinkAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid linkId)
    {
        var linkModel = await _mediator.Send(new DeleteLinkCommand(linkId));
        if (linkModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
