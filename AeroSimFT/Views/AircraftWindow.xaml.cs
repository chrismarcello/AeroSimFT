using System;
using System.Collections.Generic;
using AeroSimFT.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Windows;

namespace AeroSimFT.Views
{
    /// <summary>
    /// Interaction logic for AircraftWindow.xaml
    /// </summary>
    public partial class AircraftWindow : Window
    {
        public AircraftWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddFluentUIComponents();
            serviceCollection.AddSingleton<XplaneServices>();
            serviceCollection.AddSingleton<LocationServices>();
            serviceCollection.AddSingleton<AirportServices>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
            AppState.AircraftWindow = this;
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
        public void CloseApp_Btn()
        {
            AppState.AircraftWindow = null;
            this.Close();
        }
    }
}
