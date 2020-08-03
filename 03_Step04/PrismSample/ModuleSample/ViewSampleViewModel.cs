using System.Windows;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;

namespace PrismSample
{
	/// <summary>MainWindowへ表示するサンプルViewのVM。</summary>
	public class ViewSampleViewModel : BindableBase
	{
		public DelegateCommand ExecuteAgent { get; }

		void onExecuteAgent()
		{
			using (var agent = (Application.Current as PrismApplication).Container.Resolve<DataAgent>())
			{
				var person = agent?.GetPerson(1);
			}
		}

		/// <summary>データ読み書き用Agent。</summary>
		//private DataAgent agent = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="dataAgent">データ読み書き用Agent。（DIコンテナからインジェクションされる）</param>
		//public ViewSampleViewModel(DataAgent dataAgent)
		public ViewSampleViewModel()
		{
			this.ExecuteAgent = new DelegateCommand(this.onExecuteAgent);

			//this.agent = dataAgent;
		}
	}
}
