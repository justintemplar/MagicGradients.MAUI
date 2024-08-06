namespace MagicGradients.Maui.Animation;

public interface ITweener<TValue>
{
    TValue Tween(TValue from, TValue to, double progress);
}
