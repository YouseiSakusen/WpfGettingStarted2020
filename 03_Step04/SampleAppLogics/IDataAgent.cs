using System;

namespace PrismSample
{
	public interface IDataAgent : IDisposable
	{
		public Person GetPerson(int personId);
	}
}
