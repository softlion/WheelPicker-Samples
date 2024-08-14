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
            Vapolia.WheelPickers.Config.License = "eyJhbGciOiJSUzI1NiIsImtpZCI6InZhcG9saWFzaWciLCJ0eXAiOiJKV1QifQ.eyJodHRwczovL3NjaGVtYXMudmFwb2xpYS5ldS8yMDIwLzA1L2NsYWltcy9MaWNlbnNlc0NsYWltIjoie1wiTGljZW5zZXNcIjpbe1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJcIixcIk9zXCI6XCJpb3NcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS5XaGVlbFBpY2tlckRlbW9Gb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwiYW5kcm9pZFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLldoZWVsUGlja2VyRGVtb0Zvcm1zXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJcIixcIk9zXCI6XCJ1d3BcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS5XaGVlbFBpY2tlckRlbW9Gb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyZm9ybXNcIixcIk9zXCI6XCJpb3NcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS5XaGVlbFBpY2tlckRlbW9Gb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyZm9ybXNcIixcIk9zXCI6XCJhbmRyb2lkXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEuV2hlZWxQaWNrZXJEZW1vRm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlcmZvcm1zXCIsXCJPc1wiOlwidXdwXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEuV2hlZWxQaWNrZXJEZW1vRm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlclwiLFwiT3NcIjpcImlvc1wiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwiYW5kcm9pZFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwidXdwXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJmb3Jtc1wiLFwiT3NcIjpcImlvc1wiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyZm9ybXNcIixcIk9zXCI6XCJhbmRyb2lkXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJmb3Jtc1wiLFwiT3NcIjpcInV3cFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwiaW9zXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlclwiLFwiT3NcIjpcImFuZHJvaWRcIixcIkFwcElkXCI6XCJjb20udmFwb2xpYS53aGVlbHBpY2tlcmRlbW9mb3Jtc1wiLFwiTWF4QnVpbGRcIjpcIjIwMjEtMDctMDlUMjA6MTM6MTYuODM1NTg5KzAyOjAwXCJ9LHtcIlByb2R1Y3RcIjpcIndoZWVscGlja2VyXCIsXCJPc1wiOlwidXdwXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlcmZvcm1zXCIsXCJPc1wiOlwiaW9zXCIsXCJBcHBJZFwiOlwiY29tLnZhcG9saWEud2hlZWxwaWNrZXJkZW1vZm9ybXNcIixcIk1heEJ1aWxkXCI6XCIyMDIxLTA3LTA5VDIwOjEzOjE2LjgzNTU4OSswMjowMFwifSx7XCJQcm9kdWN0XCI6XCJ3aGVlbHBpY2tlcmZvcm1zXCIsXCJPc1wiOlwiYW5kcm9pZFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb2Zvcm1zXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn0se1wiUHJvZHVjdFwiOlwid2hlZWxwaWNrZXJmb3Jtc1wiLFwiT3NcIjpcInV3cFwiLFwiQXBwSWRcIjpcImNvbS52YXBvbGlhLndoZWVscGlja2VyZGVtb2Zvcm1zXCIsXCJNYXhCdWlsZFwiOlwiMjAyMS0wNy0wOVQyMDoxMzoxNi44MzU1ODkrMDI6MDBcIn1dfSIsIm5iZiI6MTU5NDMxODM5NiwiZXhwIjoxOTA5ODUxMTk2LCJpYXQiOjE1OTQzMTgzOTYsImlzcyI6Imh0dHBzOi8vdmFwb2xpYS5ldS9hdXRob3JpdHkiLCJhdWQiOiJodHRwczovL3ZhcG9saWEuZXUvYXV0aG9yaXR5L2xpY2Vuc2VzIn0.qsktxo6OA0HNQU0TVnVxzQ0j6zoMw3CSbwTzhRfkQ3jmHnYk3N1pcnRobcP69h-9P8X3M9Ye-2iflq5Kkdv36unwp4B6X6HLpFlz1su9doMQmlHkea1HkNXip2o3BCgCOWFHDVdVLYV9D-AQtspiuiOTthgRezYvqt1kLtfM3qfrjKw7tTXv2TAX91T8-iNRb3OSc9TQeHESPBDTYYFDV6SHUECRSuOH8_-V5gUtxoIS7c1xMOJkdty-L8pYGn45BmtdaL3bMdXY_eYQwq7uYIxRHPcQ-KEioqtyU158Jzh4uX14OjcBkQ2Bz1Qhd6rFNz8Q0EpZ2roNfoNpqLX-XQ";

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var wheelView = FindViewById<WheelPickr>(Resource.Id.wheelView);
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
