namespace BillSplittingApp;

public partial class MainPage : ContentPage
{
    double bill;
    int tip;
    int numberOfPeople = 1;

    public MainPage()
    {
        InitializeComponent();
    }

    private void TxtBill_Completed(object sender, EventArgs e)
    {
        bill = double.Parse(TxtBill.Text);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        double totalTip = (bill * tip) / 100;

        double tipPerPerson = totalTip / numberOfPeople;
        lblTipPerPerson.Text = $"{tipPerPerson:C}";

        double subTotal = bill / numberOfPeople;
        lblSubtotal.Text = $"{subTotal:C}";

        double totalPerPerson = (bill + totalTip) / numberOfPeople;
        lblTotal.Text = $"{totalPerPerson:C}";
    }

    private void slider_gorjeta_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)slider_gorjeta.Value;
        percentual_gorjeta.Text = $"Gorjeta: {tip}%";
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            Button btn = (Button)sender;
            int percentage = int.Parse(btn.Text.Replace("%", ""));
            slider_gorjeta.Value = percentage;
        }
    }

    private void BtnMinus_Clicked(object sender, EventArgs e)
    {
        if (numberOfPeople > 1)
            numberOfPeople--;

        lblNumPeople.Text = numberOfPeople.ToString();
        CalculateTotal();
    }

    private void BtnMore_Clicked(object sender, EventArgs e)
    {
        numberOfPeople++;
        lblNumPeople.Text = numberOfPeople.ToString();
        CalculateTotal();
    }

    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        bill = 0.0;
        tip = 0;
        TxtBill.Text = "";
        slider_gorjeta.Value = 0;
        lblNumPeople.Text = "1";
        numberOfPeople = 1;
        CalculateTotal();
    }
}
