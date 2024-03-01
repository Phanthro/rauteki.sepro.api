
namespace Rauteki.Fire.Api.Features.Helpers;

public interface IValidator<ICommand>
{
    void Validate(ICommand request);
}