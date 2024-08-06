using System.Collections.Generic;

namespace GradientsApp.Maui.Repositories
{
    public interface IDocumentRepository
    {
        void SetupMapper();
        Task<T> GetDocument<T>(string fullPath);
        Task<IEnumerable<T>> GetDocumentCollection<T>(string nameSpace, params string[] files);
    }
}
