﻿using MediatR;
using MultipleChoiceTool.Core.Models;

namespace MultipleChoiceTool.Core.Commands;

public record DeleteStatementSetCommand(Guid StatementSetId) : IRequest<StatementSetModel?>;
