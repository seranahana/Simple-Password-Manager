using Newtonsoft.Json;
using System.IO;

namespace SimplePM.Library.Serialization
{
    internal static class JsonSerializer
    {
        public static void WriteToJsonFile<T>(string fileName, T objectToWrite)
        {
            string jsonString = JsonConvert.SerializeObject(objectToWrite);
            File.WriteAllText(fileName, jsonString);
        }

        public static T ReadFromJsonFile<T>(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
