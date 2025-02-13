using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires/{questionaireId}/statement-sets/{statementSetId}/statements")]
public class StatementController : ControllerBase
{
    [HttpPut]
    public Task<ActionResult<StatementModel>> AddStatementAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromBody] StatementDto statement)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{statementId}")]
    public Task<ActionResult<StatementModel>> UpdateStatementAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromRoute] Guid statementId,
        [FromBody] StatementDto statement)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{statementId}")]
    public Task<ActionResult> DeleteStatementAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid statementSetId,
        [FromRoute] Guid statementId)
    {
        throw new NotImplementedException();
    }
}
