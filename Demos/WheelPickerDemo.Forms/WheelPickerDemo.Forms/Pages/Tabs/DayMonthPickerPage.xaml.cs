using System;
using WheelPickerDemo.Forms.Models;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    /// <summary>
    /// Use case: input birthday without year
    /// </summary>
    public partial class DayMonthPickerPage : ContentPage
    {
        public DayMonthPickerPage()
        {
            BindingContext = new DateMonthPickerPageModel();
            InitializeComponent();
        }
    }

    public class DateMonthPickerPageModel
    {
        public DayMonthYearModel DayMonth { get; } = new DayMonthYearModel(PickerModelType.DayMonth);
    }
}
