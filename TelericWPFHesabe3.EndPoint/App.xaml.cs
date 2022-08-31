using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using TelericWPFHesabe3.EndPoint.Base;
using TelericWPFHesabe3.EndPoint.Sales.ListOfSales;
using TelericWPFHesabe3.EndPoint.Settings.InformationSetting;

using Telerik.Windows.Controls;

using IServiceProvider = System.IServiceProvider;

namespace TelericWPFHesabe3.EndPoint
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider serviceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            InjectionCollection.InjectionServiceCollection(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public static Window GetWindow<View, ViewModel>() where ViewModel : ViewModelBase
        {
            var view = App.serviceProvider.GetServices<View>().SingleOrDefault() as Window;
            var viewModel = App.serviceProvider.GetServices<ViewModel>().SingleOrDefault();
            viewModel.CurrentWindow = view;
            view.DataContext = viewModel;
            return view;
        }

        public static Page GetPage<View, ViewModel>() where ViewModel : PageViewModelBase
        {
            var view = App.serviceProvider.GetServices<View>().SingleOrDefault() as Page;
            var viewModel = App.serviceProvider.GetServices<ViewModel>().SingleOrDefault();
            viewModel.CurentPage = view;
            view.DataContext = viewModel;
            return view;
        }

        public static Window GetWindow<View, ViewModel, Owner>() where ViewModel : ViewModelBase
        {
            var view = App.serviceProvider.GetServices<View>().SingleOrDefault() as Window;
            var viewModel = App.serviceProvider.GetServices<ViewModel>().SingleOrDefault();
            var owner = App.serviceProvider.GetServices<Owner>().SingleOrDefault() as Window;
            viewModel.CurrentWindow = view;
            view.DataContext = viewModel;
            view.Owner = owner;
            return view;
        }


        public App()
        {
            changeStyle("windows11");
        }

        public void changeStyle(string style)
        {
            if (style == "windows11")
            {
                StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Windows11Theme();
                InitializeComponent();
            }
            else if (style == "windows8")
            {
                StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Windows8Theme();
                InitializeComponent();
            }
            else if (style == "windows7")
            {
                StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Windows7Theme();
                InitializeComponent();
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ConfigureServices();
            var loginWi = App.GetWindow<LoginView, LoginViewModel>();
            MainWindow = App.GetWindow<MainWindow, MainWindowViewModel>();
            loginWi.ShowDialog();
            if (!((LoginViewModel)loginWi.DataContext).IsLogined)
            {
                Application.Current.Shutdown();
                return;
            }
            MainWindow.Show();
        }
    }
}
