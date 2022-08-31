using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

using Telerik.Windows.Controls.Data.CardView;

namespace TelericWPFHesabe3.EndPoint.Settings.InformationSetting.Models
{
    public class InformationSettingModelDto : ModelBase
    {
        private string shopName = String.Empty;

        public string ShopName
        {
            get { return shopName; }
            set
            {
                var val = value.Trim();
                shopName = val;
                OnPropertyChanged();
            }
        }


        private string shopAddress = String.Empty;

        public string ShopAddress
        {
            get { return shopAddress; }
            set
            {
                var val = value.Trim();
                shopAddress = val;
                OnPropertyChanged();
            }
        }


        private string postalCode = "0";

        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                var val = value.Trim();
                if (string.IsNullOrEmpty(val))
                {
                    postalCode = "0";
                    return;
                }
                if (!val.All(s => char.IsDigit(s)))
                {
                    return;
                }
                postalCode = val;
                OnPropertyChanged();
            }
        }

        private string economicalNumber = "0";

        public string EconomicalNumber
        {
            get { return economicalNumber; }
            set
            {
                var val = value.Trim();
                if (string.IsNullOrEmpty(val))
                {
                    economicalNumber = "0";
                    return;
                }
                if (!val.All(s => char.IsDigit(s)))
                {
                    return;
                }
                economicalNumber = val;
                OnPropertyChanged();
            }
        }

        private string nationalCode = "0";

        public string NationalCode
        {
            get { return nationalCode; }
            set
            {
                var val = value.Trim();
                if (string.IsNullOrEmpty(val))
                {
                    nationalCode = "0";
                    return;
                }
                if (!val.All(s => char.IsDigit(s)))
                {
                    return;
                }
                nationalCode = val;
                OnPropertyChanged();
            }
        }

        private string areaCode = "0";

        public string AreaCode
        {
            get { return areaCode; }
            set
            {
                var val = value.Trim();
                if (string.IsNullOrEmpty(val))
                {
                    areaCode = "0";
                    return;
                }
                if (!val.All(s => char.IsDigit(s)))
                {
                    return;
                }
                areaCode = val;
                OnPropertyChanged();
            }
        }

        private string phone = "0";

        public string Phone
        {
            get { return phone; }
            set
            {
                var val = value.Trim();
                if (string.IsNullOrEmpty(val))
                {
                    phone = "0";
                    return;
                }
                if (!val.All(s => char.IsDigit(s)))
                {
                    return;
                }
                phone = val;
                OnPropertyChanged();
            }
        }

        public int Compare(InformationSettingModelDto x)
        {
            if (ShopName == x.ShopName && ShopAddress == x.ShopAddress && AreaCode == x.AreaCode && Phone == x.Phone && PostalCode == x.postalCode && NationalCode == x.NationalCode && EconomicalNumber == x.EconomicalNumber)
            {
                return 0;
            }
            return 1;
        }
    }
}
