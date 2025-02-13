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
    public async Task<ActionResult<IEnumerable<StatementTypeResponseDto>>> GetAllStatementTypesAsync()
    {
        var statementTypeModels = await _mediator.Send(new GetAllStatementTypesQuery());
        var statementTypeDtos = _mapper.Map<IEnumerable<StatementTypeResponseDto>>(statementTypeModels);
        return Ok(statementTypeDtos);
    }

    [HttpGet("{statementTypeId}")]
    public async Task<ActionResult<StatementTypeResponseDto>> GetStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId)
    {
        var statementTypeModel = await _mediator.Send(new GetStatementTypeByIdQuery(statementTypeId));
        if (statementTypeModel == null)
        {
            return NotFound();
        }

        var statementTypeDto = _mapper.Map<StatementTypeResponseDto>(statementTypeModel);
        return Ok(statementTypeDto);
    }

    [HttpPatch("{statementTypeId}")]
    public async Task<ActionResult<StatementTypeResponseDto>> UpdateStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId,
        [FromBody] StatementTypeRequestDto statementType)
    {
        var statementTypeModel = _mapper.Map<StatementTypeModel>(statementType);
        statementTypeModel = await _mediator.Send(new UpdateStatementTypeCommand(statementTypeId, statementTypeModel));

        if (statementTypeModel == null)
        {
            return NotFound();
        }

        var statementTypeDto = _mapper.Map<StatementTypeResponseDto>(statementTypeModel);
        return Ok(statementTypeDto);
    }

    [HttpDelete("{statementTypeId}")]
    public async Task<ActionResult> DeleteStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId)
    {
        var statementTypeModel = await _mediator.Send(new DeleteStatementTypeCommand(statementTypeId));
        if (statementTypeModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
