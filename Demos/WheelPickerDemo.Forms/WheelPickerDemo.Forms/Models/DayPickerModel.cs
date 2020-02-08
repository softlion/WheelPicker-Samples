using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms.Models
{
    /// <summary>
    /// A viewmodel to pick a day.
    /// ItemsSource is a list of string containing the name of the days of the week in the user's language.
    /// INotifyPropertyChanged is used to update the Label's text which is bound to the SelectedItem property.
    /// </summary>
    public class DayPickerModel : INotifyPropertyChanged
    {
        private string selectedItem;

        /// <summary>
        /// Command triggered after the user moved the wheel and the selected item has changed
        /// </summary>
        public Command ItemSelectedCommand { get; }

        /// <summary>
        /// For displaying the selected day in a Label
        /// </summary>
        public string SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }

        /// <summary>
        /// Simple (ie: 1 wheel only) data source for the wheel picker control.
        /// </summary>
        /// <remarks>
        /// Must be a list of object, no other type is allowed.
        /// </remarks>
        public IList<object> Days { get; }

        public DayPickerModel()
        {
            Days = GetDayNames().Cast<object>().ToList();
            selectedItem = (string)Days[0];

            //Subscribe to the selection changed command
            ItemSelectedCommand = new Command<(int, int, IList<int>)>(tuple =>
            {
                var (selectedWheelIndex, selectedItemIndex, _) = tuple;

                SelectedItem = (string)Days[selectedItemIndex];
                Debug.WriteLine($"ItemSelectedCommand called wheel:{selectedWheelIndex} row:{selectedItemIndex} value:{selectedItem}");
            });
        }

        #region Utilities
        public event PropertyChangedEventHandler PropertyChanged;
     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string[] GetDayNames()
        {
            return Shift(CultureInfo.CurrentCulture.DateTimeFormat.DayNames, (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        private static T[] Shift<T>(T[] array, int positions)
        {
            var copy = new T[array.Length];
            Array.Copy(array, 0, copy, array.Length - positions, positions);
            Array.Copy(array, positions, copy, 0, array.Length - positions);
            return copy;
        }
        #endregion
    }
}