using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;

namespace PrismSample
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		/// <summary>ViewModelLocatorを設定します。</summary>
		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();

			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(vt =>
			{
				var viewName = vt.FullName;
				var asmName = vt.GetTypeInfo().Assembly.FullName;
				var vmName = $"{viewName}ViewModel, {asmName}";

				return Type.GetType(vmName);
			});
		}

		/// <summary>DIコンテナへ依存クラスを登録します。</summary>
		/// <param name="containerRegistry">登録するDIコンテナを表すIContainerRegistry。</param>
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<DataAgent>();
			containerRegistry.Register<IPersonRepository, PersonRepository>();
		}

		private Mutex mutex = new Mutex(false, "HalationGhostPrismSample");

		/// <summary>ApplicationのStartupイベントハンドラ。</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているStartupEventArgs。</param>
		private void PrismApplication_Startup(object sender, StartupEventArgs e)
		{
			if (this.mutex.WaitOne(0, false))
				return;

			MessageBox.Show("二重起動できません。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
			this.mutex.Close();
			this.mutex = null;
			this.Shutdown();
		}

		/// <summary>ApplicationのExitイベントハンドラ。</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているExitEventArgs。</param>
		private void PrismApplication_Exit(object sender, ExitEventArgs e)
		{
			if (this.mutex != null)
			{
				this.mutex.ReleaseMutex();
				this.mutex.Close();
			}
		}
	}
}
