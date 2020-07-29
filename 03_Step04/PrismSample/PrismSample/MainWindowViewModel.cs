using Prism.Mvvm;
using Prism.Regions;

namespace PrismSample
{
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainWindowViewModel(IRegionManager regMan)
		{
			regMan.RegisterViewWithRegion("ContentRegion", typeof(ViewSample));
		}
	}
}
