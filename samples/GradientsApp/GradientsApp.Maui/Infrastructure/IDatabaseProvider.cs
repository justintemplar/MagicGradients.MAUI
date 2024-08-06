using LiteDB;

namespace GradientsApp.Maui.Infrastructure
{
    public interface IDatabaseProvider
    {
        LiteDatabase CreateDatabase();
    }
}
