using MediatR;

namespace Rauteki.Fire.Api.Features.Helpers;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}