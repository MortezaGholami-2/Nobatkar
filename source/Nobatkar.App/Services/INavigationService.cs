using Microsoft.UI.Xaml.Controls;

namespace Nobatkar.App.Services;

public interface INavigationService
{
    void NavigateTo<TView>() where TView : Page;

}
