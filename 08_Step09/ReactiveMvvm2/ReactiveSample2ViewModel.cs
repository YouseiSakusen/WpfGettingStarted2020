using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSample.ReactiveMvvm.ViewModels;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample.ReactiveMvvm
{
	public class ReactiveSample2ViewModel : BindableBase, IDestructible
	{
		/// <summary>ListBoxに表示するBLEACHキャラクターを取得します。</summary>
		public ReadOnlyReactiveCollection<BleachListItemViewModel> SearchResults { get; }
		
		/// <summary>ListBoxで選択された項目のインデックスを取得・設定します。</summary>
		public ReactivePropertySlim<int> SelectedCharacterIndex { get; }

		public AsyncReactiveCommand ShowListItemsClick { get; }

		/// <summary>項目取得ボタンのClickコマンドを表します。</summary>
		public AsyncReactiveCommand GetItemsClick { get; }

		/// <summary>選択項目を設定ボタンのClickコマンドを表します。</summary>
		public AsyncReactiveCommand SelectItemsClick { get; }

		private IReactiveSamplePanelAdapter adapter = null;
		private CompositeDisposable disposables = new CompositeDisposable();

		/// <summary>コンストラクタ。</summary>
		/// <param name="samplePanelAdapter">Model呼び出し用のアダプタを表すIReactiveSamplePanelAdapter。(DIコンテナからインジェクションされる)</param>
		public ReactiveSample2ViewModel(IReactiveSamplePanelAdapter samplePanelAdapter)
		{
			this.adapter = samplePanelAdapter;
			this.adapter.AddTo(this.disposables);

			this.SearchResults = this.adapter.SearchResults
				.ToReadOnlyReactiveCollection(x => new BleachListItemViewModel(x))
				.AddTo(this.disposables);
			this.SelectedCharacterIndex = new ReactivePropertySlim<int>(-1)
				.AddTo(this.disposables);

			this.ShowListItemsClick = new AsyncReactiveCommand()
				.WithSubscribe(() => this.adapter.SearchCharacterAsync())
				.AddTo(this.disposables);

			this.GetItemsClick = this.SelectedCharacterIndex.Select(i => 0 <= i)
				.ToAsyncReactiveCommand()
				.WithSubscribe(() =>
				{
					return Task.Run(() =>
					{
						var selectedItems = this.SearchResults.Where(i => i.IsSelected.Value)
								.Select(i => i.SourcePerson)
								.ToList();

						selectedItems.ForEach(i => Debug.WriteLine(i.ToString()));
					});
				});

			this.SelectItemsClick = this.SearchResults.ObserveProperty(x => x.Count)
				.Select(c => 0 < c)
				.ToAsyncReactiveCommand()
				.WithSubscribe(() =>
				{
					return Task.Run(() =>
					{
						this.SearchResults
							.Where(vm => 40 <= vm.SourcePerson.Age.Value && vm.SourcePerson.Age.Value <= 50)
							.ToList()
							.ForEach(vm => vm.IsSelected.Value = true);
					});
				});
		}

		/// <summary>部分Viewを破棄します。</summary>
		public void Destroy()
			=> this.disposables.Dispose();
	}
}
