using Microsoft.Extensions.DependencyInjection;

using TelericWPFHesabe3.EndPoint.Sales.ListOfSales;

using TelericWPFHesabe3.EndPoint.Settings.InformationSetting;

namespace TelericWPFHesabe3.EndPoint
{
    public class InjectionCollection
    {
        public static void InjectionServiceCollection(ServiceCollection services)
        {
            services.AddScoped<MainWindow>();
            services.AddScoped<MainWindowViewModel>();
            services.AddTransient<InformationSettingView>();
            services.AddTransient<InformationSettingViewModel>();
            services.AddTransient<LoginView>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ListOfSalesView>();
            services.AddTransient<ListOfSalesViewModel>();
            services.AddTransient<MainPageView>();
            services.AddTransient<MainPageViewModel>();
        }
    }
}
