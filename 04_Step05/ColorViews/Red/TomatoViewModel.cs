using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Blue;

namespace PrismSample.Red
{
	/// <summary>トマトViewのViewModel。</summary>
	public class TomatoViewModel : BindableBase
	{
		/// <summary>コンストラクタ。</summary>
		/// <param name="regMan">DIコンテナからインジェクションするIRegionManager。</param>
		public TomatoViewModel(IRegionManager regMan)
			=> regMan.RegisterViewWithRegion("BlueContent", typeof(DarkTurquoise));
	}
}
