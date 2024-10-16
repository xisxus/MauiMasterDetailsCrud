namespace ProductApplication;

public partial class AddProductPage : ContentPage
{
    public AddProductPage()
    {
        InitializeComponent();
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        var newProduct = new Product
        {
            Name = ProductNameEntry.Text,
            ProductNumber = ProductNumberEntry.Text,
            Color = ColorEntry.Text,
            StandardCost = decimal.TryParse(StandardCostEntry.Text, out var standardCost) ? standardCost : 0,
            ListPrice = decimal.TryParse(ListPriceEntry.Text, out var listPrice) ? listPrice : 0,
            Size = int.TryParse(SizeEntry.Text, out var size) ? size : 0,
            Weight = decimal.TryParse(WeightEntry.Text, out var weight) ? weight : 0
        };

        // Return the new product to the DetailPage
        await Navigation.PopAsync();
        MessagingCenter.Send(this, "AddProduct", newProduct);
    }
}