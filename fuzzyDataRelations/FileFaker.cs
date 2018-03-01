using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace fuzzyDataRelations
{
    class FileFaker
    {
        private static string filePath = "data\\";

        public static void GetRandomFile(out string fileName, out string fileContent)
        {
            fileName = GetRandomFileName();
            fileContent = File.ReadAllText(fileName);
        }

        public static string GetRandomFileName()
        {
            string[] paths = Directory.GetFiles(filePath, "*.cs");
            int randomInt = (new Random()).Next(0, paths.Length - 1);
            return paths[randomInt];//Path.GetFileNameWithoutExtension(paths[randomInt]);
        }

        public static string GenerateRandomWord(int time=0)
        {
            string result = string.Empty;
            List<string> words = GetSomeWordsFromData();
            Random random = new Random();
            int segments = random.Next(1 + time, 5 + time);
            for (int i = 0; i < segments; i++)
            {
                string chosenword = words[random.Next(0, words.Count - 1)];
                if (chosenword.Length > 2)
                {
                    chosenword = chosenword[0].ToString().ToUpper() + chosenword.Substring(1);
                    result += chosenword;
                }
            }
            return result;
        }

        public static List<string> GetSomeWordsFromData()
        {
            List<string> words = new List<string>();
            foreach (string path in Directory.GetFiles(filePath))
            {
                string text = File.ReadAllText(path);
                words.AddRange(Sanitizer.SanitizeString(text));
            }
            return words;
        }

        private static List<string> GetDeclarationsBeginnings = new List<string>( new string[]
            {
                "int ",
                "string ",
                "double ",
                "int[] ",
                "string[] ",
                "double[] "
            }
        );

        public string FileContent;
        public string FullFileName;

        public FileFaker(string fullFileName = "")
        {
            
            if (string.IsNullOrWhiteSpace(fullFileName))
            {
                GetRandomFile(out fullFileName,out FileContent);
            }
            if (string.IsNullOrWhiteSpace(FileContent))
            {
                FileContent = File.ReadAllText(fullFileName);
            }
            FullFileName = fullFileName;
        }

        public void Save()
        {
            File.WriteAllText(FullFileName, FileContent);
        }

        public void ReplaceRandomWordFromFile(string replacement)
        {
            string word = GetRandomWordFromFile();
            FileContent.Replace(word, replacement);
        }

        public string GetRandomWordFromFile()
        {
            string word = "";
            while (string.IsNullOrWhiteSpace(word))
            {
                int searchstart = (new Random()).Next(0, FileContent.Length/2);
                for (int i = 0; i < GetDeclarationsBeginnings.Count; i++)
                {
                    int index = FileContent.IndexOf(GetDeclarationsBeginnings[i], searchstart);
                    if (index > 0)
                    {
                        int spaceindex = FileContent.IndexOf(' ', index + GetDeclarationsBeginnings[i].Length);
                        word = FileContent.Substring(index + GetDeclarationsBeginnings[i].Length, spaceindex - (index + GetDeclarationsBeginnings[i].Length)).Trim();
                    }
                }
            }
            return word;
        }

        public string FakeFile()
        {
            string word = GenerateRandomWord();
            ReplaceRandomWordFromFile(word);
            Save();
            return word;
        }
    }
}
