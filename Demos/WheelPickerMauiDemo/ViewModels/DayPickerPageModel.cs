using WheelPickerMauiDemo.Models;

namespace WheelPickerMauiDemo.ViewModels;

internal class DayPickerPageModel
{
    public DayMonthYearModel PickerModel { get; } = new (PickerModelType.Day);
}