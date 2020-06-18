using System;
using System.Collections.Generic;
using System.Reflection;

namespace JsonSerializerProject
{
    public class Serializer
    {
        public static string serializeToJson(Object obj)
        {
            try
            {
                List<string> fieldNamesAndTypes = StoreFieldsInfoIntoList(obj);
                return serializeListToJson(fieldNamesAndTypes); ;
            }
            catch (Exception ex)
            {
                return "There was a problem serializing to json!";
            }
        }

        private static List<string> StoreFieldsInfoIntoList(object obj)
        {
            List<string> fieldNamesAndTypes = new List<string>();
            FieldInfo[] fields = obj.GetType().GetFields();
            foreach (FieldInfo myField in fields)
            {
                string fieldName = myField.Name;
                string fieldType = myField.FieldType.Name;
                string fieldValue = getFieldValue(obj, myField, fieldType);

                fieldNamesAndTypes.Add(fieldName);
                fieldNamesAndTypes.Add(fieldType);
                fieldNamesAndTypes.Add(fieldValue);
            }

            return fieldNamesAndTypes;
        }

        private static string getFieldValue(object obj, FieldInfo myField, string fieldType)
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

            }
            else
            {
                fieldValue = myField.GetValue(obj).ToString();
            }

            return fieldValue;
        }

        private static string serializeListToJson(List<string> fieldNamesAndTypes)
        {
            var json = "{";
            for (int i = 0; i < fieldNamesAndTypes.Count; i += 3)
            {

                switch (fieldNamesAndTypes[i + 1])
                {
                    case ("Int32"):
                    case ("String[]"):

                        json += "\"" + fieldNamesAndTypes[i] + "\":" + fieldNamesAndTypes[i + 2];

                        break;

                    case ("String"):
                        json += "\"" + fieldNamesAndTypes[i] + "\":\"" + fieldNamesAndTypes[i + 2] + "\"";
                        break;
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