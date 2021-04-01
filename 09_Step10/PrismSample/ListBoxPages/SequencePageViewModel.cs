using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample.ListBoxPages
{
	public class SequencePageViewModel : BindableBase, IDestructible
	{
		public ReadOnlyReactiveCollection<int> Sequence { get; }

		public ReactivePropertySlim<int> SelectedValue { get; }

		public ReactiveCommand ShowSeqenceClick { get; }

		public ReactiveCommand ClearSequenceClick { get; }

		private CompositeDisposable disposable = new CompositeDisposable();
		private ObservableCollection<int> seqSource = null;
		private IObservable<int> sequenceCount = null;

		public SequencePageViewModel()
		{
			this.seqSource = new ObservableCollection<int>();
			this.Sequence = this.seqSource
				.ToReadOnlyReactiveCollection(seq => seq)
				.AddTo(this.disposable);
			this.sequenceCount = this.Sequence.ObserveProperty(x => x.Count);
			
			this.SelectedValue = new ReactivePropertySlim<int>(0)
				.AddTo(this.disposable);

			this.ClearSequenceClick = this.sequenceCount.Select(c => 0 < c)
				.ToReactiveCommand()
				.WithSubscribe(() => this.seqSource.Clear())
				.AddTo(this.disposable);

			this.ShowSeqenceClick = this.sequenceCount.Select(c => c == 0)
				.ToReactiveCommand()
				.WithSubscribe(() => this.seqSource.AddRange(Enumerable.Range(1, 30)))
				.AddTo(this.disposable);
		}

		public void Destroy()
			=> this.disposable.Dispose();
	}
}
