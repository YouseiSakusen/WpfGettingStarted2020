using System;
using System.Collections.Generic;

namespace PrismSample
{
	/// <summary>データアクセス層のPersonリポジトリクラス。</summary>
	public class PersonRepository : IPersonRepository
	{
		public List<Person> GetPersons()
		{
			// 実際はXMLやDBからデータを取得する
			return new List<Person>();
		}

		#region  IDisposable

		//private bool disposedValue;

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (!disposedValue)
		//	{
		//		if (disposing)
		//		{
		//			// TODO: マネージド状態を破棄します (マネージド オブジェクト)
		//		}

		//		// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
		//		// TODO: 大きなフィールドを null に設定します
		//		disposedValue = true;
		//	}
		//}

		//// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		//// ~PersonDataAccess()
		//// {
		////     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
		////     Dispose(disposing: false);
		//// }

		//public void Dispose()
		//{
		//	// このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
		//	Dispose(disposing: true);
		//	GC.SuppressFinalize(this);
		//}

		#endregion
	}
}
