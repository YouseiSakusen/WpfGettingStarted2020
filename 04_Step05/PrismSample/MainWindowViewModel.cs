using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Blue;
using PrismSample.Green;
using PrismSample.Red;

namespace PrismSample
{
	/// <summary>MainWindowのViewModel。</summary>
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		/// <summary>コンストラクタ</summary>
		/// <param name="regMan">インジェクションするIRegionManager。</param>
		public MainWindowViewModel(IRegionManager regMan)
		{
			regMan.RegisterViewWithRegion("ContentRegion", typeof(Tomato));
			//regMan.RegisterViewWithRegion("RedContent", typeof(Tomato));
			//regMan.RegisterViewWithRegion("BlueContent", typeof(DarkTurquoise));
			//regMan.RegisterViewWithRegion("GreenContent", typeof(MediumSeaGreen));
		}
	}
}
