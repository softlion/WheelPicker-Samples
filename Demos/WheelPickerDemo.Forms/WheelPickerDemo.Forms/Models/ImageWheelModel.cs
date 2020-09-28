using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms.Models
{
    public class ImageWheelModel : INotifyPropertyChanged
    {
        private string selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Command triggered when a user moved the wheel and the value changed
        /// </summary>
        public Command ItemSelectedCommand { get; }

        /// <summary>
        /// Display the currently selected day in a Label
        /// </summary>
        public string SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }

        /// <summary>
        /// Data source for wheel picker
        /// </summary>
        public IReadOnlyList<string> ItemsSource { get; }

        public ImageWheelModel()
        {
            ItemsSource = GetDayNames();
            selectedItem = (string)ItemsSource[0];

            //Subscribe to the selection changed command
            ItemSelectedCommand = new Command<Tuple<int, int, IList<int>>>(tuple =>
            {
                var selectedWheelIndex = tuple.Item1;
                var selectedItemIndex = tuple.Item2;
                var selectedValue = ItemsSource[selectedItemIndex];
                Debug.WriteLine($"ItemSelectedCommand called wheel:{selectedWheelIndex} row:{selectedItemIndex} value:{selectedValue}");
                SelectedItem = (string)selectedValue;
            });
        }

        #region Utilities
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string[] GetDayNames()
        {
            return new[] {"Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7" };
        }
        #endregion
    }
}