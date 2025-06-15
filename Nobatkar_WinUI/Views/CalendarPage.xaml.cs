using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Nobatkar_WinUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Nobatkar_WinUI.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class CalendarPage : Page
{
    public CalendarPageViewModel ViewModel { get; } = new CalendarPageViewModel();

    public CalendarPage()
    {
        this.InitializeComponent();
    }

    private void PreviousMonth_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.GoToPreviousMonth();
    }

    private void NextMonth_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.GoToNextMonth();
    }

    private void AddShift_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Open Add Shift Dialog (can use ContentDialog)
        ViewModel.AddDummyShiftPlan(); // Placeholder for now
    }

}
