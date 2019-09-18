using System;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
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

        public string ManualDate { get; set; }

        public Command ManualDateCommand => new Command(() =>
        {
            if (DateTime.TryParse(ManualDate, out var date))
                DatePicker.SetSelectedDate(date);
        });
    }
}