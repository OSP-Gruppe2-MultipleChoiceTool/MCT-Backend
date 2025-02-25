using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires/{questionaireId}/links")]
public class QuestionaireLinkController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public QuestionaireLinkController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<QuestionaireLinkResponseDto>> CreateLinkAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] CreateQuestionaireLinkRequestDto request)
    {
        var linkModel = await _mediator.Send(new CreateLinkCommand(questionaireId, request.ExpirationDate));
        var linkDto = _mapper.Map<QuestionaireLinkResponseDto>(linkModel);
        return Ok(linkDto);
    }

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

        var linkDto = _mapper.Map<QuestionaireLinkResponseDto>(linkModel);
        return Ok(linkDto);
    }
}
