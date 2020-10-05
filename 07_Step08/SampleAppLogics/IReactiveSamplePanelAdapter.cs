using System;
using System.Threading.Tasks;

namespace PrismSample
{
	public interface IReactiveSamplePanelAdapter : IDisposable
	{
		public PersonSlim Person { get; }

		public Task UpdatePersonAsync();

		public Task SavePersonAsync();
	}
}
