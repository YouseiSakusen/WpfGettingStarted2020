using System;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.ListBoxPages;

namespace PrismSample
{
	public class MainWindowViewModel : BindableBase, IDisposable
	{
		private IRegionManager regionManager = null;
		private bool disposedValue;

		public MainWindowViewModel(IRegionManager regMan)
		{
			this.regionManager = regMan;

			//// ListBoxItemをXAMLに書いた場合
			//this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewDirectPage));
			// ListBoxItemをXAMLに書いた場合
			this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(SequencePage));
		}

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
	}
}
