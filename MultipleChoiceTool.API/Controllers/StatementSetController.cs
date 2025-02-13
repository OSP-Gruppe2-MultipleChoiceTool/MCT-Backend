using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;

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
            return NotFound();
        }

        var statementSetDto = _mapper.Map<StatementSetResponseDto>(statementSetModel);
        return Ok(statementSetDto);
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<StatementSetResponseDto>>> GetAllStatementSetsAsync(
        [FromRoute] Guid questionaireId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{statementSetId}")]
    public Task<ActionResult> DeleteStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId)
    {
        throw new NotImplementedException();
    }
}
