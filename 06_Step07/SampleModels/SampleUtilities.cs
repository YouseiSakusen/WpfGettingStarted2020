using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MessagePack;
using MessagePack.ReactivePropertyExtension;
using MessagePack.Resolvers;

namespace PrismSample
{
	public static class SampleUtilities
	{
		public static string GetExecutingPath()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		}

		public static void InitializeMessagePack()
		{
			var resolver = CompositeResolver.Create(
				ReactivePropertyResolver.Instance,
				StandardResolverAllowPrivate.Instance,
				StandardResolver.Instance
				);

			MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(resolver);
		}

		public static void SerializeMessagePack<T>(string jsonPath, T data)
		{
			//var jsonText = MessagePackSerializer.SerializeToJson<T>(data);

			using (var writer = new StreamWriter(jsonPath))
			{
				MessagePackSerializer.SerializeToJson<T>(writer, data);
			}
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

		public static void XmlSerializeToFile<T>(string xmlPath, T data)
		{
			using (var writer = new StreamWriter(xmlPath, false, Encoding.UTF8))
			{
				var serializer = new XmlSerializer(typeof(T));

				serializer.Serialize(writer, data);
				writer.Flush();
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
