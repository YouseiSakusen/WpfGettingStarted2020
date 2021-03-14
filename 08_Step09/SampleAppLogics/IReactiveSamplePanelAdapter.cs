using Reactive.Bindings;
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

		public void UpdatePersonFromSearchResults(int index);

		public Task<int> GetCharacterIndex();

		public Task AddRandomCharacterAsync();

		public Task ClearAllCharactersAsync();

		public Task InsertRandomCharacterAsync(int index);

		public Task RemoveCharacterAsync(int index);

		public Task MoveCharacterAsync(int index, bool isUpperDirection);
	}
}
