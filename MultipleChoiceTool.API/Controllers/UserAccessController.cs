using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/statements")]
public class UserAccessController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<QuestionaireDto>> GetQuestionaireByLinkAsync(
        [FromQuery] Guid linkId, 
        [FromQuery] bool isExam)
    {
        throw new NotImplementedException();
    }
}
