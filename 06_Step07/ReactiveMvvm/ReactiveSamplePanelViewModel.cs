using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample.ReactiveMvvm
{
	/// <summary>ReactivePropertyのデータバインディングサンプル用ViewModelを表します。</summary>
	public class ReactiveSamplePanelViewModel : BindableBase, IDestructible
	{
		///// <summary>IDを取得・設定します。</summary>
		//public ReactiveProperty<int?> Id { get; }

		///// <summary>名前を取得・設定します。</summary>
		//public ReactiveProperty<string> Name { get; }

		///// <summary>誕生日を取得・設定します。</summary>
		//public ReactiveProperty<DateTime?> BirthDay { get; }

		// ReactivePropertySlimで定義したプロパティ
		/// <summary>IDを取得・設定します。</summary>
		public ReactivePropertySlim<int?> Id { get; }

		/// <summary>名前を取得・設定します。</summary>
		public ReactivePropertySlim<string> Name { get; } // = new ReactivePropertySlim<string>("管理人");

		/// <summary>誕生日を取得・設定します。</summary>
		public ReactivePropertySlim<DateTime?> BirthDay { get; }

		public ReadOnlyReactivePropertySlim<int> Age { get; }

		private CompositeDisposable disposables = new CompositeDisposable();
		private Person person = new Person();
		private PersonSlim personSlim = null;

		/// <summary>コンストラクタ。</summary>
		public ReactiveSamplePanelViewModel(IDataAgent dataAgent, PersonSlim initPerson)
		{
			this.personSlim = initPerson;
			this.personSlim.AddTo(this.disposables);

			this.Id = this.personSlim.Id
				.AddTo(this.disposables);
			this.Name = this.personSlim.Name
				.AddTo(this.disposables);
			this.BirthDay = this.personSlim.BirthDay
				.AddTo(this.disposables);
			this.Age = this.personSlim.Age
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			// PersonSlimと双方向でバインドするReactiveProperty
			//this.Id = this.personSlim.Id
			//	.ToReactiveProperty()
			//	.AddTo(this.disposables);
			//this.Name = this.personSlim.Name
			//	.ToReactiveProperty()
			//	.AddTo(this.disposables);
			//this.BirthDay = this.personSlim.BirthDay
			//	.ToReactiveProperty()
			//	.AddTo(this.disposables);

			// BindableBaseと双方向でバインドするReactiveProperty
			//this.Id = this.person.ToReactivePropertyAsSynchronized(x => x.Id)
			//	.AddTo(this.disposables);
			//this.Name = this.person.ToReactivePropertyAsSynchronized(x => x.Name)
			//	.AddTo(this.disposables);
			//this.BirthDay = this.person.ToReactivePropertyAsSynchronized(x => x.BirthDay)
			//	.AddTo(this.disposables);
			//this.Age = this.person.ObserveProperty(x => x.Age)
			//	.ToReadOnlyReactivePropertySlim()
			//	.AddTo(this.disposables);

			// View ⇔ VM間のみのバインディング
			//this.Id = new ReactivePropertySlim<int>(1)
			//	.AddTo(this.disposables);
			//this.Name = new ReactivePropertySlim<string>("管理人")
			//	.AddTo(this.disposables);
			//this.BirthDay = new ReactivePropertySlim<DateTime?>(new DateTime(1998, 7, 15))
			//	.AddTo(this.disposables);
		}

		/// <summary>部分Viewを破棄します。</summary>
		public void Destroy()
			=> this.disposables.Dispose();
	}
}
