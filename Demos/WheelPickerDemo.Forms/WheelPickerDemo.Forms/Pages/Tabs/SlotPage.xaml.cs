using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public partial class SlotPage : ContentPage
    {
        public SlotPage()
        {
            InitializeComponent();
            BindingContext = new SlotPageModel();
        }

        private async void ButtonSpin_OnClicked(object sender, EventArgs e)
        {
            SlotPicker.Spin(-100, 0);
            await Task.Delay(500);
            SlotPicker.Spin(-80, 1);
            await Task.Delay(1500);
            SlotPicker.Spin(-150, 2);
        }
    }

    internal class SlotPageModel
    {
        public SlotModel Slot { get; } = new SlotModel();
    }

    public class SlotModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Command triggered when a user moved the wheel and the value changed
        /// </summary>
        public Command ItemSelectedCommand { get; }

        /// <summary>
        /// Display the currently selected day in a Label
        /// </summary>
        public string SelectedItem { get { return selectedItem; } set { selectedItem = value; OnPropertyChanged(); } }
        private string selectedItem;

        /// <summary>
        /// Data source for wheel picker
        /// </summary>
        public List<IList<object>> ItemsSource { get; set; }

        public SlotModel()
        {
            ItemsSource = new List<IList<object>> {GetValues(), GetValues(), GetValues()};

            //Subscribe to the selection changed command
            ItemSelectedCommand = new Command<Tuple<int, int, IList<int>>>(tuple =>
            {
                var selectedWheelIndex = tuple.Item1;
                var selectedItemIndex = tuple.Item2;
                var selectedValue = ItemsSource[selectedWheelIndex][selectedItemIndex];
                Debug.WriteLine($"ItemSelectedCommand called wheel:{selectedWheelIndex} row:{selectedItemIndex} value:{selectedValue}");
                //SelectedItem = selectedValue;
            });
        }

        #region Utilities
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static object[] GetValues()
        {
            return new[] { (object)"seven", "seven", "seven", "seven", "seven", "seven", "seven" };
        }
        #endregion
    }
}
