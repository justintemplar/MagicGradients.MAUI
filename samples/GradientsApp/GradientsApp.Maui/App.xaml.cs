using GradientsApp.Maui.Infrastructure;
using GradientsApp.Maui.Repositories;

namespace GradientsApp.Maui
{
    public partial class App : Application
    {
        private readonly IDatabaseUpdater _databaseUpdater;
        private readonly IGradientRepository _gradientRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDocumentRepository _documentRepository;

        public App(
            IDocumentRepository documentRepository,
            IGradientRepository gradientRepository,
            ICategoryRepository categoryRepository,
            IDatabaseUpdater databaseUpdater)
        {
            InitializeComponent();

            _documentRepository = documentRepository;
            _gradientRepository = gradientRepository;
            _categoryRepository = categoryRepository;
            _databaseUpdater = databaseUpdater;

            _documentRepository.SetupMapper();
            _databaseUpdater.RunUpdate(_gradientRepository, _categoryRepository);

            MainPage = new AppShell();
        }
    }
}
