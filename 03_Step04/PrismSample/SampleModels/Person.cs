using System;

namespace PrismSample
{
	/// <summary>エンティティ系モデルクラス。</summary>
	public class Person
	{
		public int Id { get; set; } = 0;

		public string Name { get; set; } = string.Empty;

		public string Kana { get; set; } = string.Empty;

		public DateTime? BirthDay { get; set; } = null;

		public int? Sex { get; set; } = null;
	}
}
