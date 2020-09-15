using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;

namespace PrismSample
{
	/// <summary>MainWindowへ表示するサンプルViewのVM。</summary>
	public class ViewSampleViewModel : BindableBase
	{
		public DelegateCommand ExecuteAgent { get; }

		/// <summary>Agentを実行します。</summary>
		void onExecuteAgent()
		{
			using (var agent = this.container.Resolve<DataAgent>())
			{
				var person = agent?.GetPerson(1);
			}
		}

		/// <summary>データ読み書き用Agent。</summary>
		//private DataAgent agent = null;

		private IContainerProvider container = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="injectionContainer">インスタンス取得用DIコンテナ。（DIコンテナからインジェクションされる）</param>
		//public ViewSampleViewModel(DataAgent dataAgent)
		public ViewSampleViewModel(IContainerProvider injectionContainer)
		{
			this.container = injectionContainer;

			this.ExecuteAgent = new DelegateCommand(this.onExecuteAgent);
			//this.agent = dataAgent;
		}
	}
}
