using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Prism.Ioc;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample
{
	/// <summary>ReactiveSamplePanel用のAdapter</summary>
	public class ReactiveSamplePanelAdapter : IReactiveSamplePanelAdapter
	{
		/// <summary>ViewとバインドするPersonSlimを取得します。</summary>
		public PersonSlim Person { get; private set; }

		/// <summary>検索結果に表示するキャラクターを取得します。</summary>
		public ObservableCollection<PersonSlim> SearchResults { get; }

		public ReadOnlyReactivePropertySlim<int> SearchResultCount { get; }

		/// <summary>ListBoxで選択された項目のインデックスを取得・設定します。</summary>
		public ReactivePropertySlim<int> SelectedCharacterIndex { get; }

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

		public async Task SearchCharacterAsync()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				//await agent.SearchFewCharacterAsync(this.Person, this.SearchResults);
				await agent.SearchCharacterAsync(this.Person, this.SearchResults);
			}
		}

		/// <summary>検索結果をクリアします。</summary>
		/// <returns>非同期のTask。</returns>
		public Task ClearAllCharacters()
			=> Task.Run(() => this.SearchResults.Clear());

		/// <summary>キャラクターをランダムに追加します。</summary>
		/// <returns>非同期のTask。</returns>
		public async Task AddRandomCharacter()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				await agent.AddRandomCharacter(this.SearchResults);
			}
		}

		public async Task InsertRandomCharacter()
		{
			if (this.SelectedCharacterIndex.Value < 0)
				return;

			using (var agent = this.container.Resolve<IDataAgent>())
			{
				await agent.InsertRandomCharacter(this.SearchResults, this.SelectedCharacterIndex.Value);
			}
		}

		/// <summary>SelectedCharacterIndexの変更通知処理を表します。</summary>
		/// <param name="index">新たに選択された項目のインデックスを表すint。</param>
		private void selectedCharacterChanged(int index)
		{
			if ((index < 0) || (this.SearchResults.Count - 1 < index))
				return;	

			var selectedCharacter = this.SearchResults[index];
			this.Person.Id.Value = selectedCharacter.Id.Value;
			this.Person.Name.Value = selectedCharacter.Name.Value;
			this.Person.BirthDay.Value = selectedCharacter.BirthDay.Value;
			this.Person.Zanpakuto.Value = selectedCharacter.Zanpakuto.Value;
		}

		private IContainerProvider container = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		/// <summary>コンストラクタ。</summary>
		/// <param name="containerProvider">インスタンス取得用のDIコンテナを表すIContainerProvider。（DIコンテナからインジェクションされる）</param>
		/// <param name="personSlim">ViewとバインドするPersonSlim。（DIコンテナからインジェクションされる）</param>
		public ReactiveSamplePanelAdapter(IContainerProvider containerProvider, PersonSlim personSlim)
		{
			this.container = containerProvider;
			this.Person = personSlim
				.AddTo(this.disposables);

			this.SearchResults = new ObservableCollection<PersonSlim>();

			this.SelectedCharacterIndex = new ReactivePropertySlim<int>(-1)
				.AddTo(this.disposables);
			this.SelectedCharacterIndex.Subscribe(v => this.selectedCharacterChanged(v));
		}

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: マネージド状態を破棄します (マネージド オブジェクト)
					this.disposables.Dispose();
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
