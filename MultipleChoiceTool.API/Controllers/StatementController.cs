using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires/{questionaireId}/statement-sets/{statementSetId}/statements")]
public class StatementController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StatementController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut]
    public async Task<ActionResult<StatementResponseDto>> AddStatementAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromBody] StatementRequestDto statement)
    {
        var statementModel = _mapper.Map<StatementModel>(statement);
        statementModel = await _mediator.Send(new CreateStatementCommand(statementSetId, statementModel));

        if (statementModel == null)
        {
            return NotFound();
        }

        var statementDto = _mapper.Map<StatementResponseDto>(statementModel);
        return Ok(statementDto);
    }

    [HttpPatch("{statementId}")]
    public async Task<ActionResult<StatementResponseDto>> UpdateStatementAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromRoute] Guid statementId,
        [FromBody] StatementRequestDto statement)
    {
        var statementModel = _mapper.Map<StatementModel>(statement);
        statementModel = await _mediator.Send(new UpdateStatementCommand(statementId, statementModel));

        if (statementModel == null)
        {
            return NotFound();
        }

        var statementDto = _mapper.Map<StatementResponseDto>(statementModel);
        return Ok(statementDto);
    }

    [HttpDelete("{statementId}")]
    public async Task<ActionResult> DeleteStatementAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromRoute] Guid statementId)
    {
        var statementModel = await _mediator.Send(new DeleteStatementCommand(statementId));
        if (statementModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
