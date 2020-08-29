using System;

namespace PrismSample
{
	/// <summary>データを操作します。</summary>
	public class DataAgent : IDataAgent
	{
		public Person GetPerson(int id)
		{
			return this.personRepository.GetPerson(id);
		}

		/// <summary>Personを更新します。</summary>
		/// <param name="id">取得するPersonのIDを表すint。</param>
		/// <param name="person">更新するPerson。</param>
		public void UpdatePerson(int id, Person person)
		{
			var temp = this.personRepository.GetPerson(id);

			person.Id = temp.Id;
			person.Name = temp.Name;
			person.BirthDay = temp.BirthDay;
		}

		/// <summary>Personを保存します。</summary>
		/// <param name="person">保存するPerson。</param>
		public void SavePerson(Person person)
			=> this.personRepository.SavePerson(person);

		private IPersonRepository personRepository = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="personRepo"></param>
		public DataAgent(IPersonRepository personRepo)
			=> this.personRepository = personRepo;

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
