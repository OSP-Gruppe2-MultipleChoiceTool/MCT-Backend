﻿using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires/{questionaireId}/statement-sets")]
public class StatementSetController : ControllerBase
{
    [HttpPost]
    public Task<ActionResult<StatementSetDto>> CreateStatementSetAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] StatementSetDto statementSet)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<StatementSetDto>>> GetAllStatementSetsAsync(
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
