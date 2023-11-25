using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WpfPractices.Views;

namespace WpfPractices
{
    class MainModule : IModule
    {
        private readonly IRegionManager regionManager;

        public MainModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            regionManager.RegisterViewWithRegion<MainView>("MainRegion");
        }
    }
}
