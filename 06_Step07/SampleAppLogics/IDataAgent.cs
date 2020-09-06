using System;
using System.Threading.Tasks;

namespace PrismSample
{
	public interface IDataAgent : IDisposable
	{
		public Person GetPerson(int id);

		public void UpdatePerson(int id, Person person);

		public Task UpdatePersonSlimAsync(int id, PersonSlim person);

		public void SavePerson(Person person);
	}
}
