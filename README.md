| Xamarin.Forms (iOS, Android)| Xamarin.Android, Xamarin.iOS|
|:---------------------------:|:---------------------------:|
| [![NuGet][nuget-img]][nuget-link-forms]  ![Nuget](https://img.shields.io/nuget/dt/Vapolia.WheelPicker.Forms) | [![NuGet][nuget-img]][nuget-link]  ![Nuget](https://img.shields.io/nuget/dt/Vapolia.WheelPicker) |
| [![][demo-img]][demo-link] | [![][demo-img]][demo-link] |


# Wheel Picker for Xamarin Samples
From Apple, _**Wheel Picker**: a view that uses a spinning-wheel or slot-machine metaphor to show one or more sets of values_.

Xamarin Forms Control:
`WheelPicker`

Xamarin Android Control:
`vapolia.WheelPicker`

Xamarin iOS Control:
`UIPickerViewModel`

[Enterprise support available. More infos.](https://vapolia.eu)

[![Preview][video-img]][video-link]

[video-img]: https://i.vimeocdn.com/video/668500920.webp?mw=400&mh=540
[video-link]: https://vimeo.com/244170732
[nuget-img]: https://img.shields.io/nuget/v/Vapolia.WheelPicker
[nuget-link]: https://www.nuget.org/packages/Vapolia.WheelPicker/
[nuget-link-forms]: https://www.nuget.org/packages/Vapolia.WheelPicker.Forms/
[demo-img]: https://img.shields.io/badge/demo-source%20code-lightgrey.svg
[demo-link]: https://github.com/softlion/WheelPicker-Samples/tree/master/Demos

## Overview

This control brings the Wheel Picker view to Xamarin Forms on Android and iOS (it also supports native Xamarin Android and iOS).
It mimics a slot-machine user interface on Android, while on iOS it makes easy to use multi wheel pickers.

### Easy to use

A simple picker with one wheel

```xml
<wp:WheelPicker ItemsSourceSimple="{Binding DayPicker.ItemsSource}">
    <wp:WheelDefinition Width="Auto" HorizontalOptions="Left" Alignment="Center" />
</wp:WheelPicker>
```

A templated picker with one wheel

```xml
<wp:WheelPicker ItemsSourceSimple="{Binding DayPicker.ItemsSource}">
    <wp:WheelDefinition Width="*" HorizontalOptions="Left" Alignment="Center" IsCircular="True" RowHeight="48">
        <DataTemplate>
            <Image Source="{Binding .}" HeightRequest="48" Aspect="AspectFill" />
        </DataTemplate>
    </wp:WheelDefinition>
</wp:WheelPicker>
```

Note that the tag `wp:WheelDefinition.ItemTemplate` is optional as it is the content property.


A picker with 3 wheels  
The center wheel's width is computed automatically. Items are aligned differently inside each wheel.

```xml
<wp:WheelPicker SelectionLinesColor="Navy" 
                HorizontalSpaceBetweenWheels="40" 
                ItemsSourceMulti="{Binding DatePicker.ItemsSource}"  
                SelectedItemsIndex="0,0,0" 
                Command="{Binding DatePicker.ItemSelectedCommand}"
                HorizontalOptions="Fill">
    <wp:WheelDefinition Width="*" HorizontalOptions="Right" />
    <wp:WheelDefinition Width="Auto" HorizontalOptions="Left"  />
    <wp:WheelDefinition Width="*" HorizontalOptions="Left"  />
</wp:WheelPicker>
```

A templated picker with 3 wheels  
All properties are bindable and can be dynamically changed.

```xml
<wp:WheelPicker x:Name="SlotPicker" ItemsSourceMulti="{Binding Slot.ItemsSource}" 
                SelectedItemsIndex="0 0 0"
                Command="{Binding Slot.ItemSelectedCommand}" 
                ItemTextSelectedColor="Lime"
                ItemTextFont="Italic"
                HorizontalOptions="Fill"
                SelectionLinesColor="Aquamarine">
    <wp:WheelDefinition Width="*" HorizontalOptions="Left" Alignment="Center" IsCircular="True" RowHeight="100">
        <DataTemplate>
            <Image Source="{Binding .}" HeightRequest="100" Aspect="AspectFit" />
        </DataTemplate>
    </wp:WheelDefinition>
    <wp:WheelDefinition Width="*" HorizontalOptions="Left" Alignment="Center" IsCircular="True" RowHeight="100">
        <DataTemplate>
            <Image Source="{Binding .}" HeightRequest="100" Aspect="AspectFit" />
        </DataTemplate>
    </wp:WheelDefinition>
    <wp:WheelDefinition Width="*" HorizontalOptions="Left" Alignment="Center" IsCircular="True" RowHeight="100">
        <DataTemplate>
            <Image Source="{Binding .}" HeightRequest="100" Aspect="AspectFit" />
        </DataTemplate>
    </wp:WheelDefinition>
</wp:WheelPicker>
```

## Quick start

#### Install the nuget package

- In your Forms project
  - Install the nuget package

That's all!

#### Add the WheelPicker control

- Add `xmlns:wp="clr-namespace:Vapolia.WheelPickerForms;assembly=Vapolia.WheelPickerForms"` to the root tag of a view.   
- Add a minimal wheel:

```xml
<wp:WheelPicker ItemsSourceSimple="{Binding MyListProperty}">
    <wp:WheelDefinition Width="Auto" HorizontalOptions="Left" Alignment="Center" />
</wp:WheelPicker>
```

A Wheel Picker is made of one or more wheels, and is bound to a single data source. Add more `wp:WheelDefinition` to add more wheels. In this example MyListProperty is a `List<string>`

If you have more than one WheelDefinition, use `ItemsSourceMulti` instead of `ItemsSourceSimple`; MyListProperty must then be of type `IReadOnlyCollection<IReadOnlyCollection<T>>` (Ex: List<List<string>>) where the outer list must have a number of items equal to the count of WheelDefinitions. Each inner list contains the items for this WheelDefinition.


## Full start

- In your Forms project
  - Install the nuget package


### Add the WheelPicker control to your views

Add the namespace `xmlns:wp="clr-namespace:Vapolia.WheelPickerForms;assembly=Vapolia.WheelPickerForms"` to the root tag.   
Then add a `wp:WheelPicker` tag and set the properties you need.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
                xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                xmlns:wp="clr-namespace:Vapolia.WheelPickerForms;assembly=Vapolia.WheelPickerForms"
                x:Class="WheelPickerDemo.Forms.MainPage">
    <StackLayout>

        <wp:WheelPicker HorizontalOptions="Fill" SelectedItemsIndex="0"
                    ItemsSourceSimple="{Binding Days}" 
                    Command="{Binding ItemSelectedCommand}">
            <wp:WheelDefinition Width="Auto" HorizontalOptions="Left" Alignment="Center" />
        </wp:WheelPicker>

    </StackLayout>
</ContentPage>
```

<br/>In the code behind, set the binding context to your view model containing the items to display:

```csharp
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageModel();
    }
}

public class MainPageModel
{
    public List<string> Days { get; } = new List<string>
    {
        "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday",
    };

    public Command ItemSelectedCommand { get; }

    public MainPageModel() 
    {
        ItemSelectedCommand = new Command<(int Component, int Row, IList<int> ItemIndexes)>(tuple =>
        {
            var selectedValue = Days[tuple.Row];
            //...
        });
    }
}
```

<br/>In the above example, ```ItemsSourceSimple``` is bound to a list of strings. If you need more than one wheel, use the ```ItemsSourceMulti``` property and bind it to a ```List<List<string>>``` where the outer list represents the wheels and the inner lists the items in each wheel.


## Reference (Xamarin Forms)
<details><summary>Click to expand</summary>

**WheelPicker**

Definition  
- `IList<WheelDefinition>` **`WheelDefinitions`** Default Content
- `IReadOnlyCollection<IReadOnlyCollection<T>>` **`ItemsSourceMulti`** Ex: `List<ObservableCollection<string>>`.
- `IReadOnlyCollection<T>` **`ItemsSourceSimple`** Shortcut for ItemsSourceMulti with one wheel. Ex: `List<string>`.

Appearance  
- `double` **`HorizontalSpaceBetweenWheels`**
- `Color` **`SelectionLinesColor`**

Item appearance (when not using a templated item)  
- `Font` **`ItemTextFont`**
- `Color` **`ItemTextColor`**
- `Color` **`ItemTextSelectedColor`**

Selection  
- `IList<int>` **`SelectedItemsIndex`**
- `ICommand` **`Command`**
- `EventHandler<WheelChangedEventArgs>` **`SelectedItemIndexChanged`**
- `void` **`Spin`**`(int items, int wheelIndex = 0)` items: the number of item to spin

`SelectedItemsIndex` is a list of integer. Each integer represents the selected index inside a wheel. In XAML, you can use a space or comma separated string of integers.

**WheelDefinition**

- `GridLength` **`Width`**
- `WheelItemAlign` **`HorizontalOptions`**
- `WheelItemAlign` **`Alignment`**
- `bool` **`IsCircular`**
- `DataTemplate` **`ImageItemTemplate`**
- `double` **`RowHeight`**

When a wheel's `Width` is set to `Auto`, the control computes the max width of all strings in the data source (if object are strings).  When set to `*` (star), the wheel's width will be proportional to the remaining space. See the Xamarin Forms `Grid` control for more information about `GridLength`.

`HorizontalOptions` is used to align a wheel inside the available WheelPicker's width, if it is larger than the wheel's width.

`Alignment` is used to align the items inside a wheel.
</details>

## Reference (Xamarin.Android)
<details><summary>Click to expand</summary>

Sample usage in axml:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <vapolia.WheelPicker
        android:id="@+id/wheelView"
        app:itemWidths="* Auto *"
        app:itemAligns="Right Left Left"
        app:itemHeights="15dp 15dp 15dp"
        app:selectedItemTextColor="#ff228b22"
        app:wp_itemTextColor="#ffffb6c1"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:background="#FFFFFF" />
</LinearLayout>
```

```csharp
var wheelView = FindViewById<WheelPicker>(Resource.Id.wheelView);
wheelView.SelectedItemIndexChanged += (sender, args) =>
{
    var text = $"Wheel {args.WheelIndex} selection changed to item index {args.SelectedItemIndex}";
};
wheelView.ItemsSource = new List<string> { "Monday", "Tuesday", "Wednesday" };
wheelView.SelectedItemsIndex = new [] { 0 };
```

**vapolia.WheelPicker**

Definition  
- object ItemsSource (either IReadOnlyCollection&lt;T&gt; or IReadOnlyCollection&lt;IReadOnlyCollection&lt;T&gt;&gt;)  
- IReadOnlyCollection&lt;T&gt; ItemsSourceSimple (shortcut for ItemsSourceMulti with one wheel)
- IReadOnlyCollection&lt;IReadOnlyCollection&lt;T&gt;&gt; ItemsSourceMulti
- int VisibleItemCount

WheelPicker Appearance  
- float HorizontalSpaceBetweenWheels  
- float VerticalSpaceBetweenItems  
- float ItemTextSize  
- Typeface ItemTextTypeface  
- Color ItemTextColor  
- Color ItemTextSelectedColor  
- bool ShowSelectionLines  
- float SelectionLinesThickness  
- Color SelectionLinesColor  
- bool HasFadingItems  
- bool IsCurved

Appearance of a wheel (a picker can have multiple wheels)
- string ItemWidths (width of each wheel, see ItemWidths chapter below)  
- IList&lt;GravityFlags&gt; Gravities  
- GravityFlags Gravity (shortcut for Gravities[0], used only when ItemWidths is set)  
- IList<double> ItemHeights

Appearance of items inside a wheel
- IList<WheelItemAlign> Alignments (same as gravities. Uses WheelItemAlign instead of GravityFlags)  
- WheelItemAlign ItemAlign (shortcut for ItemAligns[0])  
- IList<WheelItemAlign> ItemAligns

Selection  
- ICommand SelectedItemIndexChangedCommand  
- EventHandler&lt;WheelChangedEventArgs&gt; SelectedItemIndexChanged  
- int SelectedItemIndex (shortcut for SelectedItemsIndex[0])  
- IList&lt;int&gt; SelectedItemsIndex

Templating  
- ItemsSimpleTemplates (currently reserved, used by the xamarin forms renderer)

`SelectedItemsIndex` is a list of integer. Each integer represents the selected index inside a wheel.  
`ItemWidths`: see chapter below  
`Alignments` or `Gravities` is used to align a wheel inside the available WheelPicker's width, if it is larger than the wheel's width.  
`ItemAligns` is used to align the items inside a wheel.

</details>

## Reference (Xamarin.iOS)

<details><summary>Click to expand</summary>

On iOS, this library uses the native UIPickerView with a custom UIPickerViewModel to greatly simplify the use of this control.

Sample usage:

```csharp
var picker = new UIPickerView {ShowSelectionIndicator = true, BackgroundColor = UIColor.White};
var pickerViewModel = new WheelPickerModel(picker);
picker.Model = pickerViewModel;

pickerViewModel.ItemsSource = new [] { "Monday", "Tuesday", "Wednesday" };
pickerViewModel.SelectedItemsIndex = new [] { 0 };
pickerViewModel.ItemAligns = new List<WheelItemAlign> { WheelItemAlign.Left };
```

**Vapolia.WheelPickerIos.WheelPickerModel**

Definition  
- object ItemsSource (either IReadOnlyCollection&lt;T&gt; or IReadOnlyCollection&lt;IReadOnlyCollection&lt;T&gt;&gt;)  
- IReadOnlyCollection&lt;T&gt; ItemsSourceSimple (shortcut for ItemsSourceMulti with one wheel)  
- IReadOnlyCollection&lt;IReadOnlyCollection&lt;T&gt;&gt; ItemsSourceMulti

Appearance  
- nfloat HorizontalSpaceBetweenWheels

Item appearance  
- string ItemWidths  
- UIFont ItemFont  
- UIColor ItemTextColor  
- IList<WheelItemAlign> Alignments  
- IList<WheelItemAlign> ItemAligns

Selection  
- ICommand SelectedItemIndexChangedCommand  
- int SelectedItemIndex  (shortcut for SelectedItemsIndex[0])  
- IEnumerable<int> SelectedItemsIndex

Templating  
- ItemsSimpleTemplates (currently reserved, used by the xamarin forms renderer)

`SelectedItemsIndex` is a list of integer. Each integer represents the selected index inside a wheel.  
`ItemWidths`: see chapter below  
`Alignments` is used to align a wheel inside the available WheelPicker's width, if it is larger than the wheel's width.  
`ItemAligns` is used to align the items inside a wheel.

</details>

## ItemWidths (Xamarin.Android, Xamarin.iOS; excluding Forms)

<details><summary>Click to expand</summary>

`ItemWidths` is used to choose the width of each wheel. It is a space separated string consisting of a combination of float numbers, stars (optionally prepended with a float number), or the "Auto" string.
The total WheelPicker width is distributed between the wheels by respecting either :

- float number: the exact width
- Auto: the width of the largest string in ItemsSource for a given wheel (if ItemsSource contains strings)
- star: the remaining space not assigned by the above rules, distributed among the other wheels using the optional float number as a weight

Examples of ItemWidths:

- `"*"`: one wheel having the full width of WheelPicker
- `"* *"`: two wheels, each of the same width, exactly half of the width of the Wheel Picker
- `"* * *"`: three wheels, each of the same width, exactly one third of the width of the Wheel Picker
- `"100 2* *"`: three wheels, first has a `100` device pixel width, second is twice the size of the third, and `3*-100=width` of the WheelPicker, which resolves to `*=WheelPickerWidth-100`
- `"* Auto *"`: three wheels, the middle wheel's width is computed from the largest string in its items source (if items source contains strings).

</details>

### Supported Platforms
- Android api level 15+ (Android 4.0.3+)  
- iOS 8+
- Xamarin Forms

### Mvvm friendly
The Weel Picker provides an event and a Command when the selection changes, making it easy to use with mvvm frameworks. It also implements INotifyPropertyChanged to notify change of its properties.

### Live Preview
The component supports live preview in the Xamarin Forms Previewer and in the Xamarin Android Designer (axml files). Xaml Hot reload is the prefered way though.
