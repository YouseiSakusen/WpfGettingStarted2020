using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PrismSample
{
    /// <summary>Person用のリポジトリを表します。</summary>
    public class PersonRepository : IPersonRepository
	{
		public void SavePerson(Person person)
		{

		}

		/// <summary>PersonDtoをXMLファイルに保存します。</summary>
		/// <param name="person">保存するPersonDto。</param>
		/// <returns>非同期処理を表すTask。</returns>
		public async Task SavePersonAsync(PersonDto person)
		{
			var xmlPath = Path.Combine(SampleUtilities.GetExecutingPath(), "Bleach.xml");

			await Task.Run(async () =>
			{
				await SampleUtilities.XmlSerializeToFile<PersonDto>(xmlPath, person);
			});
		}

		public async Task SavePersonSlimAsync(PersonSlim person)
		{
			//return Task.Run(() =>
			//{
			//	var dirPath = Path.Combine(SampleUtilities.GetExecutingPath(), "Bleach.xml");

			//	SampleUtilities.XmlSerializeToFile<PersonSlim>(dirPath, person);
			//});

			var dirPath = Path.Combine(SampleUtilities.GetExecutingPath(), "Bleach.xml");

			await Task.Run(() =>
			{
				//SampleUtilities.SerializeMessagePack<PersonSlim>(dirPath, person);
			});
		}

		/// <summary>XMLファイルからPersonDtoを取得します。</summary>
		/// <returns>XMLファイルから取得したPersonDto。</returns>
		public Task<PersonDto> GetPersonDtoAsync()
		{
			var task = Task.Run(() =>
			{
				var xmlPath = Path.Combine(SampleUtilities.GetExecutingPath(), "Bleach_src.xml");

				return SampleUtilities.XmlDeserializedFromFileAsync<PersonDto>(xmlPath);

				//return new PersonDto()
				//{
				//	Id = 1,
				//	Name = "黒崎一護",
				//	BirthDay = new DateTime(1998, 7, 15)
				//};
			});

			return task;
		}

		public Person GetPerson(int id)
		{
			return this.createSampleData();
		}

		public Task<Person> GetPersonAsync(int id)
		{
			var ret = Task.Run(() =>
			{
				return this.createSampleData();
			});

			return ret;
		}

		public Task<List<PersonDto>> SearchCharacters(PersonSlim condition)
		{
			return Task.Run(() =>
			{
				return new List<PersonDto>()
				{
					new PersonDto(1, "黒崎一護", "くろさき", "いちご", new DateTime(2001, 1, 14), "斬月"),
					new PersonDto(2, "朽木ルキア", "くちき", "ルキア", new DateTime(2001, 9, 3), "袖白雪"),
					new PersonDto(3, "井上織姫", "いのうえ", "おりひめ", new DateTime(2001, 11, 6), ""),
					new PersonDto(4, "石田雨竜", "いしだ", "うりゅう", new DateTime(2001, 4, 7), ""),
					new PersonDto(5, "茶渡泰虎", "さど", "やすとら", new DateTime(2001, 8, 31), ""),
					new PersonDto(6, "阿散井恋次", "あばらい", "れんじ", new DateTime(1998, 12, 10), "蛇尾丸"),
					new PersonDto(7, "黒崎 一心", "くろさき", "いっしん", new DateTime(1973, 12, 31), "剡月"),
					new PersonDto(8, "浦原喜助", "うらはら", "きすけ", new DateTime(1989, 1, 1), "紅姫"),
					new PersonDto(9, "四楓院 夜一", "しほういん", "よるいち", new DateTime(1989, 7, 11), ""),
					new PersonDto(10, "京楽 春水", "きょうらく", "しゅんすい", new DateTime(1980, 7, 7), "花天狂骨"),
					new PersonDto(11, "伊勢 七緒", "いせ", "ななお", new DateTime(2002, 1, 21), "神剣・八鏡剣"),
					new PersonDto(12, "山本 元柳斎 重國", "やまもと", "げんりゅうさいしげくに", new DateTime(1943, 11, 4), "流刃若火"),
					new PersonDto(13, "雀部 長次郎 忠息", "ささきべ", "ちょうじろうただおき", new DateTime(1941, 2, 11), "厳霊丸"),
					new PersonDto(14, "砕蜂", "ソイフォン", "", new DateTime(1996, 5, 5), ""),
					new PersonDto(15, "大前田 希千代", "おおまえだ", "まれちよ", new DateTime(1994, 3, 17), "五形頭"),
					new PersonDto(16, "鳳橋 楼十郎", "おおとりばし", "ろうじゅうろう", new DateTime(1991, 3, 27), "金沙羅"),
					new PersonDto(17, "吉良 イヅル", "きら", "イヅル", new DateTime(1993, 9, 10), "侘助"),
					new PersonDto(18, "市丸 ギン", "いちまる", "ギン", new DateTime(1993, 8, 2), "神鎗"),
					new PersonDto(19, "虎徹 勇音", "こてつ", "いさね", new DateTime(1996, 4, 1), "凍雲"),
					new PersonDto(20, "山田 花太郎", "やまだ", "はなたろう", new DateTime(1998, 4, 21), "瓠丸"),
					new PersonDto(21, "卯ノ花 烈", "うのはな", "れつ", new DateTime(1986, 5, 10), "肉雫唼"),
					new PersonDto(22, "平子 真子", "ひらこ", "しんじ", new DateTime(1990, 6, 3), "逆撫"),
					new PersonDto(23, "雛森 桃", "ひなもり", "もも", new DateTime(1999, 5, 29), "飛梅"),
					new PersonDto(24, "藍染惣右介", "あいぜん", "そうすけ", new DateTime(1988, 1, 31), "鏡花水月"),
					new PersonDto(25, "朽木 白哉", "くちき", "びゃくや", new DateTime(1993, 7, 18), "千本桜"),
					new PersonDto(26, "射場 鉄左衛門", "いば", "てつざえもん", new DateTime(1986, 8, 23), ""),
					new PersonDto(27, "狛村 左陣", "こまむら", "さじん", new DateTime(1977, 10, 10), "天譴"),
					new PersonDto(28, "愛川 羅武", "あいかわ", "らぶ", new DateTime(1990, 2, 3), "天狗丸"),
					new PersonDto(29, "矢胴丸 リサ", "やどうまる", "リサ", new DateTime(1994, 7, 30), "鉄漿蜻蛉"),
					new PersonDto(30, "六車 拳西", "むぐるま", "けんせい", new DateTime(1986, 8, 14), "断風"),
					new PersonDto(31, "檜佐木 修兵", "ひさぎ", "しゅうへい", new DateTime(1994, 4, 1), "風死"),
					new PersonDto(32, "久南 白", "くな", "ましろ", new DateTime(1993, 11, 13), ""),
					new PersonDto(33, "東仙 要", "とうせん", "かなめ", new DateTime(1990, 12, 20), "清虫"),
					new PersonDto(34, "日番谷 冬獅郎", "ひつがや", "とうしろう", new DateTime(2007, 9, 29), "氷輪丸"),
					new PersonDto(35, "松本 乱菊", "まつもと", "らんぎく", new DateTime(1994, 11, 19), "灰猫"),
					new PersonDto(36, "更木 剣八", "ざらき", "けんぱち", new DateTime(1986, 11, 9), "野晒"),
					new PersonDto(37, "斑目 一角", "まだらめ", "いっかく", new DateTime(1995, 9, 19), "鬼灯丸"),
					new PersonDto(38, "綾瀬川 弓親", "あやせがわ", "ゆみちか", new DateTime(1995, 2, 12), "藤孔雀"),
					new PersonDto(39, "草鹿 やちる", "くさじし", "やちる", new DateTime(2010, 3, 30), "三歩剣獣"),
					new PersonDto(40, "涅 ネム", "くろつち", "ネム", new DateTime(1998, 8, 1), ""),
					new PersonDto(41, "猿柿 ひよ里", "さるがき", "ひより", new DateTime(2004, 12, 21), "馘大蛇"),
					new PersonDto(42, "浮竹 十四郎", "うきたけ", "じゅうしろう", new DateTime(1983, 10, 27), "双魚理")
				};
			});
		}

		private Person createSampleData()
		{
			return new Person()
			{
				Id = 1,
				Name = "黒崎一護",
				//Kana = "くろさき　いちご",
				BirthDay = new DateTime(1998, 7, 15)
				//Sex = 1
			};
		}

		public PersonSlim GetPersonSlim(int id)
		{
			return new PersonSlim(1, "黒崎一護", new DateTime(1998, 7, 15));
		}

		/// <summary>PersonSlimを取得します。</summary>
		/// <returns>取得したPersonSlim。</returns>
		public Task<PersonSlim> GetPersonSlimAsync()
		{
			return Task.Run(() =>
			{
				return new PersonSlim(1, "黒崎一護", new DateTime(1998, 7, 15));
			});
		}

		/// <summary>PersonDtoを取得します。</summary>
		/// <returns>取得したPersonDto。</returns>
		public PersonDto GetPersonDto()
		{
			return new PersonDto()
			{
				Id = 1,
				Name = "黒崎一護",
				BirthDay = new DateTime(1998, 7, 15)
			};
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
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~PersonRepository()
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
