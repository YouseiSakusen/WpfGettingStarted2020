using Prism.Ioc;

namespace PrismSample
{
	public interface IReactiveSamplePanelAdapter
	{
		public IContainerProvider ContainerProvider { get; set; }

		public PersonSlim Person { get; }
	}
}
