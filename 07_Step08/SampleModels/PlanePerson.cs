using System;

namespace PrismSample
{
	/// <summary>一般的なPersonクラスを表します。</summary>
	public class PlanePerson
	{
		/// <summary>IDを取得・設定します。</summary>
		public int? Id { get; set; } = null;

		/// <summary>個人名を取得・設定します。</summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>誕生日を取得・設定します</summary>
		public DateTime? BirthDay { get; set; } = null;

		public int? Sex { get; set; } = null;

		public override string ToString()
		{
			return @$"クラス名： {nameof(PlanePerson)}
{nameof(this.Id)}： {this.Id}
{nameof(this.Name)}： {this.Name}
{nameof(this.BirthDay)}： {this.BirthDay}";
		}
	}
}
