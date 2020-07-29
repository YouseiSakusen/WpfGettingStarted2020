using System.Diagnostics;
using Prism.Ioc;
using Prism.Modularity;

namespace PrismSample
{
	public class ModuleSampleModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			Debug.WriteLine("ViewSample RegisterTypes");
			containerRegistry.RegisterForNavigation<ViewSample, ViewSampleViewModel>();
		}
	}
}