using CommunityToolkit.Maui;
using GradientsApp.Maui.ViewModels;
using MagicGradients.Maui;
//using MagicGradients.Maui.Skia;
using Microsoft.Extensions.Logging;
using GradientsApp.Maui.Infrastructure;
using GradientsApp.Maui.Repositories;
using GradientsApp.Maui.Pages;

namespace GradientsApp.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMagicGradients()
                //.UseMagicGradientsSkia()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // View Models

            builder.Services.AddSingleton<IDatabaseProvider, DatabaseProvider>();
            builder.Services.AddSingleton<IDatabaseUpdater, DatabaseUpdater>();
            builder.Services.AddSingleton<IDocumentRepository, DocumentRepository>();
            builder.Services.AddSingleton<IGradientRepository, GradientRepository>();
            builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<LinearViewModel>();
            builder.Services.AddTransient<CategoriesViewModel>();
            builder.Services.AddTransient<GalleryViewModel>();
            builder.Services.AddTransient<GradientViewModel>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AnimationsPage>();
            builder.Services.AddTransient<CategoriesPage>();
            builder.Services.AddTransient<GalleryPage>();
            builder.Services.AddTransient<GradientPage>();
            builder.Services.AddTransient<LinearPage>();
            builder.Services.AddTransient<MarkupPage>();
            builder.Services.AddTransient<MasksPage>();
            builder.Services.AddTransient<RadialPage>();

            builder.Services.AddTransient<LinearRepeatPage>();

            return builder.Build();
        }
    }
}
