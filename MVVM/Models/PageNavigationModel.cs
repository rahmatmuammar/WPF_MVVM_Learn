using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Learn.MVVM.Models
{
    public class PageNavigationModel
    {
        public string Page { get; }

        public PageNavigationModel(string page)
        {
            Page = page;
        }
    }
}
