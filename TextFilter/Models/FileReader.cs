using System;
using System.IO;
using Newtonsoft.Json;

namespace TextFilter.Models
{
    public class FileReader : ReaderAbstract
    {
        private readonly PersonalSettings _settings;
        public FileReader()
        {
            _settings = JsonConvert.DeserializeObject<PersonalSettings>(File.ReadAllText("settings.json"));

        }
        public virtual string GetFilePath()
        {
            string path;
            Console.WriteLine("Please drag and drop the text file in to console to process, or press enter to continue with the included default file");
            var input = Console.ReadLine();
            if (input != null && !input.Equals(string.Empty))
            {
                path = input.Trim('"');
            }
            else
            {
                path = _settings.File;
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            return path;
        }

        public override void ReadLines()
        {
            string path = GetFilePath();

            using var reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                OnLineRead(line);
            }
        }
    }
}