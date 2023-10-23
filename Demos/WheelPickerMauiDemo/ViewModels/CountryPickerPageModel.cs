using System.Windows.Input;
using WheelPickerMauiDemo.Models;

namespace WheelPickerDemo.Forms;

internal class CountryPickerPageModel
{
    public CountryPickerModel PickerModel { get; } = new ();

    public ICommand SelectItemByIndexCommand => new Command<string>(sIndex =>
    {
        if (int.TryParse(sIndex, out var index) && index>=0 && index < PickerModel.ItemsSource.Count)
        {
            PickerModel.SelectedItemsIndex = new[] {index};
        }
    });
}