using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using TelericWPFHesabe3.EndPoint.Sales.ListOfSales;
using TelericWPFHesabe3.EndPoint.Settings.InformationSetting;

using Telerik.Windows.Controls;

namespace TelericWPFHesabe3.EndPoint
{
    public class MainWindowViewModel : ViewModelBase
    {

        private ObservableCollection<RadTabItem> tabControlsItem;

        public ObservableCollection<RadTabItem> TabControlsItem
        {
            get { return tabControlsItem; }
            set { tabControlsItem = value; }
        }


        private int selectedIndexTabControl;

        public int SelectedIndexTabControl
        {
            get { return selectedIndexTabControl; }
            set
            {
                selectedIndexTabControl = value;
                OnPropertyChanged();
            }
        }



        public MainWindowModelDto MainWindowDto { get; set; }

        public ICommand ShowInformationSettingCommand { get; set; }
        public ICommand ShowListOfSalesCommand { get; set; }
        public override ICommand ClosingWindowCommand { get; set; }
        public override ICommand CloseWindowCommand { get; set; }

        private void showInformationSetting(object obj)
        {
            var informationView = App.GetWindow<InformationSettingView, InformationSettingViewModel, MainWindow>();
            informationView.ShowDialog();
        }

        public override void ClosingWindow(object obj)
        {

        }

        public override void CloseWindow(object obj)
        {

        }

        public MainWindowViewModel()
        {
            MainWindowDto = new MainWindowModelDto();
            MainWindowDto.ShopName = "آنتیک";
            tabControlsItem = new ObservableCollection<RadTabItem>()
            {
                new RadTabItem()
                {
                    Header = "صفحه اصلی",
                    Content = new Frame() { Content = App.GetPage<MainPageView, MainPageViewModel>() },
                }
            };

            ShowInformationSettingCommand = new DelegateCommand(showInformationSetting);
            ShowListOfSalesCommand = new DelegateCommand(ShowListOfSales);
        }

        private void ShowListOfSales(object obj)
        {

            if (TabControlsItem.Any(s => s.Header == "لیست فاکتور های فروش"))
            {
                SelectedIndexTabControl = TabControlsItem.ToList().FindIndex(s => s.Header == "لیست فاکتور های فروش");
                return;
            }
            TabControlsItem.Add(new RadTabItem()
            {
                Header = "لیست فاکتور های فروش",
                IsSelected = true,
                Content = new Frame() { Content = App.GetPage<ListOfSalesView, ListOfSalesViewModel>() },
                CloseButtonVisibility = System.Windows.Visibility.Visible
            });
        }
    }
}
