using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Vapolia.WheelPickerDemo
{
    [Activity(Label = "Vapolia Wheel Picker Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var wheelView = FindViewById<WheelPicker>(Resource.Id.wheelView);
            var text1 = FindViewById<TextView>(Resource.Id.valueText);
            var text2 = FindViewById<TextView>(Resource.Id.valueText2);

            var model = new DatePickerModel();

            model.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(model.SelectedDate))
                {
                    text1.Text = model.SelectedDate.ToLongDateString();
                }
            };

            //Use wheelView.SelectedItemIndexChangedCommand for Mvvm bindings
            wheelView.SelectedItemIndexChanged += (sender, args) =>
            {
                text2.Text = $"Wheel {args.WheelIndex} selection changed to item index {args.SelectedItemIndex} ('{model.GetWheel(args.WheelIndex)[args.SelectedItemIndex]}')";
                model.UpdateWheelsFromSelection(args.WheelIndex, wheelView.SelectedItemsIndex);
            };

            wheelView.ItemsSource = model.Wheels;
            wheelView.SelectedItemsIndex = new List<int> { 0, 0, 0 };
        }
    }
}
