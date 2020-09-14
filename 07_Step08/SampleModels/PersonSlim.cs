using System;
using System.Diagnostics;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismSample
{
	/// <summary>プロパティをReactivePropertySlimで定義したPerson。</summary>
	public class PersonSlim : DisposableModelBase
	{
		/// <summary>IDを取得・設定します。</summary>
		public ReactivePropertySlim<int?> Id { get; set; }

		/// <summary>名前を取得・設定します。</summary>
		public ReactivePropertySlim<string> Name { get; set; }

		/// <summary>誕生日を取得・設定します。</summary>
		public ReactivePropertySlim<DateTime?> BirthDay { get; set; }

		/// <summary>年齢を取得します。</summary>
		public ReadOnlyReactivePropertySlim<int> Age { get; }

		/// <summary>受け取ったPersonDtoの値に更新します。</summary>
		/// <param name="person">更新元のPersonDto。</param>
		public void UpdateFrom(PersonDto person)
		{
			this.Id.Value = Convert.ToInt32(person.Id);
			this.Name.Value = person.Name;
			this.BirthDay.Value = person.BirthDay;
		}

		/// <summary>文字列に変換します。</summary>
		/// <returns>返還後の文字列。</returns>
		public override string ToString()
		{
			return @$"クラス名： {nameof(PersonSlim)}
{nameof(this.Id)}： {this.Id.Value}
{nameof(this.Name)}： {this.Name.Value}
{nameof(this.BirthDay)}： {this.BirthDay.Value}";
		}

		/// <summary>プロパティの参照を比較します。</summary>
		public void CompareProperties()
		{
			Debug.WriteLine("ID: " + object.ReferenceEquals(this.Id, this.refId));
			Debug.WriteLine("Name: " + object.ReferenceEquals(this.Name, this.refName));
			Debug.WriteLine("BirthDay: " + object.ReferenceEquals(this.BirthDay, this.refBirth));
		}

		private ReactivePropertySlim<int> calcAge { get; set; }

		private ReactivePropertySlim<int?> refId = null;
		private ReactivePropertySlim<string> refName = null;
		private ReactivePropertySlim<DateTime?> refBirth = null;

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
			this.BirthDay = new ReactivePropertySlim<DateTime?>(birthDay)
				.AddTo(this.disposables);
			this.Age = this.calcAge.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposables);

			this.BirthDay.Subscribe(d =>
			{
				if (d.HasValue)
					this.calcAge.Value = DateTime.Now.Year - d.Value.Year;
			});

			this.refId = this.Id;
			this.refName = this.Name;
			this.refBirth = this.BirthDay;
		}

		/// <summary>インスタンスを破棄します。</summary>
		/// <param name="disposing">Dispose処理中かを表すbool。</param>
		protected override void Dispose(bool disposing)
		{
			Debug.WriteLine($"Dispose前 Id： {this.Id.IsDisposed}");
			Debug.WriteLine($"Dispose前 Name： {this.Name.IsDisposed}");
			Debug.WriteLine($"Dispose前 BirthDay： {this.BirthDay.IsDisposed}");

			base.Dispose(disposing);

			Debug.WriteLine($"Dispose後 Id： {this.Id.IsDisposed}");
			Debug.WriteLine($"Dispose後 Name： {this.Name.IsDisposed}");
			Debug.WriteLine($"Dispose後 BirthDay： {this.BirthDay.IsDisposed}");
		}
	}
}
