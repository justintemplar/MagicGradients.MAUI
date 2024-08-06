using MagicGradients.Maui.Skia.Builder;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MagicGradients.Maui.Skia;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseMagicGradientsSkia(this MauiAppBuilder builder)
    {
        GlobalSetup.Current.UseFactory(new XamlGradientFactory());
        GlobalSetup.Current.UseCssStyles<SkiaGradientView>();
        GlobalSetup.Current.UseCssStyles<SkiaGradientGLView>();

        builder.UseSkiaSharp();

        return builder;
    }
}
