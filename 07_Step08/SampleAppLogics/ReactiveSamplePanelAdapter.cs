using Prism.Ioc;

namespace PrismSample
{
	public class ReactiveSamplePanelAdapter : IReactiveSamplePanelAdapter
	{
		public IContainerProvider ContainerProvider { get; set; }

		public PersonSlim Person { get; private set; }

		public ReactiveSamplePanelAdapter(PersonSlim personSlim)
		{
			this.Person = personSlim;
		}
	}
}
