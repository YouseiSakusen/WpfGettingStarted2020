using System;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Blue;
using PrismSample.Green;
using PrismSample.Red;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample
{
	/// <summary>MainWindowのViewModel。</summary>
	public class MainWindowViewModel : BindableBase, IDisposable
	{
		private string _title = "Prism Application";
		
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private IRegionManager regionManager = null;

		/// <summary>コンストラクタ</summary>
		/// <param name="regMan">インジェクションするIRegionManager。</param>
		public MainWindowViewModel(IRegionManager regMan)
		{
			this.regionManager = regMan;

			//regMan.RegisterViewWithRegion("ContentRegion", typeof(Tomato));
			this.regionManager.RegisterViewWithRegion("RedContent", typeof(Tomato));
			this.regionManager.RegisterViewWithRegion("BlueContent", typeof(DarkTurquoise));
			//regMan.RegisterViewWithRegion("GreenContent", typeof(MediumSeaGreen));
		}

		#region IDisposable

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: マネージド状態を破棄します (マネージド オブジェクト)
					foreach (var region in this.regionManager.Regions)
					{
						region.RemoveAll();
					}
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~MainWindowViewModel()
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
