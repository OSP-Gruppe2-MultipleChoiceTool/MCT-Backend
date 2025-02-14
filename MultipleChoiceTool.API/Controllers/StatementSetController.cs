using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires/{questionaireId}/statement-sets")]
public class StatementSetController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StatementSetController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<StatementSetResponseDto>> CreateStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] CreateStatementSetRequestDto request)
    {
        var statementSetModel = await _mediator.Send(new CreateStatementSetCommand(
            questionaireId, request.Explaination, request.StatementImage, request.StatementTypeId));
        
        if (statementSetModel == null)
        {
            return NotFound();
        }

        var statementSetDto = _mapper.Map<StatementSetResponseDto>(statementSetModel);
        return Ok(statementSetDto);
    }

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

    [HttpPatch("{statementSetId}")]
    public async Task<ActionResult<IEnumerable<StatementSetResponseDto>>> UpdateStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromBody] UpdateStatementSetRequestDto request)
    {
        var statementSetModel = await _mediator.Send(new UpdateStatementSetCommand(
            statementSetId, request.Explaination, request.StatementImage, request.StatementTypeId));

        if (statementSetModel == null)
        {
            return NotFound();
        }

        var statementSetDto = _mapper.Map<StatementSetResponseDto>(statementSetModel);
        return Ok(statementSetDto);
    }

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

        return Ok();
    }
}
