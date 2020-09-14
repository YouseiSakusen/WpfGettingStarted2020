using System;
using System.IO;
using System.Threading.Tasks;

namespace PrismSample
{
	/// <summary>Person用のリポジトリを表します。</summary>
	public class PersonRepository : IPersonRepository
	{
		public void SavePerson(Person person)
		{

		}

		public async Task SavePersonSlimAsync(PersonSlim person)
		{
			//return Task.Run(() =>
			//{
			//	var dirPath = Path.Combine(SampleUtilities.GetExecutingPath(), "Bleach.xml");

			//	SampleUtilities.XmlSerializeToFile<PersonSlim>(dirPath, person);
			//});

			var dirPath = Path.Combine(SampleUtilities.GetExecutingPath(), "Bleach.xml");

			await Task.Run(() =>
			{
				//SampleUtilities.SerializeMessagePack<PersonSlim>(dirPath, person);
			});
		}

		public Person GetPerson(int id)
		{
			return this.createSampleData();
		}

		public Task<Person> GetPersonAsync(int id)
		{
			var ret = Task.Run(() =>
			{
				return this.createSampleData();
			});

			return ret;
		}

		private Person createSampleData()
		{
			return new Person()
			{
				Id = 1,
				Name = "黒崎一護",
				//Kana = "くろさき　いちご",
				BirthDay = new DateTime(1998, 7, 15)
				//Sex = 1
			};
		}

		public PersonSlim GetPersonSlim(int id)
		{
			return new PersonSlim(1, "黒崎一護", new DateTime(1998, 7, 15));
		}

		public Task<PersonSlim> GetPersonSlimAsync()
		{
			return Task.Run(() =>
			{
				return new PersonSlim(1, "黒崎一護", new DateTime(1998, 7, 15));
			});
		}

		/// <summary>PersonDtoを取得します。</summary>
		/// <returns>取得したPersonDto。</returns>
		public PersonDto GetPersonDto()
		{
			return new PersonDto()
			{
				Id = 1,
				Name = "黒崎一護",
				BirthDay = new DateTime(1998, 7, 15)
			};
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
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~PersonRepository()
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
