using AeroSimFT.Services;
using AeroSimFT.Views;
using FisSst.BlazorMaps.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Windows;

namespace AeroSimFT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddFluentUIComponents();
            serviceCollection.AddBlazorLeafletMaps();
            serviceCollection.AddSingleton<XplaneServices>();
            serviceCollection.AddSingleton<LocationServices>();
            serviceCollection.AddSingleton<AirportServices>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();

            AppState.MainWindow = this;
            
        }
        public void CloseApp_Btn()
        {
            Application.Current.Shutdown();
        }
        internal void MaximizeButton_Click()
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
        }
        internal void MinimizeButton_Click()
        {
            this.WindowState = WindowState.Minimized;
        }
        internal void OpenAirportWindow_Click()
        {
            if (AppState.AirportWindow == null)
            {
                AppState.AirportWindow = new AirportWindow();
                AppState.AirportWindow.Show();

                AppState.AirportWindow.Closed += (s, args) => AppState.AirportWindow = null!;
            }
            else
            {
                AppState.AirportWindow.Activate();
            }
        }
        internal void OpenAircraftWindow_Click()
        {
            if (AppState.AircraftWindow == null)
            {
                AppState.AircraftWindow = new AircraftWindow();
                AppState.AircraftWindow.Show();
                AppState.AircraftWindow.Closed += (s, args) => AppState.AircraftWindow = null!;
            }
            else
            {
                AppState.AircraftWindow.Activate();
            }
        }
    }
}