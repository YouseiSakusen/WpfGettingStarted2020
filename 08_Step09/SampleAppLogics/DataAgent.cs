using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Reactive.Bindings;

namespace PrismSample
{
	/// <summary>データI/O用のAgentを表します。</summary>
	public class DataAgent : IDataAgent
	{
		public Person GetPerson(int id)
		{
			return this.personRepository.GetPerson(id);
		}

		/// <summary>PersonSlimの内容を更新します。</summary>
		/// <param name="id">新たに取得するPersonのIDを表すint?。</param>
		/// <param name="person">更新内容を設定するPersonSlim。</param>
		/// <returns>非同期処理の実行結果を表すTask。</returns>
		public async Task UpdatePersonSlimAsync(int? id, PersonSlim person)
		{
			if (!id.HasValue)
				return;

			this.mapper.Map<PersonDto, PersonSlim>(await this.personRepository.GetPersonDtoAsync(), person);

			//var temp = await this.personRepository.GetPersonSlimAsync();

			//person.Id.Value = temp.Id.Value;
			//person.Name.Value = temp.Name.Value;
			//person.BirthDay.Value = temp.BirthDay.Value;
		}

		/// <summary>PersonSlimをPersonDtoに移し替えてXMLファイルに保存します。</summary>
		/// <param name="person">XMLファイルに保存するPersonSlim。</param>
		/// <returns>非同期処理を表すTask。</returns>
		public async Task SavePersonSlimAsync(PersonSlim person)
		{
			var personDto = this.mapper.Map<PersonSlim, PersonDto>(person);

			await this.personRepository.SavePersonAsync(personDto);
		}

		public void SavePerson(Person person)
		{
			this.personRepository.SavePerson(person);
		}

		public void UpdatePerson(int id, Person person)
		{
			throw new NotImplementedException();
		}

		/// <summary>マッピングのテストを実行します。</summary>
		/// <param name="person">VMと双方向でバインドしているPersonSlim。</param>
		public void TestMapper(PersonSlim person)
		{
			var src = this.personRepository.GetPersonDto();

			Debug.WriteLine("マッピング前src :" + src.ToString());
			Debug.WriteLine("マッピング前person :" + person.ToString());

			this.mapper.Map<PersonDto, PersonSlim>(src, person);

			person.CompareProperties();

			Debug.WriteLine("マッピング後src :" + src.ToString());
			Debug.WriteLine("マッピング後person :" + person.ToString());

			var revMap = new PersonDto();
			this.mapper.Map<PersonSlim, PersonDto>(person, revMap);


			//var dest = new PersonDto();

			//Debug.WriteLine("マッピング前src :" + src.ToString());
			//Debug.WriteLine("マッピング前dest :" + dest.ToString());

			//this.mapper.Map<PersonDto, PersonDto>(src, dest);

			//Debug.WriteLine("マッピング後src :" + src.ToString());
			//Debug.WriteLine("マッピング後dest :" + dest.ToString());

			//Debug.WriteLine("Mapp前");
			//person.CompareProperties();

			//this.mapper.Map<PersonDto, PersonSlim>(src, person);

			//Debug.WriteLine("Mapp後");
			//person.CompareProperties();
		}

		public async Task<List<PersonSlim>> GetAllCharactersAsync(PersonSlim searchCondition)
		{
			var dtoList = await this.personRepository.SearchCharactersAsync(searchCondition);
			
			return this.mapper.Map<List<PersonDto>, List<PersonSlim>>(dtoList);
		}

		public Task<List<PersonSlim>> GetFewCharactersAsync(PersonSlim searchCondition)
		{
			return Task.Run(() =>
			{
				var dtoList = this.personRepository.SearchFewCharacters(searchCondition);
				
				return this.mapper.Map<List<PersonDto>, List<PersonSlim>>(dtoList);
			});
		}

		public Task<int> GetCharacterIndexAsync(ObservableCollection<PersonSlim> persons, PersonSlim searchCondition)
		{
			return Task.Run(() =>
			{
				var resultIndeies = persons.Select((p, i) => new { Person = p, Index = i })
					.Where(x => Regex.IsMatch(x.Person.Name.Value, Regex.Escape(searchCondition.Name.Value)))
					.Select(x => x.Index)
					.ToList();
				if (resultIndeies.Count == 0)
					return -1;

				return resultIndeies.First();
			});
		}

		public Task<PersonSlim> GetRandomCharacterAsync()
		{
			return Task.Run(() =>
			{
				var tempDto = this.bleachAllCharacters[this.randomIndex.Next(3, this.bleachAllCharacters.Count - 1)];

				return this.mapper.Map<PersonDto, PersonSlim>(tempDto);
			});
		}

		private IPersonRepository personRepository = null;
		private IMapper mapper = null;
		private List<PersonDto> bleachAllCharacters = null;
		private Random randomIndex = new Random();

		/// <summary>コンストラクタ。</summary>
		/// <param name="personRepo">DIコンテナからインジェクションされるIPersonRepository。</param>
		public DataAgent(IPersonRepository personRepo, IMapper injectionMapper)
		{
			this.personRepository = personRepo;
			this.mapper = injectionMapper;

			this.bleachAllCharacters = this.personRepository.SearchCharacters(null);
		}

		#region IDisposable

		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: マネージド状態を破棄します (マネージド オブジェクト)
					this.personRepository?.Dispose();
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~DataAgent()
		// {
		//     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
