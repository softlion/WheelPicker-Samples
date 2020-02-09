using System;
using WheelPickerDemo.Forms.Models;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
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
        public DayMonthModel DayMonth { get; } = new DayMonthModel();
    }
}