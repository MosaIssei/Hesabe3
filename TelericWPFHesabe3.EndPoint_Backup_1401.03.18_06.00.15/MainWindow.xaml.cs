using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TelericWPFHesabe3.EndPoint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<modeee> dddd = new ObservableCollection<modeee>();
            Random r = new Random();
            for (int i = 0; i < 8000; i++)
            {
                dddd.Add(new modeee { Id = r.Next(1, 400), Name = r.Next(40000, 900000).ToString() });
            }
            asdad.ItemsSource = dddd;
        }
    }

    public class modeee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
