using LiteDB;
using GradientsApp.Maui.Models;

namespace GradientsApp.Maui.Repositories
{
    public interface ICanUpdateMyself
    {
        void UpdateDatabase(LiteDatabase db, Metadata metadata, IDocumentRepository documentRepository);
    }
}
