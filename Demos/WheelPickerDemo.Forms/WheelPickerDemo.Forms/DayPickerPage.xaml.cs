using WheelPickerDemo.Forms.Models;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
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
        public DayPickerModel PickerModel { get; } = new DayPickerModel();
    }
}
