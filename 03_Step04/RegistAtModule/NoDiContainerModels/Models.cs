using System;
using System.Collections.Generic;

namespace PrismSample
{
	/// <summary>アプリケーションロジック層のエージェントクラス。</summary>
	public class DataAgent : IDisposable
	{
		private IPersonRepository repository = null;

		public Person GetPerson(int personId)
		{
			var persons = this.repository.GetPersons();

			return persons.Find(p => p.Id == personId);
		}

		/// <summary>Personリポジトリをコンストラクタのパラメータで受け取る。</summary>
		/// <param name="personRepository">Personリポジトリを表すIPersonRepository。</param>
		public DataAgent(IPersonRepository personRepository)
		{
			this.repository = personRepository;
		}

		#region IDisposable

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					//if (this.repository != null)
					//	this.repository.Dispose();
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

	/// <summary>データアクセス層のPersonリポジトリクラス。</summary>
	public class PersonRepository : IPersonRepository
	{
		public List<Person> GetPersons()
		{
			// 実際はXMLやDBからデータを取得する
			return new List<Person>();
		}

		#region  IDisposable

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
		// ~PersonDataAccess()
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
