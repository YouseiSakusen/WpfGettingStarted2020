using System;
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

		public Task SearchCharacterAsync(PersonSlim searchCondition, ObservableCollection<PersonSlim> persons);

		public Task SearchFewCharacterAsync(PersonSlim searchCondition, ObservableCollection<PersonSlim> persons);

		public Task<int> GetCharacterIndex(ObservableCollection<PersonSlim> persons, PersonSlim searchCondition);

		public Task AddRandomCharacter(ObservableCollection<PersonSlim> persons);

		public Task InsertRandomCharacter(ObservableCollection<PersonSlim> persons, int index);

		public Task RemoveCharacter(ObservableCollection<PersonSlim> persons, int index);
	}
}
