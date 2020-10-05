using System.Threading.Tasks;
using Prism.Ioc;

namespace PrismSample
{
	/// <summary>ReactiveSamplePanel用のAdapter</summary>
	public class ReactiveSamplePanelAdapter : IReactiveSamplePanelAdapter
	{
		/// <summary>ViewとバインドするPersonSlimを取得します。</summary>
		public PersonSlim Person { get; }

		/// <summary>PersonSlimを更新します。</summary>
		/// <returns>処理を実行するTask。</returns>
		public async Task UpdatePersonAsync()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				await agent.UpdatePersonSlimAsync(this.Person.Id.Value, this.Person);
			}
		}

		/// <summary>PersonSlimを保存します。</summary>
		/// <returns>処理を実行するTask。</returns>
		public async Task SavePersonAsync()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				await agent.SavePersonSlimAsync(this.Person);
			}
		}

		private IContainerProvider container = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="containerProvider">インスタンス取得用のDIコンテナを表すIContainerProvider。（DIコンテナからインジェクションされる）</param>
		/// <param name="personSlim">ViewとバインドするPersonSlim。（DIコンテナからインジェクションされる）</param>
		public ReactiveSamplePanelAdapter(IContainerProvider containerProvider, PersonSlim personSlim)
		{
			this.container = containerProvider;
			this.Person = personSlim;
		}

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
		// ~ReactiveSamplePanelAdapter()
		// {
		//     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
			Dispose(disposing: true);
			System.GC.SuppressFinalize(this);
		}
	}
}
