namespace SplitThePay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int noPersons = 1;
	

	public MainPage()
	{

		InitializeComponent();
	}

    private void txtBill_Completed(object sender, EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
    }



    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (sender is Button)
		{
			var btn = (Button)sender;
			var precentage = int.Parse(btn.Text.Replace("%",""));
			sldTip.Value = precentage;
		}
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
		if (noPersons > 1)
		{
			noPersons--;
		}

		lblNoPerson.Text = noPersons.ToString();
		CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        noPersons++;
		lblNoPerson.Text = noPersons.ToString();
		CalculateTotal();
    }


    private void CalculateTotal()
    {
		// Total of the tip
		var totalTip = (bill * tip) / 100;

		// tip by person
		var tipByPerson = (totalTip / noPersons);
		lblTipByPerson.Text = $"{Math.Round(tipByPerson,1)} DH"; 

		//subTotal
		var subTotal = (bill / noPersons);
		lblSubTotal.Text = $"{Math.Round(subTotal, 1)} DH";

        //Total 
        var totalByPerson = (bill + totalTip) / noPersons;
		lblTotal.Text = $"{Math.Round(totalByPerson, 1)} DH";

    }

}

