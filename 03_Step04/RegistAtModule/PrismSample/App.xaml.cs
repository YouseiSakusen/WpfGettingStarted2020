using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismSample
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override Window CreateShell()
		{
			Debug.WriteLine("CreateShell");
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			Debug.WriteLine("RegisterTypes");
		}

		protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
		{
			base.ConfigureDefaultRegionBehaviors(regionBehaviors);
			Debug.WriteLine("ConfigureDefaultRegionBehaviors");
		}

		protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
		{
			base.ConfigureRegionAdapterMappings(regionAdapterMappings);
			Debug.WriteLine("ConfigureRegionAdapterMappings");
		}

		/// <summary>Moduleカタログを設定します。</summary>
		/// <param name="moduleCatalog">設定するModuleカタログを表すIModuleCatalog。</param>
		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			base.ConfigureModuleCatalog(moduleCatalog);
			Debug.WriteLine("ConfigureModuleCatalog");
		}

		protected override void ConfigureServiceLocator()
		{
			base.ConfigureServiceLocator();
			Debug.WriteLine("ConfigureServiceLocator");
		}

		/// <summary>ViewModelLocatorを設定します。</summary>
		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();
			Debug.WriteLine("ConfigureViewModelLocator");

			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(vt =>
			{
				var viewName = vt.FullName;
				var asmName = vt.GetTypeInfo().Assembly.FullName;
				var vmName = $"{viewName}ViewModel, {asmName}";

				return Type.GetType(vmName);
			});
		}

		protected override IContainerExtension CreateContainerExtension()
		{
			Debug.WriteLine("CreateContainerExtension");
			return base.CreateContainerExtension();
		}

		/// <summary>IModuleCatalogを作成します。</summary>
		/// <returns>作成したIModuleCatalog。</returns>
		protected override IModuleCatalog CreateModuleCatalog()
		{
			Debug.WriteLine("CreateModuleCatalog");

			return new DirectoryModuleCatalog() { ModulePath = @".\ModelModules" };
		}

		//protected override IModuleCatalog CreateModuleCatalog()
		//{
		//	Debug.WriteLine("CreateModuleCatalog");
		//	return base.CreateModuleCatalog();
		//}

		protected override void InitializeModules()
		{
			base.InitializeModules();
			Debug.WriteLine("InitializeModules");
		}

		protected override void InitializeShell(Window shell)
		{
			base.InitializeShell(shell);
			Debug.WriteLine("InitializeShell");
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Debug.WriteLine("OnInitialized");
		}

		protected override void RegisterFrameworkExceptionTypes()
		{
			base.RegisterFrameworkExceptionTypes();
			Debug.WriteLine("RegisterFrameworkExceptionTypes");
		}

		protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
		{
			base.RegisterRequiredTypes(containerRegistry);
			Debug.WriteLine("RegisterRequiredTypes");
		}

		private Mutex mutex = new Mutex(false, "HalationGhostPrismSample");

		/// <summary>ApplicationのStartupイベントハンドラ。</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているStartupEventArgs。</param>
		private void PrismApplication_Startup(object sender, StartupEventArgs e)
		{
			Debug.WriteLine("PrismApplication_Startup");
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
