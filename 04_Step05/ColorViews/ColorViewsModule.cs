using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismSample.Green;
using PrismSample.Red;

namespace PrismSample
{
	public class ColorViewsModule : IModule
	{
		/// <summary>Moduleを初期化します。</summary>
		/// <param name="containerProvider">取得用のDIコンテナインタフェースを表すIContainerProvider。</param>
		public void OnInitialized(IContainerProvider containerProvider)
		{
			//var regionManager = containerProvider.Resolve<IRegionManager>();

			//regionManager?.RegisterViewWithRegion("ContentRegion", typeof(Tomato));
		}

		/// <summary>DIコンテナへ型を登録します。</summary>
		/// <param name="containerRegistry">登録専用のDIコンテナを表すIContainerRegistry。</param>
		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			//containerRegistry.RegisterForNavigation<Tomato, TomatoViewModel>();

			containerRegistry.RegisterForNavigation<MediumSeaGreen, MediumSeaGreenViewModel>();
		}
	}
}