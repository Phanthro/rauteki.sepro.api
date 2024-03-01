using MediatR;

namespace Rauteki.Fire.Api.Features.Helpers;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}