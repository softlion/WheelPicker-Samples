using WheelPickerMauiDemo.Models;

namespace WheelPickerMauiDemo.ViewModels;

internal class DayMonthPickerPageModel
{
    public DayMonthYearModel DayMonth { get; } = new (PickerModelType.DayMonth);
}