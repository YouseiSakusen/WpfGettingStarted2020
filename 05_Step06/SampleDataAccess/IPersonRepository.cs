using System;

namespace PrismSample
{
	public interface IPersonRepository : IDisposable
	{
		public Person GetPerson(int id);

		public void SavePerson(Person person);
	}
}
