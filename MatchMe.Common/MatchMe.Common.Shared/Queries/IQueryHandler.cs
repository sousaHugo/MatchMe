using MediatR;

namespace MatchMe.Common.Shared.Queries
{
    public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {

    }
}
