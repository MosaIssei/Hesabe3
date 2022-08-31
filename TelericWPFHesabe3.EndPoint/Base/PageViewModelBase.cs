using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TelericWPFHesabe3.EndPoint.Base
{
    public abstract class PageViewModelBase : ModelBase
    {
        public Page CurentPage { get; set; }
    }
}
