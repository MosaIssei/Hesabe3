using System.Windows;
using System.Windows.Input;

namespace TelericWPFHesabe3.EndPoint
{
    public abstract class ViewModelBase : ModelBase
    {
        public Window CurrentWindow { get; set; }

        public abstract ICommand ClosingWindowCommand { get; set; }
        public abstract void ClosingWindow(object obj);

        public abstract ICommand CloseWindowCommand { get; set; }
        public abstract void CloseWindow(object obj);
    }
}
