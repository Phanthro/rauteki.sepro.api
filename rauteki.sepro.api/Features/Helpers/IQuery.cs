using MediatR;

namespace Rauteki.Sepro.Api.Features.Helpers;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}