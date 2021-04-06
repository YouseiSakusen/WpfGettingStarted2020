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

		public string LastNameKana { get; set; } = string.Empty;

		public string FirstNameKana { get; set; } = string.Empty;

        /// <summary>誕生日を取得・設定します</summary>
        public DateTime? BirthDay { get; set; } = null;

		public string Zanpakuto { get; set; } = string.Empty;

        public override string ToString()
		{
			return @$"クラス名： {nameof(PersonDto)}
{nameof(this.Id)}： {this.Id}
{nameof(this.Name)}： {this.Name}
{nameof(this.BirthDay)}： {this.BirthDay}";
		}

        public PersonDto(int? id, 
						 string name, 
						 string lastNameKana, 
						 string firstNameKana, 
						 DateTime? birthday, 
						 string zanpakuto)
			: this()
        {
			this.Id = id;
			this.Name = name;
			this.LastNameKana = lastNameKana;
			this.FirstNameKana = firstNameKana;
			this.BirthDay = birthday;
			this.Zanpakuto = zanpakuto;
        }

        public PersonDto() { }
	}
}
