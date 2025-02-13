using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/statement-types")]
public class StatementTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StatementTypeController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut]
    public async Task<ActionResult<StatementTypeResponseDto>> AddStatementTypeAsync(
        [FromBody] StatementTypeRequestDto statementType)
    {
        var statementTypeModel = _mapper.Map<StatementTypeModel>(statementType);
        statementTypeModel = await _mediator.Send(new CreateStatementTypeCommand(statementTypeModel));

        var statementTypeDto = _mapper.Map<StatementTypeResponseDto>(statementTypeModel);
        return Ok(statementTypeDto);
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<StatementTypeResponseDto>>> GetAllStatementTypesAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{statementTypeId}")]
    public Task<ActionResult<StatementTypeResponseDto>> GetStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{statementTypeId}")]
    public Task<ActionResult<StatementTypeResponseDto>> UpdateStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId,
        [FromBody] StatementTypeResponseDto statementType)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{statementTypeId}")]
    public Task<ActionResult> DeleteStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId)
    {
        throw new NotImplementedException();
    }
}
