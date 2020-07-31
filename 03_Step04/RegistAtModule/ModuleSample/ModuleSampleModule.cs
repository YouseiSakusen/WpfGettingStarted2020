using System.Diagnostics;
using Prism.Ioc;
using Prism.Modularity;

namespace PrismSample
{
	/// <summary>Prism Moduleのサンプル。</summary>
	public class ModuleSampleModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider) { }

		/// <summary>DIコンテナへ型を登録します。</summary>
		/// <param name="containerRegistry">型を登録するDIコンテナを表すIContainerRegistry。</param>
		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			Debug.WriteLine("ViewSample RegisterTypes");
			containerRegistry.RegisterForNavigation<ViewSample, ViewSampleViewModel>();
		}
	}
}