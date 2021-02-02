using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrismSample
{
	public interface IReactiveSamplePanelAdapter : IDisposable
	{
		public PersonSlim Person { get; }

        public ObservableCollection<PersonSlim> SearchResults { get; }

        public Task UpdatePersonAsync();

		public Task SavePersonAsync();

		public Task SearchCharacterAsync();
	}
}
