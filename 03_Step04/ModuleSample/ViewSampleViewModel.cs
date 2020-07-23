using Prism.Mvvm;

namespace PrismSample
{
	public class ViewSampleViewModel : BindableBase
	{
		private DataAgent agent = null;

		public ViewSampleViewModel(DataAgent dataAgent)
		{
			this.agent = dataAgent;
		}
	}
}
