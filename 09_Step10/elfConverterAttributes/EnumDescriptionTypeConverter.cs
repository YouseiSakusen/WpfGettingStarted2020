using System;
using System.ComponentModel;
using System.Globalization;

namespace elf.Converters.Attributes
{
	/// <summary>列挙子の代わりにDescriptionを取得するTypeConverterを表します。</summary>
	public class EnumDescriptionTypeConverter : EnumConverter
	{
		/// <summary>指定したコンテキストとカルチャ情報を使用して、変換した値を返します。</summary>
		/// <param name="context">書式指定コンテキストを提供する ITypeDescriptorContext。</param>
		/// <param name="culture">カルチャを表すCultureInfo。</param>
		/// <param name="value">変換対象の値を表すobject。</param>
		/// <param name="destinationType">valueパラメーター変換後のType。</param>
		/// <returns>変換後の値を表すObject。</returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				if (value != null)
				{
					var fInfo = value.GetType().GetField(value.ToString());
					if (fInfo != null)
					{
						var attributes = (DescriptionAttribute[])fInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

						// Description属性が指定されていればDescriptionを返し、指定されていなければ列挙子自体を返す
						return (attributes.Length > 0) && (!string.IsNullOrEmpty(attributes[0].Description)) ? attributes[0].Description : value.ToString();
					}
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		/// <summary>コンストラクタ。</summary>
		/// <param name="type"></param>
		public EnumDescriptionTypeConverter(Type type) : base(type) { }
	}
}
