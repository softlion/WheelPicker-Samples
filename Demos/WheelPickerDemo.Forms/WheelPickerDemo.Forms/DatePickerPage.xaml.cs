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
    public partial class DatePickerPage : ContentPage
    {
        public DatePickerPage()
        {
            InitializeComponent();
            BindingContext = new DatePickerPageModel();
        }
    }

    internal class DatePickerPageModel
    {
        public DatePickerModel DatePicker { get; } = new DatePickerModel();
    }
}