using Cargo.Util.CommonControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Views.Main
{
    public interface IMainView
    {
        ICommonTextBox Text1 { get; set; }
    }
}
