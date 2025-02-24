﻿using MediatR;
using MultipleChoiceTool.Core.Commands;
using MultipleChoiceTool.Core.Models;
using MultipleChoiceTool.Core.Repositories;

namespace MultipleChoiceTool.Service.Commands;

internal class CreateStatementCommandHandler : IRequestHandler<CreateStatementCommand, StatementModel?>
{
    private readonly IStatementReadRepository _statementReadRepository;
    private readonly IBaseReadRepository<StatementSetModel> _statementSetReadRepository;
    private readonly IBaseWriteRepository<StatementModel> _statementWriteRepository;

    public CreateStatementCommandHandler(
        IStatementReadRepository statementReadRepository,
        IBaseReadRepository<StatementSetModel> statementSetReadRepository, 
        IBaseWriteRepository<StatementModel> statementWriteRepository)
    {
        _statementReadRepository = statementReadRepository;
        _statementSetReadRepository = statementSetReadRepository;
        _statementWriteRepository = statementWriteRepository;
    }

    public async Task<StatementModel?> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
    {
        var statement = await _statementReadRepository.FindStatementByContentAsync(request.Content, true, cancellationToken);
        if (statement != null)
        {
            return statement;
        }

        var statementSet = await _statementSetReadRepository.FindByIdAsync(request.StatementSetId, cancellationToken);
        if (statementSet == null)
        {
            return null;
        }

        statement = new StatementModel(request.IsCorrect, request.Content, statementSet.Id);
        return await _statementWriteRepository.CreateAsync(statement, true, cancellationToken);
    }
}
