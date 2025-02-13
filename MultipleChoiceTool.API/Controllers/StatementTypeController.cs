using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/statement-types")]
public class StatementTypeController : ControllerBase
{
    [HttpPut]
    public Task<ActionResult<StatementTypeDto>> AddStatementTypeAsync(
        [FromBody] StatementTypeDto statementType)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<StatementTypeDto>>> GetAllStatementTypesAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{statementTypeId}")]
    public Task<ActionResult<StatementTypeDto>> GetStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{statementTypeId}")]
    public Task<ActionResult<StatementTypeDto>> UpdateStatementTypeByIdAsync(
        [FromRoute] Guid statementTypeId,
        [FromBody] StatementTypeDto statementType)
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
