using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Views;

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

            //Optional: use an item builder to build complex cells for each wheel item
            wheelView.ItemsSimpleTemplates = new List<ItemFactoryDelegate> { ItemBuilder, ItemBuilder, ItemBuilder };

            wheelView.ItemsSource = model.Wheels;
            wheelView.SelectedItemsIndex = new List<int> { 0, 0, 0 };
        }

        #region Optional: use an item builder to build complex cells for each wheel item
        private View ItemBuilder(Context context, int wheelIndex, int itemIndex, View reusableView, bool isSelected, object data, Rect rect, MeasureItem childChanged)
        {
            var view = (ViewGroup) reusableView ?? CreateCell(context, wheelIndex); //Create/use same cell for all wheels and index
            
            var textView = view.FindViewById<TextView>(Resource.Id.valueText);
            textView.Text = data.ToString();
            textView.SetTextColor(isSelected ? Color.Red : Color.Black);
            
            childChanged(view,false);
            return view;
        }

        private ViewGroup CreateCell(Context context, int wheelIndex)
        {
            var group = new LinearLayout(context)
            {
                Orientation = Orientation.Horizontal,
                LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };

            if (wheelIndex == 0)
            {
                var iconView = new ImageView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
                    {
                        RightMargin = 20
                    }
                };
                iconView.SetImageResource(Resource.Drawable.Icon);
                group.AddView(iconView);
            }

            var textView = new TextView(context)
            {
                Id = Resource.Id.valueText,
                Gravity = GravityFlags.CenterVertical,
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
                {
                    Gravity = GravityFlags.CenterVertical,
                }
            };
            textView.SetTextSize(ComplexUnitType.Dip, 14);
            group.SetBackgroundColor(Color.Yellow);
            group.AddView(textView);

            return group;
        }
        #endregion
    }
}
