using System;
using System.Collections.Generic;

namespace PrismSample
{
	/// <summary>Personのリポジトリインタフェース。</summary>
	public interface IPersonRepository //: IDisposable
	{
		public List<Person> GetPersons();
	}
}
