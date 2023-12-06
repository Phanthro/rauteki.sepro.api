
namespace Rauteki.Sepro.Api.Features.Helpers;

public interface IValidator<ICommand>
{
    void Validate(ICommand request);
}