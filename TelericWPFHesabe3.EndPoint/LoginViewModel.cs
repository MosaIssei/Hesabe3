using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Telerik.Windows.Controls;

namespace TelericWPFHesabe3.EndPoint
{
    public class LoginViewModel : ViewModelBase
    {
        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                OnPropertyChanged();
                username = value;
            }
        }

        private bool isLogined = false;

        public bool IsLogined
        {
            get { return isLogined; }
            set
            {
                OnPropertyChanged();
                isLogined = value;
            }
        }

        public override ICommand ClosingWindowCommand { get; set; }
        public override ICommand CloseWindowCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            CloseWindowCommand = new DelegateCommand(CloseWindow);
            ClosingWindowCommand = new DelegateCommand(ClosingWindow);
            LoginCommand = new DelegateCommand(LoginExecut);
        }

        private void LoginExecut(object obj)
        {
            RadPasswordBox passwordBox = (RadPasswordBox)obj;
            if (Username == "1" && passwordBox.Password == "1")
            {
                isLogined = true;
                CurrentWindow.Close();
            }
            else
            {
                MessageBox.Show("نام کاربری یا کلمه عبور اشتباه میباشد");
            }
        }

        public override void CloseWindow(object obj)
        {
            CurrentWindow.Close();
        }

        public override void ClosingWindow(object obj)
        {

        }
    }
}
