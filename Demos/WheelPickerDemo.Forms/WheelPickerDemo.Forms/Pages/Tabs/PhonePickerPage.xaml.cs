using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PhoneNumbers;
using Vapolia.WheelPickers;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    /// <summary>
    /// Use case: choose a phone number
    /// </summary>
    public partial class PhonePickerPage : ContentPage
    {
        public PhonePickerPage()
        {
            var model = new PhonePickerPageModel();
            BindingContext = model;
            InitializeComponent();

            #region Animate visibility of the wheel picker
            //{Binding IsPhonePickerVisible}
            model.PropertyChanged += async (sender, args) =>
            {
                if (args.PropertyName == nameof(PhonePickerPageModel.IsPhonePickerVisible))
                {
                    var yOriginFromBottom = PhoneRegionWheel.Height;
                    if (model.IsPhonePickerVisible)
                    {
                        //Animate visibility
                        PhoneRegionWheel.TranslationY = yOriginFromBottom;
                        if (!PhoneRegionWheel.IsVisible)
                            PhoneRegionWheel.IsVisible = true;
                        await PhoneRegionWheel.TranslateTo(0, 0, easing: Easing.CubicOut);
                    }
                    else
                    {
                        //Animate invisibility
                        PhoneRegionWheel.TranslationY = 0;
                        await PhoneRegionWheel.TranslateTo(0, yOriginFromBottom, easing: Easing.CubicIn);
                        PhoneRegionWheel.IsVisible = false;
                    }
                }
            };
            #endregion
        }
    }

    public class RegionViewModel
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string FullDisplayName => $"{DisplayName} {DisplayPrefix}";
        public int Prefix { get; set; }
        public string DisplayPrefix => $"+{Prefix}";
    }

    internal class PhonePickerPageModel : INotifyPropertyChanged
    {
        private string phone;
        private RegionViewModel phoneRegion = new RegionViewModel();
        private bool isPhonePickerVisible;

        public RegionViewModel PhoneRegion
        {
            get => phoneRegion;
            set { SetProperty(ref phoneRegion, value); OnPropertyChanged(nameof(FullPhone)); }
        }

        public string Phone
        {
            get => phone;
            set { SetProperty(ref phone, value); OnPropertyChanged(nameof(FullPhone)); }
        }
        
        public PhonePickerWheelModel PickerModel { get; } = new PhonePickerWheelModel();
        public string FullPhone => String.IsNullOrWhiteSpace(phone) ? String.Empty : phoneRegion.DisplayPrefix + phone;

        public bool IsPhonePickerVisible { get => isPhonePickerVisible; private set => SetProperty(ref isPhonePickerVisible, value); }
        public Command ChoosePhoneCountryCommand { get; } 
        public Command EndChoosePhoneCountryCommand { get; }

        public PhonePickerPageModel()
        {
            ChoosePhoneCountryCommand = new Command(() => IsPhonePickerVisible = true);
            EndChoosePhoneCountryCommand = new Command(() => IsPhonePickerVisible = false);
            PickerModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(PhonePickerWheelModel.SelectedPhoneRegion))
                    PhoneRegion = PickerModel.SelectedPhoneRegion;
            };
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }

    public class PhonePickerWheelModel : INotifyPropertyChanged
    {
        private IList<int> selectedItemsIndex;
        private readonly Lazy<PhoneNumberUtil> pnuLazy = new Lazy<PhoneNumberUtil>(PhoneNumberUtil.GetInstance);
        private PhoneNumberUtil pnu => pnuLazy.Value;
        private readonly List<RegionViewModel> regions;

        public List<RegionViewModel> ItemsSource { get; }

        public IList<int> SelectedItemsIndex
        {
            get => selectedItemsIndex;
            set { selectedItemsIndex = value; OnPropertyChanged(); OnPropertyChanged(nameof(SelectedPhoneRegion)); }
        }

        public RegionViewModel SelectedPhoneRegion => selectedItemsIndex[0] >= 0 ? (RegionViewModel)ItemsSource[selectedItemsIndex[0]] : null;

        public PhonePickerWheelModel()
        {
            //This is an example only.
            //Libphonenumbers is very slow to initialize. This initialization should be done in a worker thread instead.
            //Also some regions are unknown to the .net framework (RegionInfo returns null): for example Cyprus (a Greek island) and Guadeloupe (a French island).
            //Those needs to be separated as they have a different phone prefix.
            regions = GetRegions()
                .Select(c => new RegionViewModel { Code = c.Key, DisplayName = GetDisplayName(c.Key), Prefix = c.Value })
                .Where(c => c.DisplayName != null)
                .OrderBy(ct => ct.DisplayName)
                .ToList();

            ItemsSource = regions;
            SetSelectedPhoneRegion(RegionInfo.CurrentRegion.TwoLetterISORegionName);
        }

        public void SetSelectedPhoneRegion(string regionCode)
        {
            var newIndex = regions.FindIndex(0, r => r.Code == regionCode);
            if (newIndex < 0)
                newIndex = 0;
            SelectedItemsIndex = new[] { newIndex };
        }

        private Dictionary<string, int> GetRegions()
            => pnu.GetSupportedRegions().ToDictionary(region => region, region => pnu.GetCountryCodeForRegion(region));
        
        private string GetDisplayName(string key)
        {
            try
            {
                var region = new RegionInfo(key);
                return region.DisplayName;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
