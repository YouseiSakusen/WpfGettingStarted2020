using System;

namespace PrismSample
{
	/// <summary>DataAccess層で生成される個人情報を表します。</summary>
	public class PersonDto
	{
		/// <summary>IDを取得・設定します。</summary>
		public int? Id { get; set; } = null;

		/// <summary>個人名を取得・設定します。</summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>個人名のフリガナを取得・設定します</summary>
		public string Kana { get; set; } = string.Empty;

		/// <summary>誕生日を取得・設定します</summary>
		public DateTime? BirthDay { get; set; } = null;

		public override string ToString()
		{
			return @$"クラス名： {nameof(PersonDto)}
{nameof(this.Id)}： {this.Id}
{nameof(this.Name)}： {this.Name}
{nameof(this.BirthDay)}： {this.BirthDay}";
		}
	}
}
