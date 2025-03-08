using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

/// <summary>
/// Controller for managing statement types.
/// </summary>
[ApiController]
[Route("api/statement-types")]
public class StatementTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="StatementTypeController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public StatementTypeController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a new statement type.
    /// </summary>
    /// <param name="request">The request containing the title of the statement type.</param>
    /// <returns>The created statement type.</returns>
    [HttpPut]
    public async Task<ActionResult<StatementTypeResponseDto>> AddStatementTypeAsync(
        [FromBody] CreateStatementTypeRequestDto request)
    {
        var statementTypeModel = await _mediator.Send(new CreateStatementTypeCommand(request.Title));
        var statementTypeDto = _mapper.Map<StatementTypeResponseDto>(statementTypeModel);
        return Ok(statementTypeDto);
    }

    /// <summary>
    /// Gets all statement types.
    /// </summary>
    /// <returns>A list of statement types.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatementTypeResponseDto>>> GetAllStatementTypesAsync()
    {
        var statementTypeModels = await _mediator.Send(new GetAllStatementTypesQuery());
        var statementTypeDtos = _mapper.Map<IEnumerable<StatementTypeResponseDto>>(statementTypeModels);
        return Ok(statementTypeDtos);
    }

    /// <summary>
    /// Gets a statement type by its ID.
    /// </summary>
    /// <param name="statementTypeId">The ID of the statement type.</param>
    /// <returns>The statement type with the specified ID.</returns>
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

    /// <summary>
    /// Updates a statement type by its ID.
    /// </summary>
    /// <param name="statementTypeId">The ID of the statement type.</param>
    /// <param name="request">The request containing the updated title of the statement type.</param>
    /// <returns>The updated statement type.</returns>
    [HttpPatch("{statementTypeId}")]
    public async Task<ActionResult<StatementTypeResponseDto>> UpdateStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId,
        [FromBody] UpdateStatementTypeRequestDto request)
    {
        var statementTypeModel = await _mediator.Send(new UpdateStatementTypeCommand(statementTypeId, request.Title));
        if (statementTypeModel == null)
        {
            return NotFound();
        }

        var statementTypeDto = _mapper.Map<StatementTypeResponseDto>(statementTypeModel);
        return Ok(statementTypeDto);
    }

    /// <summary>
    /// Deletes a statement type by its ID.
    /// </summary>
    /// <param name="statementTypeId">The ID of the statement type.</param>
    /// <returns>No content if the deletion was successful.</returns>
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
