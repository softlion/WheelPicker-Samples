using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelPickerDemo.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContainer : TabbedPage
    {
        public MainContainer()
        {
            InitializeComponent();
        }
    }
}