using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Vapolia.WheelPickerForms;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    /// <summary>
    /// Use case: choose a day
    /// </summary>
    public partial class CountryPickerPage : ContentPage
    {
        public CountryPickerPage()
        {
            InitializeComponent();
            BindingContext = new CountryPickerPageModel();
        }
    }

    internal class CountryPickerPageModel
    {
        public CountryPickerModel PickerModel { get; } = new CountryPickerModel();
    }

    public class CountryPickerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IntegerList selectedItemsIndex;

        public List<object> ItemsSource { get; }
        public Command<(int, int, IList<int>)> ItemSelectedCommand { get; }

        public IntegerList SelectedItemsIndex
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
                    SelectedItemsIndex = new IntegerList(new[] { newIndex });
            }
        }

        public CountryPickerModel()
        {
            var countries = GetCountries();
            ItemsSource = new List<object>(countries.Values.OrderBy(c => c));

            if (countries.TryGetValue(RegionInfo.CurrentRegion.TwoLetterISORegionName, out var currentCountry))
                SelectedCountry = currentCountry;

            ItemSelectedCommand = new Command<(int, int, IList<int>)>(tuple =>
            {
                var (selectedWheelIndex, selectedItemIndex, selectedItemsIndexes) = tuple;
                OnPropertyChanged(nameof(SelectedCountry));
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Dictionary<string, string> GetCountries()
        {
            return new Dictionary<string, string>(CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures)
                .Distinct(new FuncEqualityComparer<CultureInfo>((info, cultureInfo) => info.LCID == cultureInfo.LCID))
                .Select(ci => new RegionInfo(ci.LCID))
                .Distinct(new FuncEqualityComparer<RegionInfo>((ri1, ri2) => ri1.TwoLetterISORegionName == ri2.TwoLetterISORegionName))
                .ToDictionary(ri => ri.TwoLetterISORegionName, ri => ri.DisplayName)
            );
        }

        class FuncEqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> comparer;
            private readonly Func<T, int> hash;

            public FuncEqualityComparer(Func<T, T, bool> comparer) : this(comparer, t => 0)
            {
                //Cannot assume anything about how t.GetHashCode() interacts with the comparer's behavior
            }

            public FuncEqualityComparer(Func<T, T, bool> comparer, Func<T, int> hash)
            {
                this.comparer = comparer;
                this.hash = hash;
            }

            public bool Equals(T x, T y)
            {
                return comparer(x, y);
            }

            public int GetHashCode(T obj)
            {
                return hash(obj);
            }
        }
    }
}
