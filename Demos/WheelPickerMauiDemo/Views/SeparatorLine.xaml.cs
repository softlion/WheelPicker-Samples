namespace WheelPickerMauiDemo.Views;

public partial class SeparatorLine : ContentPage
{
    public string[][] MetricWeightItems { get; } =
    [
        ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10"],
        //["AA", "BB", "CC", "DD", "EE", "FF", "GG"]
    ];

    public SeparatorLine()
    {
        InitializeComponent();
        BindingContext = this;
    }
}