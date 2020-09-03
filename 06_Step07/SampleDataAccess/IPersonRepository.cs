using System;
using System.Threading.Tasks;

namespace PrismSample
{
	public interface IPersonRepository : IDisposable
	{
		public Person GetPerson(int id);

		public PersonSlim GetPersonSlim(int id);

		public Task<Person> GetPersonAsync(int id);

		public Task<PersonSlim> GetPersonSlimAsync();

		public void SavePerson(Person person);

		public Task SavePersonSlimAsync(PersonSlim person);
	}
}
