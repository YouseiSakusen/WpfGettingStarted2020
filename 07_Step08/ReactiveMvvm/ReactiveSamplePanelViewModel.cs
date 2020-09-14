using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Unity;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample.ReactiveMvvm
{
	/// <summary>ReactivePropertyのデータバインディングサンプル用ViewModelを表します。</summary>
	public class ReactiveSamplePanelViewModel : BindableBase, IDestructible
	{
		/// <summary>IDを取得・設定します。</summary>
		public ReactivePropertySlim<int?> Id { get; }

		/// <summary>名前を取得・設定します。</summary>
		public ReactivePropertySlim<string> Name { get; }

		/// <summary>誕生日を取得・設定します。</summary>
		public ReactivePropertySlim<DateTime?> BirthDay { get; }

		public ReadOnlyReactivePropertySlim<int> Age { get; }

		/// <summary>現在日時を取得します。</summary>
		public ReadOnlyReactivePropertySlim<string> NowDateTime { get; }

		/// <summary>パラメータで指定した分数を減算した時刻を取得します。</summary>
		public ReadOnlyReactivePropertySlim<string> PastTime { get; }

		/// <summary>パラメータ切り替えToggleButtonのIsCheckedを取得・設定します。</summary>
		public ReactivePropertySlim<bool> PastParameter { get; }

		/// <summary>コマンドパラメータの値を取得します。</summary>
		public ReadOnlyReactivePropertySlim<int> PastParameterValue { get; }

		/// <summary>MouseMoveイベントを受け取ります。</summary>
		public ReactivePropertySlim<MouseEventArgs> MousePoint { get; }

		/// <summary>現在のマウス座標を取得・設定します。</summary>
		public ReactivePropertySlim<string> CurrentMousePoint { get; }

		/// <summary>読込ボタンClickコマンド</summary>
		public AsyncReactiveCommand LoadClick { get; }

		/// <summary>現在日時取得ボタンのCommandを表します。</summary>
		public ReactiveCommand NowDateTimeClick { get; }

		/// <summary>パラメータを受け取るCommand。</summary>
		public AsyncReactiveCommand<int> PastTimeClick { get; }

		/// <summary>部分ViewのLoadedイベントハンドラ。</summary>
		public AsyncReactiveCommand ViewLoaded { get; }

		/// <summary>MouseMoveイベントを受け取るCommand。</summary>
		public ReactiveCommand<MouseEventArgs> MouseMove { get; }

		public ReactiveCommand MapperTest { get; }

		/// <summary>読込処理</summary>
		private async Task onLoadClick()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				await agent.UpdatePersonSlimAsync(this.Id.Value, this.personSlim);
			}
		}

		/// <summary>10分前、20分前ボタンで過去時刻を表示します。</summary>
		/// <param name="interval">Commandに設定したパラメータを表す文字列。</param>
		/// <returns>非同期処理のTask。</returns>
		//private Task onPastTimeClickAsync(string interval)
		//{
		//	return Task.Run(() =>
		//	{
		//		this.pastText.Value = DateTime.Now.AddMinutes(-1 * Convert.ToInt32(interval)).ToString("yyyy/MM/dd HH:mm:ss");
		//	});
		//}
		private Task onPastTimeClickAsync(int interval)
		{
			return Task.Run(() =>
			{
				this.pastText.Value = DateTime.Now.AddMinutes(-1 * interval).ToString("yyyy/MM/dd HH:mm:ss");
			});
		}

		/// <summary>マウス座標をCurrentMousePointに表示します。</summary>
		/// <param name="args">MouseMoveイベントパラメータを表すMouseEventArgs。</param>
		private void onMousePoint(MouseEventArgs args)
		{
			var pos = args.GetPosition(null);
			this.CurrentMousePoint.Value = $"(X: {pos.X} Y: {pos.Y})";
		}

		/// <summary>マウス座標をCurrentMousePointに表示します。</summary>
		/// <param name="args">MouseMoveイベントパラメータを表すMouseEventArgs。</param>
		private void onMouseMove(MouseEventArgs args)
			=> this.onMousePoint(args);

		private void onMapperTest()
		{
			using (var agent = this.container.Resolve<IDataAgent>())
			{
				agent.TestMapper(this.personSlim);
			}
		}

		private CompositeDisposable disposables = new CompositeDisposable();
		private PersonSlim personSlim = null;
		private IContainerProvider container = null;
		private IReactiveSamplePanelAdapter adapter = null;
		private Person person = new Person();
		private ReactivePropertySlim<bool> hasId;
		private ReactivePropertySlim<string> pastText;

		/// <summary>コンストラクタ。</summary>
		public ReactiveSamplePanelViewModel(PersonSlim person, IReactiveSamplePanelAdapter reactiveSamplePanelAdapter)
		{
			this.adapter = reactiveSamplePanelAdapter;
			this.adapter.ContainerProvider = (Application.Current as PrismApplication)?.Container;

			this.personSlim = person;
			this.personSlim.AddTo(this.disposables);
			this.container = (Application.Current as PrismApplication)?.Container;

			this.hasId = new ReactivePropertySlim<bool>(false)
				.AddTo(this.disposables);
			this.pastText = new ReactivePropertySlim<string>(string.Empty)
				.AddTo(this.disposables);

			this.Id = this.personSlim.Id;
			this.Name = this.personSlim.Name
				.AddTo(this.disposables);
			this.BirthDay = this.personSlim.BirthDay
				.AddTo(this.disposables);
			this.Age = this.personSlim.Age
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			//this.Id = this.adapter.Person.Id;
			//this.Name = this.adapter.Person.Name
			//	.AddTo(this.disposables);
			//this.BirthDay = this.adapter.Person.BirthDay
			//	.AddTo(this.disposables);
			//this.Age = this.adapter.Person.Age
			//	.ToReadOnlyReactivePropertySlim()
			//	.AddTo(this.disposables);

			this.PastTime = this.pastText
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);
			this.PastParameter = new ReactivePropertySlim<bool>(false);

			this.CurrentMousePoint = new ReactivePropertySlim<string>(string.Empty)
				.AddTo(this.disposables);
			this.MousePoint = new ReactivePropertySlim<MouseEventArgs>(mode: ReactivePropertyMode.None);

			this.Id.Subscribe(v => this.hasId.Value = v.HasValue)
				.AddTo(this.disposables);
			this.PastParameterValue = this.PastParameter
				.Select(v => v ? 20 : 10)
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);
			this.MousePoint.Subscribe(a => this.onMousePoint(a))
				.AddTo(this.disposables);

			this.LoadClick = this.hasId
				.ToAsyncReactiveCommand()
				.WithSubscribe(() => this.onLoadClick())
				.AddTo(this.disposables);

			//this.LoadClick = new ReactiveCommand(this.hasId)
			//	.WithSubscribe(() => this.onLoadClick())
			//	.AddTo(this.disposables);

			this.NowDateTimeClick = new ReactiveCommand()
				.AddTo(this.disposables);
			this.NowDateTime = this.NowDateTimeClick
				.Select(_ => DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			//this.PastTimeClick = new AsyncReactiveCommand<string>()
			//	.WithSubscribe(i => Task.Run(() => this.pastText.Value = DateTime.Now.AddMinutes(-1 * Convert.ToInt32(i)).ToString("yyyy/MM/dd HH:mm:ss")))
			//	.AddTo(this.disposables);

			//this.PastTimeClick = new AsyncReactiveCommand<string>()
			//	.WithSubscribe(i => this.onPastTimeClickAsync(i))
			//	.AddTo(this.disposables);
			this.PastTimeClick = new AsyncReactiveCommand<int>()
				.WithSubscribe(i => this.onPastTimeClickAsync(i))
				.AddTo(this.disposables);

			this.ViewLoaded = new AsyncReactiveCommand()
				.WithSubscribe(() => Task.Run(() => Debug.WriteLine("Loaded!")))
				.AddTo(this.disposables);

			this.MouseMove = new ReactiveCommand<MouseEventArgs>()
				.WithSubscribe(a => this.onMouseMove(a))
				.AddTo(this.disposables);

			this.MapperTest = new ReactiveCommand()
				.WithSubscribe(() => this.onMapperTest())
				.AddTo(this.disposables);
		}

		/// <summary>部分Viewを破棄します。</summary>
		public void Destroy()
			=> this.disposables.Dispose();
	}
}
