using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ListBoxBindingSamle.ListBoxPages
{
	public class EnumMarkupPageViewModel : BindableBase, IDestructible
	{
		public ReactivePropertySlim<所属組織?> BleachListSelectedValue { get; }

		private CompositeDisposable disposables = new CompositeDisposable();

		public EnumMarkupPageViewModel()
		{
			this.BleachListSelectedValue = new ReactivePropertySlim<所属組織?>(null)
				.AddTo(this.disposables);
			this.BleachListSelectedValue.Subscribe(s => Debug.WriteLine(s.ToString()));
		}

		public void Destroy()
			=> this.disposables.Dispose();
	}
}
