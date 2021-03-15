using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace PrismSample.ReactiveMvvm
{
	/// <summary>BLEACHキャラクターListBoxItem用ViewModelを表します。</summary>
	public class BleachListItemViewModel : BindableBase, IDisposable
	{
		/// <summary>キャラクター名を取得します。</summary>
		public Reactive.Bindings.ReadOnlyReactivePropertySlim<string> Name { get; }

		/// <summary>キャラクター姓の読み仮名を取得します。</summary>
		public Reactive.Bindings.ReadOnlyReactivePropertySlim<string> LastNameKana { get; }

		/// <summary>キャラクター名の読み仮名を取得します。</summary>
		public Reactive.Bindings.ReadOnlyReactivePropertySlim<string> FirstNameKana { get; }

		/// <summary>誕生日を文字列として取得します。</summary>
		public Reactive.Bindings.ReadOnlyReactivePropertySlim<string> BirthDay { get; }

		/// <summary>斬魄刀銘を取得します。</summary>
		public Reactive.Bindings.ReadOnlyReactivePropertySlim<string> Zanpakuto { get; }

		public ReactiveProperty<bool> IsSelected { get; }

		/// <summary>VMに設定したエンティティ系モデルを取得します。</summary>
		public PersonSlim SourcePerson { get; } = null;

		private CompositeDisposable disposable = new CompositeDisposable();

		/// <summary>コンストラクタ。</summary>
		/// <param name="bleachChara">VMが仲介するBLEACHキャラクターのインスタンス。</param>
		public BleachListItemViewModel(PersonSlim bleachChara)
		{
			this.SourcePerson = bleachChara;
			this.SourcePerson.AddTo(this.disposable);

			this.Name = this.SourcePerson.Name
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.LastNameKana = this.SourcePerson.LastNameKana
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.FirstNameKana = this.SourcePerson.FirstNameKana
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.BirthDay = this.SourcePerson.BirthDay
				.Where(v => v.HasValue)
				.Select(v => v.Value.ToString("yyyy/MM/dd"))
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.Zanpakuto = this.SourcePerson.Zanpakuto
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);

			this.IsSelected = new ReactiveProperty<bool>(false)
				.AddTo(this.disposable);
		}

		#region IDisposable

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					this.disposable.Dispose();
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~BleachListItemViewModel()
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
