using Prism.Commands;
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

		public DelegateCommand ShowViewButtonClick { get; }

		void onShowViewButtonClick()
		{
			this.regionManager.RequestNavigate("ContentRegion", "ViewSample");
		}

		private IRegionManager regionManager = null;

		public MainWindowViewModel(IRegionManager regMan)
		{
			this.regionManager = regMan;

			this.ShowViewButtonClick = new DelegateCommand(this.onShowViewButtonClick);
		}
	}
}
