using System;
using System.Windows.Markup;

namespace elf.Views
{
	/// <summary>Enumをリスト表示するためのマークアップ拡張を表します。</summary>
	public class EnumBindingSourceExtension : MarkupExtension
	{
		/// <summary>表示するEnumの型を取得・設定します。</summary>
		public Type EnumType { get; private set; }

		/// <summary>このマークアップ拡張が返す値を提供します。</summary>
		/// <param name="serviceProvider">サービスプロバイダを表すIServiceProvider。</param>
		/// <returns>このマークアップ拡張が返す値を表すobject。</returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
			=> Enum.GetValues(this.EnumType);

		/// <summary>コンストラクタ。</summary>
		/// <param name="enumType">このマークアップ拡張でリスト表示するEnumのType。</param>
		public EnumBindingSourceExtension(Type enumType)
		{
			if ((enumType is null) || (!enumType.IsEnum))
				throw new NullReferenceException($"{nameof(enumType)}がNull又はEnum型ではありません。");

			this.EnumType = enumType;
		}
	}
}
