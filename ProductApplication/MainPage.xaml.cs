namespace ProductApplication
{
    public partial class MainPage : ContentPage
    {

        private readonly ProductService _productService;
        public List<ProductCategory> ProductCategories { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _productService = new ProductService();
            LoadCategories();
        }

        private async void LoadCategories()
        {
            ProductCategories = await _productService.GetProductCategoriesAsync();
            CategoryListView.ItemsSource = ProductCategories;
        }

        private async void OnCategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as ProductCategory;
            if (selectedCategory != null)
            {
                await Navigation.PushAsync(new DetailPage(selectedCategory));
            }
        }

        private async void OnAddCategoryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage(null));
        }


    }

}
