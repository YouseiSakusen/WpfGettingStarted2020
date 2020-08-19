using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
//using PrismSample.Blue;

namespace PrismSample.Red
{
	/// <summary>トマトViewのViewModel。</summary>
	public class TomatoViewModel : BindableBase, IDestructible
	{
		/// <summary>コンストラクタ。</summary>
		/// <param name="regMan">DIコンテナからインジェクションするIRegionManager。</param>
		public TomatoViewModel(IRegionManager regMan)
		{
			//regMan.RegisterViewWithRegion("BlueContent", typeof(DarkTurquoise));
		}

		/// <summary>このVMを破棄します。</summary>
		public void Destroy()
		{
			// Dispose処理を実装する
		}
	}
}
