﻿using System;
using System.Reflection;
using System.Windows;
using Prism.Ioc;
using Prism.Mvvm;

namespace PrismSample
{
	/// <summary>Interaction logic for App.xaml</summary>
	public partial class App
	{
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

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		/// <summary>DIコンテナにインジェクションするクラスを登録します。</summary>
		/// <param name="containerRegistry">登録用のDIコンテナを表すcontainerRegistry。</param>
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IPersonRepository, PersonRepository>();
			containerRegistry.Register<IDataAgent, DataAgent>();
			containerRegistry.Register<IReactiveSamplePanelAdapter, ReactiveSamplePanelAdapter>();
			containerRegistry.Register<PersonSlim>();
			containerRegistry.RegisterInstance(MapperFactory.GetMapper());
			containerRegistry.RegisterInstance(this.Container);
		}
	}
}
