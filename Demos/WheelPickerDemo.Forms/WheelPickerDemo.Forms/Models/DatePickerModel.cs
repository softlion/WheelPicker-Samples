using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Vapolia.WheelPickerForms;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms
{
    public class DatePickerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ObservableCollection<object> wheel0, wheel1, wheel2;
        private readonly DateTime MaxDate = DateTime.Now.AddYears(2);

        public List<IList<object>> ItemsSource { get; }

        public IntegerList SelectedItemsIndex
        {
            get => selectedItemsIndex;
            set { selectedItemsIndex = value; OnPropertyChanged(); }
        }

        public string SelectedItem => selectedDate.ToString("D");

        public DateTime SelectedDate
        {
            get => selectedDate;
            private set
            {
                selectedDate = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private DateTime selectedDate;
        private IntegerList selectedItemsIndex;

        public Command<Tuple<int, int, IList<int>>> ItemSelectedCommand { get; }

        public DatePickerModel()
        {
            wheel2 = new ObservableCollection<object>(Enumerable.Range(1900, MaxDate.Year - 1900 + 1).Reverse().Select(year => year.ToString()));
            wheel1 = new ObservableCollection<object>(Enumerable.Range(1, 12).Select(month => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)));
            wheel0 = new ObservableCollection<object>(Enumerable.Range(1, 31).Select(day => day.ToString()));

            ItemsSource = new List<IList<object>>(3) {wheel0, wheel1, wheel2};

            ItemSelectedCommand = new Command<Tuple<int, int, IList<int>>>(tuple =>
            {
                //When the selection changed, update the SelectedDate string 
                UpdateWheelsFromSelection(tuple.Item1, tuple.Item3);
            });

            //Set the initial selection
            SetSelectedDate(DateTime.Now);
        }

        public void SetSelectedDate(DateTime date)
        {
            var selection = new List<int> {date.Day - 1, date.Month - 1, MaxDate.Year-date.Year};
            SelectedItemsIndex = new IntegerList(selection);
            UpdateWheelsFromSelection(1, selection);
        }

        /// <summary>
        /// If year or month changed, change the 'days' collection.
        /// ObservableCollection will notify the WheelPicker which will reflect the changes.
        /// </summary>
        private void UpdateWheelsFromSelection(int wheelIndex, IList<int> selection)
        {
            var date = new DateTime(MaxDate.Year - selection[2], 1 + selection[1], 1);
            var dayInMonth = 1 + selection[0];

            if (wheelIndex != 0)
            {
                var daysInMonth = (int) (date.AddMonths(1) - date).TotalDays;
                if (dayInMonth > daysInMonth)
                    dayInMonth = daysInMonth;

                if (wheel0.Count != daysInMonth)
                {
                    while (daysInMonth < wheel0.Count)
                        wheel0.RemoveAt(wheel0.Count - 1);

                    for (var day = wheel0.Count + 1; day <= daysInMonth; day++)
                        wheel0.Add(day.ToString());
                }
            }

            SelectedDate = date.AddDays(dayInMonth - 1);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}