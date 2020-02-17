using WheelPickerDemo.Forms.Models;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    /// <summary>
    /// Use case: choose a day
    /// </summary>
    public partial class DayPickerPage : ContentPage
    {
        public DayPickerPage()
        {
            InitializeComponent();
            BindingContext = new DayPickerPageModel();
        }
    }

    internal class DayPickerPageModel
    {
        public DayMonthYearModel PickerModel { get; } = new DayMonthYearModel(PickerModelType.Day);
    }
}
