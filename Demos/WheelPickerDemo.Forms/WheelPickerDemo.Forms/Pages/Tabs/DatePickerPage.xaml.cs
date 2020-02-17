using System;
using WheelPickerDemo.Forms.Models;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    /// <summary>
    /// Use case: input full birthday with year
    /// </summary>
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
        public DayMonthYearModel DatePicker { get; } = new DayMonthYearModel();

        public string ManualDate { get; set; }

        public Command ManualDateCommand => new Command(() =>
        {
            if (DateTime.TryParse(ManualDate, out var date))
                DatePicker.SelectedDate = date;
        });
    }
}
