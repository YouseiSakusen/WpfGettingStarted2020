using System;
using System.Collections.Generic;
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

		public Task SavePersonAsync(PersonDto person);

		public PersonDto GetPersonDto();

		public Task<PersonDto> GetPersonDtoAsync();

		public Task<List<PersonDto>> SearchCharactersAsync(PersonSlim condition);

		public List<PersonDto> SearchCharacters(PersonSlim condition);

		public List<PersonDto> SearchFewCharacters(PersonSlim condition);
	}
}
