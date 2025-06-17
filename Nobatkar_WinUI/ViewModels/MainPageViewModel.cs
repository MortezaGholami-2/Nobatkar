using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Navigation;
using Nobatkar_WinUI.Interfaces.IServices;
using Nobatkar_WinUI.Models;
using Nobatkar_WinUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace Nobatkar_WinUI.ViewModels;

public partial class MainPageViewModel : ObservableRecipient
{
    public INavigationService NavigationService { get; }

    [ObservableProperty]
    private bool isBackEnabled;

    public MainPageViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    [RelayCommand]
    private void GotoSettingsPage()
    {
        //NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

        //var appWindow = Windows.UI.WindowManagement.AppWindow.TryCreateAsync();

        //var a = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(App.MainWindow.AppWindow.Id);
        //a.SetPresenter(AppWindowPresenterKind.Overlapped);

        //Frame appWindowContentFrame = new Frame();
        //appWindowContentFrame.Navigate(typeof(SettingsWindow));
        //appWindowContentFrame.Content=  ////ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);
        ////_ = await appWindow.TryShowAsync();



        //var a = new SettingsWindow();
        //a.SetWindowPresenter(AppWindowPresenterKind.Overlapped);
        //a.Activate();

        //var presenter = OverlappedPresenter.CreateForDialog();
        //presenter.IsModal = true;
        //var appWindow = Microsoft.UI.Windowing.AppWindow.Create(presenter, App.MainWindow.AppWindow.Id);
        //appWindow.Show();

        //// C# code to create a new window
        //var newWindow = WindowHelper.CreateWindow();
        //var rootPage = new SettingsPage();
        ////rootPage.RequestedTheme = ThemeHelper.RootTheme;
        //newWindow.Content = rootPage;
        //newWindow.Activate();

        //// C# code to navigate in the new window
        //var targetPageType = typeof(SettingsWindow);
        //string targetPageArguments = string.Empty;
        ////rootPage.Navigate(targetPageType, targetPageArguments);
        ///

        //ContentDialog dialog = new ContentDialog();
        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        //dialog.XamlRoot = App.MainWindow.Content.XamlRoot;
        //dialog.Width = 640;
        //dialog.Height = 480;
        //dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        //dialog.Title = "Save your work?";
        //dialog.PrimaryButtonText = "Save";
        //dialog.SecondaryButtonText = "Don't Save";
        //dialog.CloseButtonText = "Cancel";
        //dialog.DefaultButton = ContentDialogButton.Primary;
        //dialog.Content = new SettingsPage();
        //var result = await dialog.ShowAsync();

    }


    //[RelayCommand]
    //private void GotoListDetailsPage() => NavigationService.NavigateTo(typeof(ListDetailsViewModel).FullName!);

    [RelayCommand]
    private void GotoCalendarPage() => NavigationService.NavigateTo(typeof(CalendarPageViewModel).FullName!);

    [RelayCommand]
    private async Task RunNotepad()
    {
        try
        {
            // Clear previous returned file name, if it exists, between iterations of this scenario
            //OutputTextBlock.Text = "";

            // Create a file picker
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            // See the sample code below for how to make the window accessible from the App class.
            var window = App.MainWindow;

            // Retrieve the window handle (HWND) of the current WinUI 3 window.
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            // Initialize the file picker with the window handle (HWND).
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            // Set options for your file picker
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add("*");

            // Open the picker for the user to pick a file
            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                Process.Start(file.Path);
            }
            else
            {
                //    //PickAFileOutputTextBlock.Text = "Operation cancelled.";
            }


            //Console.WriteLine("\nTrying to launch NotePad using your login information...");
            //Process.Start("notepad.exe");

            //StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(@"E:\\Games\\Console Games\\Emulators\\Mesen\\");
            //Process.Start(storageFolder + @"Mesen.exe");
        }
        catch (Win32Exception ex)
        {
            Console.WriteLine(ex.Message);
        }




    }
}
