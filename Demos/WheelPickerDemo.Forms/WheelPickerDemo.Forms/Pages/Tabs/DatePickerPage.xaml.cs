using System;
using WheelPickerDemo.Forms.Models;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public partial class DatePickerPage : ContentPage
    {
        public DatePickerPage()
        {
            InitializeComponent();
            BindingContext = new DatePickerPageModel();
        }
    }

    public class DatePickerPageModel
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