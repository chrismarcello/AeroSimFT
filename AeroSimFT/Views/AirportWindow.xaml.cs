using AeroSimFT.Services;
using FisSst.BlazorMaps.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AeroSimFT.Views
{
    /// <summary>
    /// Interaction logic for AirportWindow.xaml
    /// </summary>
    public partial class AirportWindow : Window
    {
        public AirportWindow()
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
            AppState.AirportWindow = this;
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
            AppState.AirportWindow = null;
            this.Close();
        }
    }
}
