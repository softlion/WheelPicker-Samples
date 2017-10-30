using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public class DayPickerModel : INotifyPropertyChanged
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
        public IList<string> ItemsSource { get; }

        public DayPickerModel()
        {
            ItemsSource = GetDayNames();
            selectedItem = ItemsSource[0];

            //Subscribe to the selection changed command
            ItemSelectedCommand = new Command<Tuple<int, int, IList<int>>>(tuple =>
            {
                var selectedWheelIndex = tuple.Item1;
                var selectedItemIndex = tuple.Item2;
                var selectedValue = ItemsSource[selectedItemIndex];
                Debug.WriteLine($"ItemSelectedCommand called wheel:{selectedWheelIndex} row:{selectedItemIndex} value:{selectedValue}");
                SelectedItem = selectedValue;
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
            //return Shift(CultureInfo.CurrentCulture.DateTimeFormat.DayNames, (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        private static T[] Shift<T>(T[] array, int positions)
        {
            T[] copy = new T[array.Length];
            Array.Copy(array, 0, copy, array.Length - positions, positions);
            Array.Copy(array, positions, copy, 0, array.Length - positions);
            return copy;
        }
        #endregion
    }
}