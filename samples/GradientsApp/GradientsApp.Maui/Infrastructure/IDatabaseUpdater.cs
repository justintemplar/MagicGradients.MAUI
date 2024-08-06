using GradientsApp.Maui.Repositories;

namespace GradientsApp.Maui.Infrastructure
{
    public interface IDatabaseUpdater
    {
        void RunUpdate(params ICanUpdateMyself[] repositories);
    }
}
