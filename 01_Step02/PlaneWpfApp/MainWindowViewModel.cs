using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PlaneWpfApp
{
	/// <summary>MainWindowのViewModel。</summary>
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		/// <summary>ボタンのCommand。</summary>
		public ICommand ButtonCommand { get; }

		private ObservableCollection<string> personList;

		public ObservableCollection<string> Persons
		{
			get { return personList; }
			set { personList = value; }
		}

		private string singleVal;

		/// <summary>単一値バインド用プロパティ。</summary>
		public string SingleValue
		{
			get { return singleVal; }
			set
			{
				if (value != this.singleVal)
				{
					singleVal = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#region INotifyPropertyChanged

		/// <summary>プロパティ変更通知イベント。</summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>プロパティ変更通知イベント呼出用</summary>
		/// <param name="propertyName">変更対象プロパティ名を表す文字列。</param>
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
			=> this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		#endregion

		/// <summary>コンストラクタ。</summary>
		public MainWindowViewModel()
		{
			this.SingleValue = "INotifyPropertyChanged";
			this.ButtonCommand = new DelegateCommand(() => this.SingleValue = "Command Click!",
				() => !string.IsNullOrEmpty(this.SingleValue));
		}
	}
}
