using GradientsApp.Maui.Pages;

namespace GradientsApp.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;

            Routing.RegisterRoute("AnimationsPage", typeof(Pages.AnimationsPage));
            Routing.RegisterRoute("CategoriesPage", typeof(Pages.CategoriesPage));
            Routing.RegisterRoute("GalleryPage", typeof(Pages.GalleryPage));
            Routing.RegisterRoute("GradientPage", typeof(Pages.GradientPage));
            Routing.RegisterRoute("LinearPage", typeof(Pages.LinearPage));
            Routing.RegisterRoute("MasksPage", typeof(Pages.MasksPage));
            Routing.RegisterRoute("RadialPage", typeof(Pages.RadialPage));

            Routing.RegisterRoute("LinearRepeatPage", typeof(Pages.LinearRepeatPage));            

            Routing.RegisterRoute("MarkupPage", typeof(Pages.MarkupPage));
        }
    }
}
