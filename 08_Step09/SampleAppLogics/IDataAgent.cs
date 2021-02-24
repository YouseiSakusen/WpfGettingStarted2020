using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrismSample
{
	public interface IDataAgent : IDisposable
	{
		public Person GetPerson(int id);

		public void UpdatePerson(int id, Person person);

		public Task UpdatePersonSlimAsync(int? id, PersonSlim person);

		public void SavePerson(Person person);

		public Task SavePersonSlimAsync(PersonSlim person);

		public void TestMapper(PersonSlim person);

		public Task<List<PersonSlim>> GetAllCharactersAsync(PersonSlim searchCondition);

		public Task<List<PersonSlim>> GetFewCharactersAsync(PersonSlim searchCondition);

		public Task<int> GetCharacterIndexAsync(ObservableCollection<PersonSlim> persons, PersonSlim searchCondition);

		public Task<PersonSlim> GetRandomCharacterAsync();
	}
}
