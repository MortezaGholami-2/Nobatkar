using System.Threading.Tasks;

namespace Nobatkar_WinUI.Interfaces.IServices;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
