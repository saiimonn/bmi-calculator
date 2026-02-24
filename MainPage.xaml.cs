namespace BmiCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculateClicked(object? sender, EventArgs e)
    {
        if (!double.TryParse(HeightEntry.Text, out double heightCm) || heightCm <= 0)
        {
            DisplayAlert("Invalid Input", "Please enter a valid height in centimeters.", "OK");
            return;
        }

        if (!double.TryParse(WeightEntry.Text, out double weightKg) || weightKg <= 0)
        {
            DisplayAlert("Invalid Input", "Please enter a valid weight in kilograms.", "OK");
            return;
        }

        double heightM = heightCm / 100.0;
        double bmi = weightKg / (heightM * heightM);

        string category;
        Color categoryColor;

        if (bmi < 18.5)
        {
            category = "Underweight";
            categoryColor = Color.FromArgb("#3B82F6"); // blue
        }
        else if (bmi < 25.0)
        {
            category = "Normal Weight";
            categoryColor = Color.FromArgb("#22C55E"); // green
        }
        else if (bmi < 30.0)
        {
            category = "Overweight";
            categoryColor = Color.FromArgb("#F97316"); // orange
        }
        else
        {
            category = "Obese";
            categoryColor = Color.FromArgb("#EF4444"); // red
        }

        BmiValueLabel.Text = bmi.ToString("F1");
        BmiValueLabel.TextColor = categoryColor;
        BmiCategoryLabel.Text = category;
        BmiCategoryLabel.TextColor = categoryColor;

        ResultCard.IsVisible = true;
    }
}