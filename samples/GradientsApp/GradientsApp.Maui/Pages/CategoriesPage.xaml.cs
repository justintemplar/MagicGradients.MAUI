using GradientsApp.Maui.ViewModels;

namespace GradientsApp.Maui.Pages
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel _viewModel;

        public CategoriesPage(CategoriesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.OnDisappearing();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            _viewModel.OnNavigatedTo();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesList.SelectedItem != null)
            {
                CategoriesList.SelectedItem = null;
            }
        }
    }
}