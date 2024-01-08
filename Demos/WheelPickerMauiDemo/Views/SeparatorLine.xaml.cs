namespace WheelPickerMauiDemo.Views;

public partial class SeparatorLine : ContentPage
{
    public List<IList<object>> MetricWeightItems { get; } = new()
    {
        new List<object> { "1", "2", "3", "4", "5", "6", "7", "8", "9" },
        new List<object> { "a", "b", "c", "d", "e", "f", "g", "h" },
    };

    public SeparatorLine()
    {
        InitializeComponent();
        BindingContext = this;
    }
}