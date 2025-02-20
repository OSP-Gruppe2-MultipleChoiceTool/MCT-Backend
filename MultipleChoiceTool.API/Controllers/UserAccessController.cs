using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/statements")]
public class UserAccessController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserAccessController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<QuestionaireResponseDto>> GetQuestionaireByLinkAsync(
        [FromQuery] Guid linkId, 
        [FromQuery] bool isExam)
    {
        var questionaireModel = await _mediator.Send(new GetQuestionaireByLinkIdQuery(linkId, isExam));
        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }
}
