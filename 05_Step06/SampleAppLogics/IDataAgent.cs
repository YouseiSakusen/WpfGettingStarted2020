using System;

namespace PrismSample
{
	public interface IDataAgent : IDisposable
	{
		public Person GetPerson(int id);

		public void UpdatePerson(int id, Person person);

		public void SavePerson(Person person);
	}
}
