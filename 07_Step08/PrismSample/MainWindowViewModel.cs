using System;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.PrismMvvm;
using PrismSample.ReactiveMvvm;

namespace PrismSample
{
	public class MainWindowViewModel : BindableBase, IDisposable
	{
		private string _title = "Prism Application";

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private IRegionManager regionManager = null;

		public MainWindowViewModel(IRegionManager regMan)
		{
			this.regionManager = regMan;

			//this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(BindSamplePage));
			this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ReactiveSamplePanel));
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
