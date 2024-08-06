using MagicGradients.Masks;
using GradientStretch = MagicGradients.Masks.GradientStretch;

namespace MagicGradients.Maui.Masks
{
    public class MaskExtension
    {
        public ClipMode ClipMode { get; set; }
        public GradientStretch Stretch { get; set; }

        protected void FillValues(GradientMask mask)
        {
            mask.ClipMode = ClipMode;
            mask.Stretch = Stretch;
        }
    }
}
