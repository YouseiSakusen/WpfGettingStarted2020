using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
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

		/// <summary>検索条件に一致するキャラクターを検索します。</summary>
		/// <returns>非同期処理のTask。</returns>
		public async Task SearchCharacterAsync()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				this.SearchResults.AddRange(await agent.GetAllCharactersAsync(this.Person));
				//this.SearchResults.AddRange(await agent.GetFewCharactersAsync(this.Person));
			}
		}

		/// <summary>SelectedCharacterIndexの変更通知処理を表します。</summary>
		/// <param name="index">新たに選択された項目のインデックスを表すint。</param>
		public void UpdatePersonFromSearchResults(int index)
		{
			if ((index < 0) || (this.SearchResults.Count <= index))
				return;

			this.Person.Id.Value = this.SearchResults[index].Id.Value;
			this.Person.Name.Value = this.SearchResults[index].Name.Value;
			this.Person.BirthDay.Value = this.SearchResults[index].BirthDay.Value;
			this.Person.Zanpakuto.Value = this.SearchResults[index].Zanpakuto.Value;
		}

		public Task<int> GetCharacterIndex()
		{
			return Task.Run(() =>
			{
				var resultIndeies = this.SearchResults.Select((p, i) => new { Person = p, Index = i })
					.Where(x => Regex.IsMatch(x.Person.Name.Value, Regex.Escape(this.Person.Name.Value)))
					.Select(x => x.Index)
					.ToList();
				if (resultIndeies.Count == 0)
					return -1;

				return resultIndeies.First();
			});
		}

		/// <summary>検索結果をクリアします。</summary>
		/// <returns>非同期のTask。</returns>
		public Task ClearAllCharactersAsync()
			=> Task.Run(() => this.SearchResults.Clear());

		/// <summary>キャラクターをランダムに追加します。</summary>
		/// <returns>非同期のTask。</returns>
		public async Task AddRandomCharacterAsync()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				this.SearchResults.Add(await agent.GetRandomCharacterAsync());
			}
		}

		public async Task InsertRandomCharacterAsync()
		{
			//using (var agent = this.container.Resolve<IDataAgent>())
			//{
			//	this.SearchResults.Insert(this.SelectedCharacterIndex.Value, await agent.GetRandomCharacterAsync());
			//}
		}

		public Task RemoveSelectedCharacterAsync()
		{
			//var selectedIndex = this.SelectedCharacterIndex.Value;

			//return Task.Run(() =>
			//{
			//	this.SearchResults.RemoveAt(selectedIndex);

			//	if (0 <= selectedIndex - 1)
			//		this.SelectedCharacterIndex.Value = selectedIndex - 1;
			//});
			return Task.CompletedTask;
		}

		private IContainerProvider container = null;
		private CompositeDisposable disposables = new CompositeDisposable();
		private IMapper mapper = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="containerProvider">インスタンス取得用のDIコンテナを表すIContainerProvider。（DIコンテナからインジェクションされる）</param>
		/// <param name="personSlim">ViewとバインドするPersonSlim。（DIコンテナからインジェクションされる）</param>
		public ReactiveSamplePanelAdapter(IContainerProvider containerProvider, PersonSlim personSlim, IMapper autoMapper)
		{
			this.container = containerProvider;
			this.Person = personSlim
				.AddTo(this.disposables);
			this.mapper = autoMapper;

			this.SearchResults = new ObservableCollection<PersonSlim>();
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
