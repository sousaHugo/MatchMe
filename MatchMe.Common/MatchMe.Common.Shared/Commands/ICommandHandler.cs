using MediatR;

namespace MatchMe.Common.Shared.Commands
{
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
      where TRequest : IRequest<TResponse>
    {

    }
    public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest, Unit>
    where TRequest : IRequest<Unit>
    {

    }
}
