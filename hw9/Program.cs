using System.Text.Json;
using System.Xml;
using static System.Text.Json.JsonElement;

namespace hw9
{
	public class Program
	{
		static void Main(string[] args)
		{

			string json = """{"users":{"user1":{"Name":"Ivan","Surname":"Ivanov","Age":34},"user2":{"Name":"Petr","Surname":"Petrov","Age":40}}}""";
			using (XmlWriter writer = XmlWriter.Create("myXml.xml"))
			{
				Rec(json, writer);

			}
			Console.WriteLine("End");
			
		}
		static void Rec(string json, XmlWriter writer)
		{
			using (JsonDocument jDoc = JsonDocument.Parse(json))
			{
				foreach (JsonProperty item in jDoc.RootElement.EnumerateObject())
				{
					writer.WriteStartElement(item.Name);
					if (isRoot(item))
					{
						Rec(item.Value.ToString(), writer);

					}
					else
					{
						writer.WriteValue(item.Value.ToString());
					}
					writer.WriteEndElement();
				}
			}
		}


		static bool isRoot(JsonProperty prop)
		{
			if (prop.Value.ValueKind == JsonValueKind.Object)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
