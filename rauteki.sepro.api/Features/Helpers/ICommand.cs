using MediatR;

namespace Rauteki.Sepro.Api.Features.Helpers;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}