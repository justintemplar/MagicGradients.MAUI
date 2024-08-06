using Microsoft.Maui.Storage;
using GradientsApp.Maui.Models;
using GradientsApp.Maui.Repositories;

namespace GradientsApp.Maui.Infrastructure
{
    public class DatabaseUpdater : IDatabaseUpdater
    {
        private readonly IDatabaseProvider _databaseProvider;
        private readonly IDocumentRepository _documentRepository;

        public DateTime LastUpdate
        {
            get => Preferences.Get(nameof(LastUpdate), DateTime.MinValue);
            set => Preferences.Set(nameof(LastUpdate), value);
        }

        public DatabaseUpdater(
            IDatabaseProvider databaseProvider, 
            IDocumentRepository documentRepository)
        {
            _databaseProvider = databaseProvider;
            _documentRepository = documentRepository;
        }

        public async void RunUpdate(params ICanUpdateMyself[] repositories)
        {
            var metadata = await _documentRepository.GetDocument<Metadata>("Metadata.json");

            using (var db = _databaseProvider.CreateDatabase())
            {
                if (LastUpdate >= metadata.Date)
                    return;

                foreach (var repository in repositories)
                {
                    repository.UpdateDatabase(db, metadata, _documentRepository);
                }

                LastUpdate = metadata.Date;
            }
        }
    }
}
