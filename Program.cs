using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("-------------");
			Configuration config = new Configuration(1, "fadi", new[] {
				"123",
				"456"
			});
			List<string> fields = Analyse(config);

			Console.ReadLine();
		}
		private static List<string> Analyse(Object obj)
		{

			Console.WriteLine("start");

			List<string> fieldNamesAndTypes = StoreFieldsInfoIntoList(obj);

			for (int i = 0; i < fieldNamesAndTypes.Count; i++)
			{
				Console.WriteLine(fieldNamesAndTypes[i]);
			}

			string json = serializeToJson(fieldNamesAndTypes);

			Console.WriteLine(json);

			return fieldNamesAndTypes;
		}

		private static List<string> StoreFieldsInfoIntoList(object obj)
		{
			List<string> fieldNamesAndTypes = new List<string>();
			Type type = obj.GetType();
			FieldInfo[] fields = type.GetFields();
			Console.WriteLine("fields and their types: ");
			foreach (FieldInfo myField in fields)
			{
				// Console.WriteLine(myField.ToString());

				string fieldName = myField.Name;
				string fieldType = myField.FieldType.Name;
				string fieldValue = "unknown";

				fieldValue = getFieldsValues(obj, myField, fieldType);

				fieldNamesAndTypes.Add(fieldName);
				fieldNamesAndTypes.Add(fieldType);
				fieldNamesAndTypes.Add(fieldValue);

				// "{"Version":2,"DomainName":"www.training.com","IpAddresses":["192.168.1.8","192.168.1.2"]}"

			}

			return fieldNamesAndTypes;
		}

		private static string getFieldsValues(object obj, FieldInfo myField, string fieldType)
		{
			string fieldValue;
			if (fieldType.Equals("String[]"))
			{
				String[] array = (string[])(myField.GetValue(obj) as Array);

				for (int i = 0; i < array.Length; i++)
				{

					array[i] = "\"" + array[i] + "\"";

					if (i == 0)
					{
						array[i] = "[" + array[i];
					}
					if (i == array.Length - 1)
					{
						array[i] = array[i] + "]";

					}
				}

				fieldValue = string.Join(",", array);
				//fieldValue = String.Concat(array);
				//fieldValue = "ah";

			}
			else
			{
				fieldValue = myField.GetValue(obj).ToString();
			}

			return fieldValue;
		}

		private static string serializeToJson(List<string> fieldNamesAndTypes)
		{
			var json = "{";
			for (int i = 0; i < fieldNamesAndTypes.Count; i = i + 3)
			{

				if (fieldNamesAndTypes[i + 1].Equals("Int32"))
				{
					json += "\"" + fieldNamesAndTypes[i] + "\":" + fieldNamesAndTypes[i + 2];

				}
				else if (fieldNamesAndTypes[i + 1].Equals("String"))
				{
					json += "\"" + fieldNamesAndTypes[i] + "\":\"" + fieldNamesAndTypes[i + 2] + "\"";

				}
				else if (fieldNamesAndTypes[i + 1].Equals("String[]"))
				{
					json += "\"" + fieldNamesAndTypes[i] + "\":" + fieldNamesAndTypes[i + 2];

				}

				if (i != fieldNamesAndTypes.Count - 3)
				{
					json += ",";
				}

			}
			json += "}";
			return json;
		}
	}
}