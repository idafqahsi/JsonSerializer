using System;
using System.Collections.Generic;
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
            List<string> fields = NewMethod(config);




            Console.ReadLine();
        }
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

                if (fieldType == "String[]")
                {

                    //var x = myField.GetValue(obj);
                    //string[] sRes = x.OfType<string>().ToArray();
                    //                    foreach (var value in sRes)
                    //                    {
                    //                       Console.WriteLine(value);
                    //                   }
                }
                else
                {
                    fieldType = myField.GetValue(obj).ToString();
                }

                fieldNamesAndTypes.Add(fieldName);
                fieldNamesAndTypes.Add(fieldType);
                fieldNamesAndTypes.Add(fieldValue);
                //fieldNamesAndTypes.Add(myField.GetValue(obj));

            }

            for (int i = 0; i < fieldNamesAndTypes.Count; i++)
            {
                Console.WriteLine(fieldNamesAndTypes[i]);
            }
            return fieldNamesAndTypes;
        }
    }
}