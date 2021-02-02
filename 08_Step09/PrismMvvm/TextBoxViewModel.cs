using Prism.Mvvm;

namespace PrismSample.PrismMvvm
{
	/// <summary>TexBox用ViewModel</summary>
	public class TextBoxViewModel : BindableBase
	{
		private string text;
		/// <summary>Textプロパティを取得・設定します。</summary>
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		private bool enabled;
		/// <summary>IsEnabledプロパティを取得・設定します。</summary>
		public bool IsEnabled
		{
			get { return enabled; }
			set { SetProperty(ref enabled, value); }
		}

		/// <summary>コンストラクタ。</summary>
		/// <param name="initText">Textプロパティの初期値を表す文字列。</param>
		/// <param name="initEnabled">IsEnabledプロパティの初期値を表すbool。</param>
		public TextBoxViewModel(string initText, bool initEnabled)
		{
			this.text = initText;
			this.enabled = initEnabled;
		}
	}
}
