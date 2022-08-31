using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelericWPFHesabe3.EndPoint
{
    public class MainWindowModelDto : ModelBase
    {

        private string shopName;

        public string ShopName
        {
            get { return shopName; }
            set
            {
                shopName = value;
                OnPropertyChanged();
            }
        }
    }
}
