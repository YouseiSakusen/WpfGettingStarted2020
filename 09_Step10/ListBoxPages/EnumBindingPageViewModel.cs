﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using ListBoxBindingSamle;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ListBoxBindingSamle.ListBoxPages
{
	public class EnumBindingPageViewModel : BindableBase, IDestructible
	{
		public ReactivePropertySlim<所属組織?> BleachListSelectedValue { get; }

		private CompositeDisposable disposables = new CompositeDisposable();

		public EnumBindingPageViewModel()
		{
			this.BleachListSelectedValue = new ReactivePropertySlim<所属組織?>(null)
				.AddTo(this.disposables);
			this.BleachListSelectedValue.Subscribe(s => Debug.WriteLine(s.ToString()));
		}

		public void Destroy()
			=> this.disposables.Dispose();
	}
}
