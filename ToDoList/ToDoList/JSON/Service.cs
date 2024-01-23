using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace ToDoList.JSON
{
    public static class Service
    {
        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "baza.json");
        public static void WriteToFile(List<Task> list)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "");
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(path, json);
        }
        public static List<Task> GetFromFile()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "");
            string text = File.ReadAllText(path);
            if (text != "")
                return JsonSerializer.Deserialize<List<Task>>(text);
            return new List<Task>();
        }
    }
}
