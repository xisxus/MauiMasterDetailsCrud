namespace ProductApplication;

public partial class EditProductPage : ContentPage
{
    private Product _product;

    public EditProductPage(Product product)
    {
        InitializeComponent();
        _product = product;

        // Populate fields with product data
        ProductNameEntry.Text = _product.Name;
        ProductNumberEntry.Text = _product.ProductNumber;
        ColorEntry.Text = _product.Color;
        StandardCostEntry.Text = _product.StandardCost.ToString();
        ListPriceEntry.Text = _product.ListPrice.ToString();
        SizeEntry.Text = _product.Size.ToString();
        WeightEntry.Text = _product.Weight.ToString();
    }

    private async void OnUpdateProductClicked(object sender, EventArgs e)
    {
        // Update product details
        _product.Name = ProductNameEntry.Text;
        _product.ProductNumber = ProductNumberEntry.Text;
        _product.Color = ColorEntry.Text;
        _product.StandardCost = decimal.TryParse(StandardCostEntry.Text, out var standardCost) ? standardCost : 0;
        _product.ListPrice = decimal.TryParse(ListPriceEntry.Text, out var listPrice) ? listPrice : 0;
        _product.Size = int.TryParse(SizeEntry.Text, out var size) ? size : 0;
        _product.Weight = decimal.TryParse(WeightEntry.Text, out var weight) ? weight : 0;

        // Send message to update product in DetailPage
        MessagingCenter.Send(this, "UpdateProduct", _product);

        await Navigation.PopAsync();
    }

    private async void OnRemoveProductClicked(object sender, EventArgs e)
    {
        _product.Name = "";
        _product.ProductNumber = "";
        _product.Color = "";
        _product.StandardCost =  0;
        _product.ListPrice =  0;
        _product.Size =  0;
        _product.Weight = 0;
        _product.ProductCategoryID = 0;
        _product.ProductID = 0;

        MessagingCenter.Send(this, "RemoveProduct", _product);
        await Navigation.PopAsync();
    }
}