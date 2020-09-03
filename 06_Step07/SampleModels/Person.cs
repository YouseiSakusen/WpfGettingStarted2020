using System;
using Prism.Mvvm;

namespace PrismSample
{
	/// <summary>エンティティ系モデルクラス。</summary>
	public class Person : BindableBase
	{
		private int? id = null;
		public int? Id
		{
			get { return id; }
			set { SetProperty(ref id, value); }
		}

		private string name = string.Empty;
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		private DateTime? birthday = null;
		public DateTime? BirthDay
		{
			get { return birthday; }
			set
			{
				SetProperty(ref birthday, value);

				if (value.HasValue)
					this.Age = DateTime.Now.Year - value.Value.Year;
			}
		}

		private int age = 0;
		public int Age
		{
			get { return age; }
			private set { SetProperty(ref age, value); }
		}

		public string Kana { get; set; } = string.Empty;

		/// <summary>性別（男：1、女：2）を取得・設定します。</summary>
		public int? Sex { get; set; } = null;
	}



	//public class Person
	//{
	//	public int Id { get; set; } = 0;

	//	public string Name { get; set; } = string.Empty;

	//	public string Kana { get; set; } = string.Empty;

	//	public DateTime? BirthDay { get; set; } = null;

	//	/// <summary>性別（男：1、女：2）を取得・設定します。</summary>
	//	public int? Sex { get; set; } = null;
	//}
}
