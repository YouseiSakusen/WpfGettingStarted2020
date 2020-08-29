using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Unity;
using Prism.Ioc;
using System;

namespace PrismSample.PrismMvvm
{
	/// <summary>Prismデータバインディングのサンプル用ViewModelを表します。</summary>
	public class BindSamplePageViewModel : BindableBase
	{
		/// <summary>IDを取得・設定します。</summary>
		public int? Id
		{
			get { return this.person.Id; }
			set
			{
				this.person.Id = value;
				this.RaisePropertyChanged(nameof(Id));
			}
		}

		/// <summary>名前を取得・設定します。</summary>
		public string Name
		{
			get { return this.person.Name; }
			set
			{
				this.person.Name = value;
				this.RaisePropertyChanged(nameof(Name));
			}
		}

		/// <summary>誕生日を取得・設定します。</summary>
		public DateTime? BirthDay
		{
			get { return this.person.BirthDay; }
			set
			{
				this.person.BirthDay = value;
				this.RaisePropertyChanged(nameof(this.Age));
				this.RaisePropertyChanged(nameof(BirthDay));
			}
		}

		/// <summary>現在年齢を取得します。</summary>
		public int Age => this.person.Age;

		/// <summary>保存ボタンのクリックコマンドを取得します。</summary>
		public DelegateCommand SaveButtonClick { get; }

		/// <summary>画面のデータを保存します。</summary>
		void onSaveButtonClick()
		{
			using (var agent = (Application.Current as PrismApplication)?.Container.Resolve<IDataAgent>())
			{
				agent.SavePerson(this.person);
			}
		}

		/// <summary>検索ボタンClick Commandを取得します。</summary>
		public DelegateCommand SearchButtonClick { get; }

		/// <summary>データを読み込みます。</summary>
		void onSearchButtonClick()
		{
			if (!this.Id.HasValue)
				return;

			using (var agent = (Application.Current as PrismApplication)?.Container.Resolve<IDataAgent>())
			{
				agent.UpdatePerson(this.Id.Value, this.person);
				this.RaisePropertyChanged(null);
			}
		}

		private Person person = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="initPerson">インジェクションするPersonの初期値。</param>
		public BindSamplePageViewModel(Person initPerson)
		{
			this.person = initPerson;

			this.SearchButtonClick = new DelegateCommand(this.onSearchButtonClick, () => true);
			this.SaveButtonClick = new DelegateCommand(this.onSaveButtonClick);
		}





		// ※ ↓ 現在年齢無しのサンプルコード

		//private int? id = null;
		///// <summary>IDを取得・設定します。</summary>
		//public int? Id
		//{
		//	get { return id; }
		//	set { SetProperty(ref id, value); }
		//}

		//private string name = string.Empty;
		///// <summary>名前を取得・設定します。</summary>
		//public string Name
		//{
		//	get { return name; }
		//	set { SetProperty(ref name, value); }
		//}

		//private DateTime? birthDay = null;
		///// <summary>誕生日を取得・設定します。</summary>
		//public DateTime? BirthDay
		//{
		//	get { return birthDay; }
		//	set { SetProperty(ref birthDay, value); }
		//}

		////private TextBoxViewModel nameTextBox;
		/////// <summary>名前TexBoxを取得・設定します。</summary>
		////public TextBoxViewModel NameTextBox
		////{
		////	get { return nameTextBox; }
		////	private set { SetProperty(ref nameTextBox, value); }
		////}

		///// <summary>保存ボタンのクリックコマンドを取得します。</summary>
		//public DelegateCommand SaveButtonClick { get; }

		///// <summary>画面のデータを保存します。</summary>
		//void onSaveButtonClick()
		//{
		//	using (var agent = (Application.Current as PrismApplication)?.Container.Resolve<IDataAgent>())
		//	{
		//		agent.SavePerson(new Person()
		//		{
		//			Id = this.Id.Value,
		//			Name = this.Name,
		//			BirthDay = this.BirthDay.Value
		//		});
		//	}
		//}

		///// <summary>検索ボタンClick Commandを取得します。</summary>
		//public DelegateCommand SearchButtonClick { get; }

		///// <summary>データを読み込みます。</summary>
		//void onSearchButtonClick()
		//{
		//	if (!this.Id.HasValue)
		//		return;

		//	using (var agent = (Application.Current as PrismApplication)?.Container.Resolve<IDataAgent>())
		//	{
		//		var person = agent.GetPerson(this.id.Value);

		//		this.Id = person.Id;
		//		this.Name = person.Name;
		//		this.BirthDay = person.BirthDay;
		//	}
		//}

		///// <summary>コンストラクタ。</summary>
		//public BindSamplePageViewModel()
		//{
		//	//this.nameTextBox = new TextBoxViewModel("管理人VM", false);

		//	this.SearchButtonClick = new DelegateCommand(this.onSearchButtonClick, () => true);
		//	this.SaveButtonClick = new DelegateCommand(this.onSaveButtonClick);
		//}
	}
}
