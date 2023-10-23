using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Nager.Country;
using Nager.Country.Translation;

namespace WheelPickerMauiDemo.Models;

public sealed class CountryPickerModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private IList<int> selectedItemsIndex;

    public List<string> ItemsSource { get; }
    public Command<(int, int, IList<int>)> ItemSelectedCommand { get; }

    public IList<int> SelectedItemsIndex
    {
        get => selectedItemsIndex;
        set { selectedItemsIndex = value; OnPropertyChanged(); }
    }

    public string SelectedCountry
    {
        get => selectedItemsIndex[0] >= 0 ? (string)ItemsSource[selectedItemsIndex[0]] : null;
        set
        {
            var newIndex = ItemsSource.FindIndex(0, o => o.Equals(value));
            if(newIndex>=0)
                SelectedItemsIndex = new[] { newIndex };
        }
    }

    public CountryPickerModel()
    {
        var countries = GetCountries();
        ItemsSource = countries.Values.OrderBy(c => c).ToList();

        if (countries.TryGetValue(RegionInfo.CurrentRegion.TwoLetterISORegionName, out var currentCountry))
            SelectedCountry = currentCountry;

        ItemSelectedCommand = new (tuple =>
        {
            var (selectedWheelIndex, selectedItemIndex, selectedItemsIndexes) = tuple;
            OnPropertyChanged(nameof(SelectedCountry));
        });
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new (propertyName));
    }

    private Dictionary<string, string> GetCountries()
    {
        var countryProvider = new CountryProvider();
        var translationProvider = new TranslationProvider();

        var countries = countryProvider.GetCountries();
        return countries.ToDictionary(
            item => item.Alpha2Code.ToString(), 
            item => translationProvider.GetCountryTranslatedName(item.Alpha2Code, CultureInfo.CurrentCulture) ?? item.OfficialName);
    }
}