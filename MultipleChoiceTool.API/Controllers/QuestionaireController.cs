﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleChoiceTool.API.Dtos.Requests;
using MultipleChoiceTool.API.Dtos.Responses;
using MultipleChoiceTool.Core.Commands;
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
    public async Task<ActionResult<QuestionaireResponseDto>> CreateQuestionaireAsync(
        [FromBody] CreateQuestionaireRequestDto request)
    {
        var questionaireModel = await _mediator.Send(new CreateQuestionaireCommand(request.Title));
        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionaireResponseDto>>> GetAllQuestionairesAsync()
    {
        var questionaireModels = await _mediator.Send(new GetAllQuestionairesQuery());
        var questionaireDtos = _mapper.Map<IEnumerable<QuestionaireResponseDto>>(questionaireModels);
        return Ok(questionaireDtos);
    }

    [HttpGet("{questionaireId}")]
    public async Task<ActionResult<QuestionaireResponseDto>> GetQuestionaireByIdAsync(
        [FromRoute] Guid questionaireId)
    {
        var questionaireModel = await _mediator.Send(new GetQuestionaireByIdQuery(questionaireId));
        if (questionaireModel == null)
        {
            return NotFound();
        }

        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }

    [HttpPatch("{questionaireId}")]
    public async Task<ActionResult<QuestionaireResponseDto>> UpdateQuestionaireAsync(
        [FromRoute] Guid questionaireId,
        [FromBody] UpdateQuestionaireRequestDto request)
    {
        var questionaireModel = await _mediator.Send(new UpdateQuestionaireCommand(questionaireId, request.Title));
        
        if (questionaireModel == null)
        {
            return NotFound();
        }

        var questionaireDto = _mapper.Map<QuestionaireResponseDto>(questionaireModel);
        return Ok(questionaireDto);
    }

    [HttpDelete("{questionaireId}")]
    public async Task<ActionResult> DeleteQuestionaireAsync(
        [FromRoute] Guid questionaireId)
    {
        var questionaireModel = await _mediator.Send(new DeleteQuestionaireCommand(questionaireId));
        if (questionaireModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("{questionaireId}/export")]
    public async Task<ActionResult<string>> ExportQuestionaireAsync(
        [FromRoute] Guid questionaireId)
    {
        var richText = await _mediator.Send(new ExportQuestionaireToRTFCommand(questionaireId));
        if (richText == null)
        {
            return NotFound();
        }
        return Ok(richText);
    }
}
