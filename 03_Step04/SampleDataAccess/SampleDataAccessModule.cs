using Prism.Ioc;
using Prism.Modularity;

namespace PrismSample
{
	/// <summary>DataAccessモジュール</summary>
	public class SampleDataAccessModule : IModule
	{
		/// <summary>モジュールを初期化します。</summary>
		/// <param name="containerProvider">インスタンスを取り出すDIコンテナを表すIContainerProvider。</param>
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		/// <summary>DIコンテナへ型を登録します。</summary>
		/// <param name="containerRegistry">型を登録するDIコンテナを表すIContainerRegistry。</param>
		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IPersonRepository, PersonRepository>();
			//containerRegistry.RegisterInstance<IPersonRepository>(new PersonRepository());
			//containerRegistry.RegisterSingleton<IPersonRepository, PersonRepository>();
		}
	}
}