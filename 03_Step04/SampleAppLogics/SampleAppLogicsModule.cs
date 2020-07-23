using Prism.Ioc;
using Prism.Modularity;

namespace PrismSample
{
	public class SampleAppLogicsModule : IModule
	{
		/// <summary>DataAccessモジュール</summary>
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		/// <summary>DIコンテナへ型を登録します。</summary>
		/// <param name="containerRegistry">型を登録するDIコンテナを表すIContainerRegistry。</param>
		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IDataAgent, DataAgent>();
			//containerRegistry.Register<IPersonRepository, PersonRepository>();
		}
	}
}