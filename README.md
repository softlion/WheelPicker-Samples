|               Maui and Native iOS + Android on net8/9               |
|:------------------------------------------------------------------------------------------------:|
| [![NuGet][nuget-img]][nuget-link]  ![Nuget](https://img.shields.io/nuget/dt/Vapolia.WheelPicker) |
|                                    [![][demo-img]][demo-link]                                    |


# Wheel Picker
Definition by Apple 🍏 :  
A **Wheel Picker** is a **view** that uses a **spinning-wheel** or slot-machine **metaphor** to **display** one or more **sets of values**.

This interactive UI control mimics a slot machine user interface:
- Modern replacement for drop downs and lists
- Gesture based selection
- Cascading selection (multi wheel dependency)
- Dynamic Content Loading
- Accessibility Enhancements

Use Cases:  
- Date and time selection
- Country Code Selection
- E-Commerce Product Customization: Car Brand & Model Selection ...
- Medical Appointment Scheduling
- Food Recipe Ingredient Selector
- Survey & Poll Answer Selection
- Stock Trading App Price Asset Selector
- Travel App Destination Picker
- Elderly-Friendly UI for Large Number Selection


Enterprise support available: contact [Vapolia](https://vapolia.eu)

## UI controls
* `WheelPicker` for Maui net8/9 / Android+iOS: supports hot reload & trimming
* `vapolia.WheelPicker` for native android on net8/9: supports code and native layout .xml files
* `UIPickerViewModel` for native iOS on net8/9: supports code and storyboard files

## Presentations

| Features  | Design Sample  |
|-----------|---------------|
| [![Preview][video-img]][video-link] <br> *Click to watch the video* | [![Preview][video-img2]][video-link2] <br> *Click to watch the video* |

[video-img]: https://github.com/user-attachments/assets/6a8a3f8d-ccde-4f34-9ede-4a04846ae6ca
[video-link]: https://vimeo.com/244170732
[nuget-img]: https://img.shields.io/nuget/v/Vapolia.WheelPicker
[nuget-link]: https://www.nuget.org/packages/Vapolia.WheelPicker/
[nuget-link-forms]: https://www.nuget.org/packages/Vapolia.WheelPicker.Forms/
[demo-img]: https://img.shields.io/badge/demo-source%20code-lightgrey.svg
[demo-link]: https://github.com/softlion/WheelPicker-Samples/tree/main/Demos
[video-img2]: https://i.imgur.com/BKTYa8G.png
[video-link2]: https://vimeo.com/488497139


## Quick start

`dotnet add package Vapolia.WheelPicker`

#### MAUI Specific

If using Maui, register the control in the `CreateMauiApp()` function:
```cs
...
using Vapolia.WheelPickers;

...
builder
    .UseMauiApp<App>()
    .UseWheelPicker();
```


#### Add a WheelPicker to your xaml UI

- Add `xmlns:wp="https://vapolia.eu/WheelPicker"` to the root tag
- Add a minimal wheel:

```xml
<wp:WheelPicker ItemsSourceSimple="{Binding MyListProperty}">
    <wp:WheelDefinition Width="Auto" HorizontalOptions="Left" Alignment="Center" />
</wp:WheelPicker>
```

## Anatomy of the control

The WheelPicker is made of 2 parts: 
- the container `<wp:WheelPicker> ... </wp:WheelPicker>` which contains 1 or more wheels and present them like a Horizontal StackLayout does.
- a list of 1 or more `wp:WheelDefinition`, each representing a vertical interactive wheel.  
Tip: `wp:WheelDefinition` supports a customizable template for displaying each item in the wheel.

The WheelPicker is bound to a single data source through `ItemsSource="{Binding SomeProperty}"`.  
The type of `SomeProperty` can be:
- For 1 wheel: 
  - a list of items `IReadOnlyCollection<T>`. Ex: `List<string>`


- For more than 1 wheel: 
  - a list of list of items `IReadOnlyCollection<IReadOnlyCollection<T>>`. Ex: `List<List<MyItemModel>>` 
  - Each inner list is bound to a wheel.  
    The outer list must have a number of items equal to the number of `wp:WheelDefinition`.

## Full example

```xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
                xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                xmlns:wp="clr-namespace:Vapolia.WheelPickers;assembly=Vapolia.WheelPicker"
                x:Class="WheelPickerDemo.Forms.MainPage">
    <VerticalStackLayout>

        <wp:WheelPicker HorizontalOptions="Fill" SelectedItemsIndex="0"
                        ItemsSource="{Binding Days}" 
                        Command="{Binding ItemSelectedCommand}">
            <wp:WheelDefinition Width="Auto" HorizontalOptions="Left" Alignment="Center" />
        </wp:WheelPicker>

    </VerticalStackLayout>
</ContentPage>
```

In the code behind, set the binding context to your view model containing the items to display.  
For the example below `ItemsSource` is bound to a list of strings.


```cs
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
    public List<string> Days { get; } = new () { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    public Command ItemSelectedCommand { get; }

    public MainPageModel() 
    {
        //Component is the index of the wheel triggering the command. 
        //Row is the index of the currently displayed item at the center of the wheel for this Component.
        //ItemIndexes are the current indexes of all wheels of the WheelPicker control
        ItemSelectedCommand = new Command<(int Component, int Row, IList<int> ItemIndexes)>(tuple =>
        {
            var selectedValue = Days[tuple.Row];
            //...
        });
    }
}
```

## Using custom templates

You can customize how each item is rendered by using custom templates.    
By default, the control converts all items to strings and renders those strings with the specified style.

You can fully customize the style and content of the items. However, there is a constraint: there is only one template per wheel, which renders all items of that wheel. 
If you have multiple wheels in the same WheelPicker, you can set one template per wheel.

For example, below is a templated picker with 3 wheels. All properties are bindable and can be dynamically changed.

Note that `SelectedItemsIndex` initializes the position of the three wheels to the specified item indexes.

```xml
<wp:WheelPicker x:Name="SlotPicker" ItemsSource="{Binding Slot.ItemsSource}" 
                SelectedItemsIndex="1 10 7"
                Command="{Binding Slot.ItemSelectedCommand}" 
                ItemTextSelectedColor="Lime"
                ItemTextFont="Italic"
                HorizontalOptions="Fill"
                SelectionLinesColor="Aquamarine">
    <wp:WheelDefinition Width="*" HorizontalOptions="Left" Alignment="Center" IsCircular="True">
        <DataTemplate>
            <Label Text="{Binding .}" TextColor="Black" FontSize="30" />
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

## Examples

Those examples are extracted from the demo projects in this repository.

A simple picker with one wheel:

```xml
<wp:WheelPicker ItemsSource="{Binding DayPicker.ItemsSource}">
    <wp:WheelDefinition Width="Auto" HorizontalOptions="Left" Alignment="Center" />
</wp:WheelPicker>
```

A templated picker with one wheel:

```xml
<wp:WheelPicker ItemsSource="{Binding DayPicker.ItemsSource}">
    <wp:WheelDefinition Width="*" HorizontalOptions="Left" Alignment="Center" IsCircular="True" RowHeight="48">
        <DataTemplate>
            <Image Source="{Binding .}" HeightRequest="48" Aspect="AspectFill" />
        </DataTemplate>
    </wp:WheelDefinition>
</wp:WheelPicker>
```

A picker with 3 wheels:  
The width of the center wheel is computed automatically, and items are aligned differently inside each wheel.

```xml
<wp:WheelPicker SelectionLinesColor="Navy" 
                HorizontalSpaceBetweenWheels="40" 
                ItemsSource="{Binding DatePicker.ItemsSource}"  
                SelectedItemsIndex="0,0,0" 
                Command="{Binding DatePicker.ItemSelectedCommand}"
                HorizontalOptions="Fill">
    <wp:WheelDefinition Width="*" HorizontalOptions="Right" />
    <wp:WheelDefinition Width="Auto" HorizontalOptions="Left"  />
    <wp:WheelDefinition Width="*" HorizontalOptions="Left"  />
</wp:WheelPicker>
```

A templated picker with 3 wheels:  
All properties are bindable and can be dynamically changed.

```xml
<wp:WheelPicker x:Name="SlotPicker" ItemsSource="{Binding Slot.ItemsSource}" 
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


## Reference (Maui & Xamarin Forms)
<details><summary>Click to expand</summary>

**WheelPicker**

Definition  
- `IList<WheelDefinition>` **`WheelDefinitions`** Default Content
- `object` **`ItemsSource`** Accepts both `IReadOnlyCollection<T>` and `IReadOnlyCollection<IReadOnlyCollection<T>>` 

Appearance  
- `double` **`HorizontalSpaceBetweenWheels`**
- `Color` **`SelectionLinesColor`**

Item appearance (used by the default item template, when no custom item template is specified)  
- `Font` **`ItemTextFont`**
- `Color` **`ItemTextColor`**
- `Color` **`ItemTextSelectedColor`**

Selection  
- `IList<int>` **`SelectedItemsIndex`** One index per wheel.
- `ICommand` **`Command`** Triggered when any of the wheel's index has changed
- `EventHandler<WheelChangedEventArgs>` **`SelectedItemIndexChanged`** Triggered when any of the wheel's index has changed
- `void` **`Spin`**`(int items, int wheelIndex = 0)` items: the number of item to spin

`SelectedItemsIndex` is a list of integers, where each integer represents the selected index within a wheel. In XAML, you can use a space- or comma-separated string of integers.

**WheelDefinition**

- `GridLength` **`Width`**
- `WheelItemAlign` **`HorizontalOptions`**
- `WheelItemAlign` **`Alignment`**
- `bool` **`IsCircular`**
- `DataTemplate` **`ImageItemTemplate`**
- `double` **`RowHeight`**

When a wheel's `Width` is set to `Auto`, the control computes the max width of all strings in the data source (if object are strings).  When set to `*` (star), the width of the wheel will be proportional to the remaining space. See the `Grid` control for more information about `GridLength`.

`HorizontalOptions` is used to align a wheel inside the available width of the WheelPicker, if it is larger than the width of the wheel.

`Alignment` is used to align the items within a wheel.
</details>

## Reference (net8-android & Xamarin.Android)
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
- ItemsSimpleTemplates (currently reserved, used by the renderer)

`SelectedItemsIndex` is a list of integers. Each integer represents the selected index within a wheel.  
`ItemWidths`: see chapter below  
`Alignments` or `Gravities` is used to align a wheel inside the available WheelPicker's width, if it is larger than the width of the wheel.  
`ItemAligns` is used to align the items within a wheel.

</details>

## Reference (net8-ios & Xamarin.iOS)

<details><summary>Click to expand</summary>

On iOS, this library utilizes the native UIPickerView along with a custom UIPickerViewModel to significantly simplify the use of this control.

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
- ItemsSimpleTemplates (currently reserved, used by the renderer)

`SelectedItemsIndex` is a list of integer. Each integer represents the selected index inside a wheel.  
`ItemWidths`: see chapter below  
`Alignments` is used to align a wheel inside the available WheelPicker's width, if it is larger than the wheel's width.  
`ItemAligns` is used to align the items inside a wheel.

</details>

## ItemWidths (net8-android and net8-ios only, excluding Maui & Xamarn Forms)

<details><summary>Click to expand</summary>

`ItemWidths` is used to choose the width of each wheel. It is a space separated string consisting of a combination of float numbers, stars (optionally prepended with a float number), or the "Auto" string.
The total width of the WheelPicker is distributed between the wheels by respecting either :

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
- Maui, net-iOS, net-Android, Xamarin Forms
- Android api level 15+ (Android 4.0.3+)  
- iOS 8+

### Mvvm friendly
The Wheel Picker provides an event and a Command when the selection changes, making it easy to use with or without mvvm frameworks.    
It also implements `INotifyPropertyChanged`.

### Live Preview
This control supports hot reload and live preview.


### Enterprise Support

[Enterprise support is available: contact sales](https://vapolia.eu)  
[Source code is available: contact sales](https://vapolia.eu)
