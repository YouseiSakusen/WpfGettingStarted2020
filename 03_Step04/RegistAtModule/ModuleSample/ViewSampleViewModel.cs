using Prism.Mvvm;

namespace PrismSample
{
	/// <summary>MainWindowへ表示するサンプルViewのVM。</summary>
	public class ViewSampleViewModel : BindableBase
	{
		/// <summary>データ読み書き用Agent。</summary>
		private DataAgent agent = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="dataAgent">データ読み書き用Agent。（DIコンテナからインジェクションされる）</param>
		public ViewSampleViewModel(DataAgent dataAgent)
		{
			this.agent = dataAgent;
		}
	}
}
