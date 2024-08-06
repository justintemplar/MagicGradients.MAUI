using MagicGradients.Masks;
using GradientStretch = MagicGradients.Masks.GradientStretch;

namespace MagicGradients.Maui.Masks;

public class GradientMask : GradientElement, IGradientMask
{
    public static readonly BindableProperty ClipModeProperty = BindableProperty.Create(nameof(ClipMode),
        typeof(ClipMode), typeof(GradientMask), ClipMode.Include);

    public static readonly BindableProperty StretchProperty = BindableProperty.Create(nameof(Stretch),
        typeof(GradientStretch), typeof(GradientMask), GradientStretch.None);

    public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(nameof(IsActive),
        typeof(bool), typeof(GradientMask), true);

    public ClipMode ClipMode
    {
        get => (ClipMode)GetValue(ClipModeProperty);
        set => SetValue(ClipModeProperty, value);
    }

    public GradientStretch Stretch
    {
        get => (GradientStretch)GetValue(StretchProperty);
        set => SetValue(StretchProperty, value);
    }

    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }
}
