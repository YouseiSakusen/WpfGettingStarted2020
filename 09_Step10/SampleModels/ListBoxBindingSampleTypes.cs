using System.ComponentModel;
using elf.Converters.Attributes;

namespace ListBoxBindingSamle
{
	[TypeConverter(typeof(EnumDescriptionTypeConverter))]
	public enum 所属組織
	{
		[Description("空座第一高校")]
		空座第一高校_001,
		[Description("現世")]
		現世_002,
		[Description("浦原商店")]
		浦原商店_003,
		尸魂界_010,
		[Description("護廷十三隊")]
		護廷十三隊_011,
		王属特務零番隊_012,
		滅却師_020,
		星十字騎士団_021,
		見えざる帝国_022,
		虚圏_030,
		完現術者_040,
		仮面の軍勢_050,
		バウント_060
	}
}