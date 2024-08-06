namespace MagicGradients.Maui.Skia
{
    public static class GlobalSetupExtensions
    {
        public static GlobalSetup UseMagicGradientsSkia(this GlobalSetup setup)
        {
            // Init() as GlobalSetup extension
            return setup;
        }

        public static GlobalSetup UseCssStyles<TControl>(this GlobalSetup setup)
        {

            return setup;
        }
    }
}
