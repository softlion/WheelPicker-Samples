using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Vapolia.WheelPickerForms;
using Xamarin.Forms;

namespace WheelPickerDemo.Forms.Models
{
    public enum PickerModelType
    {
        DayMonthYear,
        DayMonth,
        MonthYear,
        Day,
        Month,
        Year,
    }


    public class DayMonthYearModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ObservableCollection<string> wheelDay, wheelMonth, wheelYear;
        private DateTime selectedDate;
        private IList<int> selectedItemsIndex;

        //TODO
        private readonly DateTime MaxDate = DateTime.Now.AddYears(2);
        private readonly DateTime MinDate = new DateTime(1900,1,1);

        public IReadOnlyCollection<ObservableCollection<string>> ItemsSource { get; }
        public PickerModelType DisplayType { get; }
        public Command<(int, int, IList<int>)> ItemSelectedCommand { get; }

        public IList<int> SelectedItemsIndex
        {
            get => selectedItemsIndex;
            set { selectedItemsIndex = value; OnPropertyChanged(); }
        }

        public DateTime SelectedDate
        {
            get => selectedDate;
            set  => SetSelectedDateExternal(value);
        }


        public DayMonthYearModel(PickerModelType displayType = PickerModelType.DayMonthYear)
        {
            DisplayType = displayType;

            wheelYear = new ObservableCollection<string>(Enumerable.Range(MinDate.Year, MaxDate.Year - MinDate.Year + 1).Reverse().Select(year => year.ToString()));
            wheelMonth = new ObservableCollection<string>(Enumerable.Range(1, 12).Select(month => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)));
            wheelDay = new ObservableCollection<string>(Enumerable.Range(1, 31).Select(day => day.ToString()));

            switch (DisplayType)
            {
                case PickerModelType.DayMonthYear:
                    ItemsSource = new [] { wheelDay, wheelMonth, wheelYear };
                    selectedDate = DateTime.Today;
                    break;
                case PickerModelType.DayMonth:
                    ItemsSource = new []  { wheelDay, wheelMonth };
                    selectedDate = DateTime.Today;
                    break;
                case PickerModelType.Day:
                    ItemsSource = new [] { wheelDay };
                    selectedDate = new DateTime(2020, 8, 1, 12,0,0,0, DateTimeKind.Utc);
                    break;
            }

            ItemSelectedCommand = new Command<(int, int, IList<int>)>(tuple =>
            {
                var (selectedWheelIndex, selectedItemIndex, selectedItemsIndexes) = tuple;
                //After the selection has changed, update the SelectedDate string 
                UpdateDaysFromMonthYear(selectedWheelIndex, selectedItemsIndexes);
            });

            //Set the initial selection
            SetSelectedDateExternal(DateTime.Now);
        }

        private void SetSelectedDateExternal(DateTime date)
        {
            if (date < MinDate)
                date = MinDate;
            if (date > MaxDate)
                date = MaxDate;
            selectedDate = date;

            List<int> selection = null;
            var fullSelection = new List<int> { date.Day - 1, date.Month - 1, MaxDate.Year - date.Year };

            switch (DisplayType)
            {
                case PickerModelType.DayMonthYear:
                    selection = fullSelection;
                    break;
                case PickerModelType.DayMonth:
                    selection = fullSelection.Take(2).ToList();
                    break;
                case PickerModelType.Day:
                    selection = fullSelection.Take(1).ToList();
                    break;
            }

            SelectedItemsIndex = selection;
            UpdateDaysFromMonthYear(1, fullSelection);
        }

        private void SetSelectedDateInternal(DateTime value)
        {
            selectedDate = value;
            OnPropertyChanged(nameof(SelectedDate));
        }

        /// <summary>
        /// If year or month changed, change the 'days' collection.
        /// ObservableCollection will notify the WheelPicker which will reflect the changes.
        /// </summary>
        private void UpdateDaysFromMonthYear(int wheelIndex, IList<int> selection)
        {
            var selectedYear = selectedDate.Year;
            var selectedMonth = selectedDate.Month;
            var selectedDay = selectedDate.Day;
            var yearWheelIndex = -1;

            switch (DisplayType)
            {
                case PickerModelType.DayMonthYear:
                    yearWheelIndex = 0;
                    selectedYear = MaxDate.Year - selection[2];
                    selectedMonth = 1 + selection[1];
                    selectedDay = 1 + selection[0];
                    break;
                case PickerModelType.DayMonth:
                    selectedMonth = 1 + selection[1];
                    selectedDay = 1 + selection[0];
                    break;
                case PickerModelType.Day:
                    selectedDay = 1 + selection[0];
                    break;
            }

            var date = new DateTime(selectedYear, selectedMonth, 1);
            var dayInMonth = selectedDay;

            if (wheelIndex != yearWheelIndex)
            {
                var daysInMonth = (int) (date.AddMonths(1) - date).TotalDays;
                if (dayInMonth > daysInMonth)
                    dayInMonth = daysInMonth;

                if (wheelDay.Count != daysInMonth)
                {
                    while (daysInMonth < wheelDay.Count)
                        wheelDay.RemoveAt(wheelDay.Count - 1);

                    for (var day = wheelDay.Count + 1; day <= daysInMonth; day++)
                        wheelDay.Add(day.ToString());
                }
            }

            SetSelectedDateInternal(date.AddDays(dayInMonth - 1));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}