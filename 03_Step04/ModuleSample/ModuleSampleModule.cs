using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace PrismSample
{
	public class ModuleSampleModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var modules = containerProvider.Resolve<IModuleCatalog>();

			modules.AddModule<SampleAppLogicsModule>();
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<ViewSample, ViewSampleViewModel>();
		}
	}
}