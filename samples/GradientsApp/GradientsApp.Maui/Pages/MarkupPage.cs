using MagicGradients;
using MagicGradients.Markup;
using MagicGradients.Masks;
using Microsoft.Maui.Graphics;
using GradientStop = MagicGradients.GradientStop;
using GradientView = MagicGradients.Maui.GradientView;
using GradientStretch = MagicGradients.Masks.GradientStretch;

namespace GradientsApp.Maui.Pages
{
    public class MarkupPage : ContentPage
    {
        private const int GHeight = 160;

        public MarkupPage()
        {
            Title = "Markup";
            Content = new ScrollView { Content = Body() };
        }

        private View Body() => new StackLayout { Children = 
        {
            new GradientView()
                .Height(GHeight)
                .Source(
                    new LinearGradient()
                        .Stops(Colors.Orange, Colors.Yellow)
                        .Rotate(45)),
            new GradientView()
                .Height(GHeight)
                .Source(
                    new RadialGradient()
                        .Circle().At(100, 100, OffsetType.Absolute)
                        .Size(200, 130)
                        .Repeat()
                        .Stops(
                            new GradientStop(Colors.Orange, Offset.Proportional(0)),
                            new GradientStop(Colors.Blue, Offset.Proportional(0.6)),
                            new GradientStop(Colors.Chocolate, Offset.Proportional(1)))),
            new GradientView()
                .Height(GHeight)
                .Source(b => b
                    .AddRadialGradient(o => o
                        .Ellipse().At(0.5, 0.5)
                        .AddStop(Colors.Pink, Offset.Proportional(0))
                        .AddStop(Colors.Red, Offset.Proportional(0.3))
                        .AddStop(Colors.Magenta, Offset.Proportional(1)))),
            new GradientView()
                .Height(GHeight)
                .Source("linear-gradient(43deg, #4158D0 0%, #C850C0 46%, #FFCC70 100%)")
                .GradientSize(GHeight, GHeight)
                .GradientRepeat(BackgroundRepeat.RepeatX),
            new GradientView()
                .Height(GHeight)
                .Source("linear-gradient(242deg, red, green, orange)")
                .Mask(
                    new PathMask("M 0 -100 L 58.8 90.9, -95.1 -30.9, 95.1 -30.9, -58.8 80.9 Z")
                        .Stretch(GradientStretch.AspectFit))
        }};
    }
}