using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vapolia.WheelPickerDemo
{
    public class DatePickerModel : INotifyPropertyChanged
    {
        private readonly List<string> wheel0, wheel1, wheel2;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<List<string>> Wheels { get; }

        public DateTime SelectedDate { get => selectedDate; set { selectedDate = value; OnPropertyChanged(); } }
        private DateTime selectedDate;

        private DateTime maxDate = DateTime.Now;

        public DatePickerModel()
        {
            wheel2 = new List<string>(Enumerable.Range(1900, maxDate.Year - 1900 + 1).Reverse().Select(year => year.ToString()));
            wheel1 = new List<string>(Enumerable.Range(1, 12).Select(month => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)));
            wheel0 = new List<string>(Enumerable.Range(1, 31).Select(day => day.ToString()));

            Wheels = new List<List<string>>(3) { wheel0, wheel1, wheel2 };
        }

        public List<string> GetWheel(int wheelIndex)
        {
            return wheelIndex == 0 ? wheel0 : wheelIndex == 1 ? wheel1 : wheel2;
        }

        /// <summary>
        /// If year or month changed, change the days collection.
        /// ObservableCollection will notify the WheelPicker which will reflect the changes.
        /// </summary>
        public void UpdateWheelsFromSelection(int wheelIndex, IList<int> selection)
        {
            var date = new DateTime(maxDate.Year - selection[2], 1 + selection[1], 1);
            var dayInMonth = 1 + selection[0];

            if (wheelIndex != 0)
            {
                var daysInMonth = (int)(date.AddMonths(1) - date).TotalDays;
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

            SelectedDate = date.AddDays(dayInMonth-1);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}