using System;
using System.Reactive.Linq;
using MessagePack;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample
{
	[MessagePackObject]
	public class PersonSlim : DisposableModelBase
	{
		/// <summary>IDを取得・設定します。</summary>
		[Key(0)]
		public ReactivePropertySlim<int?> Id { get; set; }

		/// <summary>名前を取得・設定します。</summary>
		[Key(1)]
		public ReactivePropertySlim<string> Name { get; set; }

		/// <summary>誕生日を取得・設定します。</summary>
		[Key(2)]
		public ReactivePropertySlim<DateTime?> BirthDay { get; set; }

		/// <summary>年齢を取得します。</summary>
		[IgnoreMember]
		public ReadOnlyReactivePropertySlim<int> Age { get; set; }

		[IgnoreMember]
		private ReactivePropertySlim<int> calcAge { get; set; }

		/// <summary>コンストラクタ。</summary>
		public PersonSlim() : this(null, string.Empty, null)
		{
			//this.BirthDay.Where(v => v.HasValue)
			//	.Subscribe(d => this.calcAge.Value = DateTime.Now.Year - d.Value.Year)
			//	.AddTo(this.disposables);
		}

		/// <summary>コンストラクタ。</summary>
		/// <param name="id">IDの初期値を表すint?</param>
		/// <param name="name">Nameの初期値を表す文字列。</param>
		/// <param name="birthDay">BirthDayの初期値を表すDateTime?。</param>
		public PersonSlim(int? id, string name, DateTime? birthDay)
		{
			this.calcAge = new ReactivePropertySlim<int>(0)
				.AddTo(this.disposables);

			this.Id = new ReactivePropertySlim<int?>(id)
				.AddTo(this.disposables);
			this.Name = new ReactivePropertySlim<string>(name)
				.AddTo(this.disposables);
			this.BirthDay = new ReactivePropertySlim<DateTime?>(birthDay);
			this.Age = this.calcAge.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.BirthDay.Subscribe(d =>
			{
				if (d.HasValue)
					this.calcAge.Value = DateTime.Now.Year - d.Value.Year;
			})
				.AddTo(this.disposables);
		}
	}
}
