using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Responses;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/statement-types")]
public class StatementTypeController : ControllerBase
{
    [HttpPut]
    public Task<ActionResult<StatementTypeResponseDto>> AddStatementTypeAsync(
        [FromBody] StatementTypeResponseDto statementType)
    {
        throw new NotImplementedException();
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
