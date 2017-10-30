using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageModel();
        }

        private void ButtonSpin_OnClicked(object sender, EventArgs e)
        {
            WheelDayPicker.Spin(-100,0);
        }
    }

    internal class MainPageModel
    {
        public DayPickerModel DayPicker { get; } = new DayPickerModel();
    }
}
