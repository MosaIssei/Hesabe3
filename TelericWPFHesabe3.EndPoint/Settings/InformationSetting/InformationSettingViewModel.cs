using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using TelericWPFHesabe3.EndPoint.Settings.InformationSetting.Models;

using Telerik.Windows.Controls;

namespace TelericWPFHesabe3.EndPoint.Settings.InformationSetting
{
    public class InformationSettingViewModel : ViewModelBase
    {
        #region Properties

        public InformationSettingModelDto LastInformationSettingModel { get; set; }

        public InformationSettingModelDto InformationSettingModel { get; set; }

        #endregion

        #region Commands

        public override ICommand ClosingWindowCommand { get; set; }
        public override ICommand CloseWindowCommand { get; set; }
        public ICommand SaveInformationCommand { get; set; }

        #endregion

        #region Ctor

        public InformationSettingViewModel()
        {
            InformationSettingModel = new InformationSettingModelDto();
            LastInformationSettingModel = new InformationSettingModelDto();
            SaveInformationCommand = new DelegateCommand(SaveInformation);
            ClosingWindowCommand = new DelegateCommand(ClosingWindow);
            CloseWindowCommand = new DelegateCommand(CloseWindow);
        }

        #endregion

        public override void ClosingWindow(object obj)
        {
            CancelEventArgs param = obj as CancelEventArgs;

            var comp = LastInformationSettingModel.Compare(InformationSettingModel);


            if (comp != 0)
            {
                if (MessageBox.Show("اطلاعات تغیر پیدا کرده است آیا اطمینان به خروج دارید؟", "اخطار", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                {
                    return;
                }
                param.Cancel = true;
                return;
            }
        }
        public override void CloseWindow(object obj)
        {
            base.CurrentWindow?.Close();
        }
        public void SaveInformation(object obj)
        {
            if (MessageBox.Show("آیا از صحت اطلاعات وارد شده اطمینان دارید؟", "ذخیره اطلاعات", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                return;
            }
        }
    }
}
