using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PrismSample
{
	public static class SampleUtilities
	{
		public static string GetExecutingPath()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		}

		public static async Task SerializedJsonToFileAsync<T>(string jsonPath, T data)
		{
			using (var stream = File.Create(jsonPath))
			{
				var option = new JsonSerializerOptions()
				{
					IgnoreNullValues = true,
					WriteIndented = true
				};

				await JsonSerializer.SerializeAsync<T>(stream, data, option);
			}
		}

		public static async Task<T> DeserializedJsonFromFileAsync<T>(string jsonPath)
		{
			using (var reader = File.OpenRead(jsonPath))
			{
				return await JsonSerializer.DeserializeAsync<T>(reader);
			}
		}

		public async static Task XmlSerializeToFile<T>(string xmlPath, T data)
		{
			await using (var writer = new StreamWriter(xmlPath, false, Encoding.UTF8))
			{
				var serializer = new XmlSerializer(typeof(T));

				serializer.Serialize(writer, data);
				await writer.FlushAsync();
			}
		}

		public static T XmlDeserializedFromFileAsync<T>(string xmlPath) where T: class
		{
			using (var reader = new StreamReader(xmlPath, Encoding.UTF8))
			{
				var serializer = new XmlSerializer(typeof(T));

				return (T)serializer.Deserialize(reader);
			}
		}

		/// <summary>
		/// ファイルへシリアライズします。
		/// </summary>
		/// <typeparam name="T">シリアライズするオブジェクトの型を表します。</typeparam>
		/// <param name="xmlFilePath">シリアライズするXMLファイルのパスを表します。</param>
		/// <param name="data">シリアライズするオブジェクトを表すT。</param>
		public static void SerializeToFile<T>(string xmlFilePath, T data) where T : class
		{
			var dirPath = Path.GetDirectoryName(xmlFilePath);
			if (!Directory.Exists(dirPath))
				return;

			var writerSettings = new XmlWriterSettings()
			{
				Encoding = new UTF8Encoding(false),
				Indent = true
			};
			
			using (var writer = XmlWriter.Create(xmlFilePath, writerSettings))
			{
				var serializer = new DataContractSerializer(typeof(T));
				serializer.WriteObject(writer, data);
			}
		}
	}
}
