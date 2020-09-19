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
				c.CreateMap<int?, ReactivePropertySlim<int?>>().ConvertUsing<ReactivePropertySlimConverter<int?>>();
				c.CreateMap<ReactivePropertySlim<int?>, int?>().ConvertUsing<ToReactivePropertySlimConverter<int?>>();
				c.CreateMap<string, ReactivePropertySlim<string>>().ConvertUsing<ReactivePropertySlimConverter<string>>();
				c.CreateMap<ReactivePropertySlim<string>, string>().ConvertUsing<ToReactivePropertySlimConverter<string>>();
				c.CreateMap<DateTime?, ReactivePropertySlim<DateTime?>>().ConvertUsing<ReactivePropertySlimConverter<DateTime?>>();
				c.CreateMap<ReactivePropertySlim<DateTime?>, DateTime?>().ConvertUsing<ToReactivePropertySlimConverter<DateTime?>>();
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

	/// <summary>TをReactivePropertySlim<T>に変換します。</summary>
	/// <typeparam name="T">ReactivePropertySlimに指定する型パラメータと同じ型を表します。</typeparam>
	class ReactivePropertySlimConverter<T> : ITypeConverter<T, ReactivePropertySlim<T>>
	{
		public ReactivePropertySlim<T> Convert(T source, ReactivePropertySlim<T> destination, ResolutionContext context)
		{
			destination.Value = source;

			return destination;
		}
	}

	/// <summary>ReactivePropertySlim<T>をTに変換します。</summary>
	/// <typeparam name="T">ReactivePropertySlimに指定する型パラメータと同じ型を表します。</typeparam>
	class ToReactivePropertySlimConverter<T> : ITypeConverter<ReactivePropertySlim<T>, T>
	{
		public T Convert(ReactivePropertySlim<T> source, T destination, ResolutionContext context)
			=> source.Value;
	}
}
