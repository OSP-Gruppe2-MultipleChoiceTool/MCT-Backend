using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

/// <summary>
/// Controller for managing user access to questionnaires.
/// </summary>
[ApiController]
[Route("api/statements")]
public class UserAccessController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserAccessController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public UserAccessController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets a questionnaire by its link ID.
    /// </summary>
    /// <param name="linkId">The link ID of the questionnaire.</param>
    /// <param name="isExam">Indicates whether the questionnaire is an exam.</param>
    /// <returns>The questionnaire with the specified link ID.</returns>
    [HttpGet]
    public async Task<ActionResult<QuestionaireResponseDto>> GetQuestionaireByLinkAsync(
        [FromQuery] Guid linkId, 
        [FromQuery] bool isExam)
    {
        var questionaireModel = await _mediator.Send(new GetQuestionaireByLinkIdQuery(linkId, isExam));
        if (questionaireModel == null)
        {
            return NotFound();
        }

        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }
}
