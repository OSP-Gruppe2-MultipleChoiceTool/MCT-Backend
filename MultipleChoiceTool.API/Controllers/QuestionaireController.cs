using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Queries;

namespace MultipleChoiceTool.API.Controllers;

[ApiController]
[Route("api/questionaires")]
public class QuestionaireController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public QuestionaireController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public Task<ActionResult<QuestionaireModel>> CreateQuestionaireAsync(
        [FromBody] QuestionaireDto questionaire)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionaireModel>>> GetAllQuestionairesAsync()
    {
        var questionaireModels = await _mediator.Send(new GetAllQuestionairesQuery());
        var questionaireDtos = _mapper.Map<IEnumerable<QuestionaireModel>>(questionaireModels);
        return Ok(questionaireDtos);
    }

    [HttpGet("{questionaireId}")]
    public Task<ActionResult<QuestionaireModel>> GetQuestionaireByIdAsync(
        [FromRoute] Guid questionaireId)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{questionaireId}")]
    public Task<ActionResult<QuestionaireModel>> UpdateQuestionaireAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] QuestionaireDto questionaire)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{questionaireId}")]
    public Task<ActionResult> DeleteQuestionaireAsync(
        [FromRoute] Guid questionaireId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{questionaireId}/export")]
    public Task<ActionResult<string>> ExportQuestionaireAsync(
        [FromRoute] Guid questionaireId)
    {
        throw new NotImplementedException();
    }
}
