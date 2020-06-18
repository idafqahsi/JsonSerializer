using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace JsonSerializer
{
	public class Serializer
	{ 
		private static List<string> NewMethod(Object obj)
		{
			List<string> fieldNamesAndTypes = new List<string>();

			Console.WriteLine("start");
			Type type = obj.GetType();
			FieldInfo[] fields = type.GetFields();
			Console.WriteLine("fields and their types: ");
			foreach (FieldInfo myField in fields)
			{
				// Console.WriteLine(myField.ToString());

				string fieldName = myField.Name;
				string fieldType = myField.FieldType.Name;
				string fieldValue = "unknown";

				if (fieldType.Equals("String[]"))
				{
					// fieldValue = "xd";
					//  var arr = myField.GetValue(obj);

					String[] array = (string[])(myField.GetValue(obj) as Array);

					foreach (string s in array)
					{
						//	Console.WriteLine(s);
					}

					fieldValue = string.Join(",", array);
					//fieldValue = String.Concat(array);
					//fieldValue = "ah";

				}
				else
				{
					fieldValue = myField.GetValue(obj).ToString();
				}

				fieldNamesAndTypes.Add(fieldName);
				fieldNamesAndTypes.Add(fieldValue);

				// "{"Version":2,"DomainName":"www.training.com","IpAddresses":["192.168.1.8","192.168.1.2"]}"

			}

			for (int i = 0; i < fieldNamesAndTypes.Count; i++)
			{
				Console.WriteLine(fieldNamesAndTypes[i]);
			}

			var json = "";

			for (int i = 0; i < fieldNamesAndTypes.Count; i = i + 2)
			{

				json += "{\"" + fieldNamesAndTypes[i] + "\":" + fieldNamesAndTypes[i + 1] + "\",";

			}

			Console.WriteLine(json);

			return fieldNamesAndTypes;
		}
	}
}