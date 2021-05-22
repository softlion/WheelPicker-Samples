using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelPickerDemo.Forms.Pages.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeparatorLine : ContentPage
    {
        public List<IList<object>> MetricWeightItems { get; } = new List<IList<object>>
        {
            new List<object>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            new List<object>() { "a", "b", "c", "d", "e", "f", "g", "h" },
        };

        public SeparatorLine()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}