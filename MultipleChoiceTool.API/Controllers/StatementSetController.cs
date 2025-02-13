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
        [FromBody] StatementSetRequestDto statementSet)
    {
        var statementSetModel = _mapper.Map<StatementSetModel>(statementSet);
        statementSetModel = await _mediator.Send(new CreateStatementSetCommand(questionaireId, statementSetModel));
        
        if (statementSetModel == null)
        {
            return BadRequest();
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
        return Ok(_mapper.Map<IEnumerable<StatementSetResponseDto>>(statementSetModels));
    }

    [HttpDelete("{statementSetId}")]
    public async Task<ActionResult> DeleteStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId)
    {
        var questionaireModel = await _mediator.Send(new DeleteStatementSetCommand(questionaireId, statementSetId));
        if (questionaireModel == null)
        {
            return NotFound();
        }
        return Ok();
    }
}
