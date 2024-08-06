using MagicGradients.Drawing;
using Microsoft.Maui.Graphics.Platform;

namespace MagicGradients
{
    public partial class SkiaGradientView : PlatformGraphicsView
    {
        public SkiaGradientView()
        {
            // TODO: set ViewWidth to Bounds.Width
            Drawable = new GradientDrawable(this);
        }

        partial void InvalidateNative()
        {
            InvalidateDrawable();
        }
    }
}
