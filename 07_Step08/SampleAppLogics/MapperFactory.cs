using System;
using AutoMapper;
using Reactive.Bindings;

namespace PrismSample
{
	/// <summary>Mapperを作成します。</summary>
	public static class MapperFactory
	{
		/// <summary>Mapperを取得します。</summary>
		/// <returns>生成したIMapper。</returns>
		public static IMapper GetMapper()
		{
			var conf = new MapperConfiguration(c =>
			{
				c.CreateMap<int?, ReactivePropertySlim<int?>>().ConvertUsing<RpSlimNullableIntConverter>();
				c.CreateMap<ReactivePropertySlim<int?>, int?>().ConvertUsing<ToRpSlimNullableIntConverter>();
				c.CreateMap<string, ReactivePropertySlim<string>>().ConvertUsing<RpSlimStringConverter>();
				c.CreateMap<ReactivePropertySlim<string>, string>().ConvertUsing<ToRpSlimStringConverter>();
				c.CreateMap<DateTime?, ReactivePropertySlim<DateTime?>>().ConvertUsing<RpSlimNullableDateTimeConverter>();
				c.CreateMap<ReactivePropertySlim<DateTime?>, DateTime?>().ConvertUsing<ToRpSlimNullableDateTimeConverter>();
				c.CreateMap<PersonDto, PersonSlim>()
				 .ReverseMap();
				c.CreateMap<PersonDto, PersonDto>();
				c.CreateMap<PersonDto, PlanePerson>()
				 .ForMember(d => d.Sex, o => o.Ignore());
			});

			conf.AssertConfigurationIsValid();

			return conf.CreateMapper();
		}
	}

	/// <summary>int?をReactivePropertySlim<int?>にコンバートします。</summary>
	class RpSlimNullableIntConverter : ITypeConverter<int?, ReactivePropertySlim<int?>>
	{
		public ReactivePropertySlim<int?> Convert(int? source, ReactivePropertySlim<int?> destination, ResolutionContext context)
		{
			destination.Value = source;

			return destination;
		}
	}

	/// <summary>ReactivePropertySlim<int?>をint?にコンバートします。</summary>
	class ToRpSlimNullableIntConverter : ITypeConverter<ReactivePropertySlim<int?>, int?>
	{
		public int? Convert(ReactivePropertySlim<int?> source, int? destination, ResolutionContext context)
			=> source.Value;
	}

	/// <summary>stringをReactivePropertySlim<string>にコンバートします。</summary>
	class RpSlimStringConverter : ITypeConverter<string, ReactivePropertySlim<string>>
	{
		public ReactivePropertySlim<string> Convert(string source, ReactivePropertySlim<string> destination, ResolutionContext context)
		{
			destination.Value = source;

			return destination;
		}
	}

	/// <summary>ReactivePropertySlim<string>をstringにコンバートします。</summary>
	class ToRpSlimStringConverter : ITypeConverter<ReactivePropertySlim<string>, string>
	{
		public string Convert(ReactivePropertySlim<string> source, string destination, ResolutionContext context)
			=> source.Value;
	}

	/// <summary>DateTime?をReactivePropertySlim<DateTime?>にコンバートします。</summary>
	class RpSlimNullableDateTimeConverter : ITypeConverter<DateTime?, ReactivePropertySlim<DateTime?>>
	{
		public ReactivePropertySlim<DateTime?> Convert(DateTime? source, ReactivePropertySlim<DateTime?> destination, ResolutionContext context)
		{
			destination.Value = source;

			return destination;
		}
	}

	/// <summary>ReactivePropertySlim<DateTime?>をDateTime?にコンバートします。</summary>
	class ToRpSlimNullableDateTimeConverter : ITypeConverter<ReactivePropertySlim<DateTime?>, DateTime?>
	{
		public DateTime? Convert(ReactivePropertySlim<DateTime?> source, DateTime? destination, ResolutionContext context)
			=> source.Value;
	}
}
