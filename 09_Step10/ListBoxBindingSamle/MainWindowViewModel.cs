using System;
using ListBoxBindingSamle.ListBoxPages;
using Prism.Mvvm;
using Prism.Regions;

namespace ListBoxBindingSamle
{
	public class MainWindowViewModel : BindableBase, IDisposable
	{
		private IRegionManager regionManager = null;

		public MainWindowViewModel(IRegionManager regMan)
		{
			this.regionManager = regMan;

			//// Viewから直接データを供給
			//this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewDirectPage));
			//// VMからデータを供給
			//this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(SequencePage));
			// ObjectDataProviderでバインド
			this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(EnumBindingPage));
			//// EnumBindingSourceExtensionでバインド
			//this.regionManager.RegisterViewWithRegion("ContentRegion", typeof(EnumMarkupPage));
		}

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
	}
}
