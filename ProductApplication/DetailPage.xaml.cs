using System.Collections.ObjectModel;

namespace ProductApplication;

public partial class DetailPage : ContentPage
{
    private readonly ProductService _productService;
    public ProductCategory SelectedCategory { get; set; }

    public DetailPage(ProductCategory category)
    {
        InitializeComponent();
        _productService = new ProductService();
        SelectedCategory = category ?? new ProductCategory { Products = new ObservableCollection<Product>() };
        CategoryNameEntry.Text = SelectedCategory.Name;
        ProductsListView.ItemsSource = SelectedCategory.Products;

        // Subscribe to messages for adding and updating products
        MessagingCenter.Subscribe<AddProductPage, Product>(this, "AddProduct", (sender, product) =>
        {
            SelectedCategory.Products.Add(product);
        });

        MessagingCenter.Subscribe<EditProductPage, Product>(this, "UpdateProduct", (sender, product) =>
        {
            var existingProduct = SelectedCategory.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                // Update existing product details
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.Color = product.Color;
                existingProduct.StandardCost = product.StandardCost;
                existingProduct.ListPrice = product.ListPrice;
                existingProduct.Size = product.Size;
                existingProduct.Weight = product.Weight;
            }
        });
    }

    private async void OnSaveCategoryClicked(object sender, EventArgs e)
    {
        SelectedCategory.Name = CategoryNameEntry.Text;

        if (SelectedCategory.ProductCategoryID > 0)
        {
            SelectedCategory.Products = new ObservableCollection<Product>(SelectedCategory.Products.Where(p => p.Size !=0));
            await _productService.UpdateProductCategoryAsync(SelectedCategory.ProductCategoryID, SelectedCategory);
        }
        else
        {
            await _productService.AddProductCategoryAsync(SelectedCategory);
        }

        await Navigation.PushAsync(new MainPage());
    }

    private async void OnDeleteCategoryClicked(object sender, EventArgs e)
    {
        if (SelectedCategory.ProductCategoryID > 0)
        {
            await _productService.DeleteProductCategoryAsync(SelectedCategory.ProductCategoryID);
        }

        await Navigation.PushAsync(new MainPage());
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProductPage());
    }

    private async void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedProduct = e.SelectedItem as Product;
        if (selectedProduct != null)
        {
            await Navigation.PushAsync(new EditProductPage(selectedProduct));
        }
    }

    private void OnCategoryNameEntryCompleted(object sender, EventArgs e)
    {
        SelectedCategory.Name = CategoryNameEntry.Text;
    }
}