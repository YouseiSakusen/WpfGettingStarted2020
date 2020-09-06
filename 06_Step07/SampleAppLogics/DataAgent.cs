using System;
using System.Threading.Tasks;

namespace PrismSample
{
	public class DataAgent : IDataAgent
	{
		public Person GetPerson(int id)
		{
			return this.personRepository.GetPerson(id);
		}

		public async Task UpdatePersonSlimAsync(int id, PersonSlim person)
		{
			var temp = await this.personRepository.GetPersonSlimAsync();

			person.Id.Value = temp.Id.Value;
			person.Name.Value = temp.Name.Value;
			person.BirthDay.Value = temp.BirthDay.Value;

			//var temp = await this.personRepository.GetPersonAsync(id);

			//person.Id.Value = temp.Id;
			//person.Name.Value = temp.Name;
			//person.BirthDay.Value = temp.BirthDay;
		}

		public void SavePerson(Person person)
		{
			this.personRepository.SavePerson(person);
		}

		private IPersonRepository personRepository = null;

		public DataAgent(IPersonRepository personRepo)
		{
			this.personRepository = personRepo;
		}

		public void UpdatePerson(int id, Person person)
		{
			throw new NotImplementedException();
		}

		#region IDisposable

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: マネージド状態を破棄します (マネージド オブジェクト)
					this.personRepository?.Dispose();
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~DataAgent()
		// {
		//     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
