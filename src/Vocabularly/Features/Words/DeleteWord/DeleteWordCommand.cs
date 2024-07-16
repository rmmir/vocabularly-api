using MediatR;

namespace Vocabularly.Features.Words.DeleteWord;

public sealed record DeleteWordCommand(Guid Id) : IRequest<Guid>;