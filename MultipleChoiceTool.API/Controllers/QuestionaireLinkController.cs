using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires/{questionaireId}/links")]
public class QuestionaireLinkController : ControllerBase
{
    [HttpPost]
    public Task<ActionResult<QuestionaireLinkModel>> CreateLinkAsync(
        [FromRoute] Guid questionaireId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<QuestionaireLinkModel>>> GetAllLinksAsync(
        [FromRoute] Guid questionaireId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{linkId}")]
    public Task<ActionResult<QuestionaireLinkModel>> UpdateLinkAsync(
        [FromRoute] Guid questionaireId, 
        [FromRoute] Guid linkId, 
        [FromBody] QuestionaireLinkDto link)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{linkId}")]
    public Task<ActionResult> DeleteLinkAsync(
        [FromRoute] Guid questionaireId,
        [FromRoute] Guid linkId)
    {
        throw new NotImplementedException();
    }
}
