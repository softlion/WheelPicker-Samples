namespace WheelPickerMauiDemo.Views;

public partial class SeparatorLine : ContentPage
{
    public string[][] MetricWeightItems { get; } =
    [
        ["1", "2", "3", "4", "5", "6", "7", "8", "9"],
        ["a", "b", "c", "d", "e", "f", "g", "h"]
    ];

    public SeparatorLine()
    {
        InitializeComponent();
        BindingContext = this;
    }
}