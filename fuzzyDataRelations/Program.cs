using System;
using System.Collections.Generic;
using System.IO;

namespace fuzzyDataRelations
{
    public class Program
    {
        static string filePath = "data\\";
        static string fileShell = "publish.ps1";
        public static void Main()
        {
            Console.WriteLine("Statring to run!");
            string fileName;
            string block;
            string word;
            int time=0;
            do
            {
                time++;
                word = GenerateRandomWord(time);
                block = GenerateRandomBlockFromData(word);
                fileName = word + ".cs";
            } while (File.Exists(fileName));
            File.WriteAllText(fileName, block);
            if (File.Exists(fileShell))
                File.Delete(fileShell);
            File.WriteAllText(fileShell, "" +
                "$runToday = Get-Random -Minimum 0 -Maximum 4 \n" +
                "If( $runToday -gt 1) { \n" +
                "	$number = Get-Random -Minimum 1 -Maximum 8 \n" +
                "	Write-Host $number \" times\" \n" +
                "	for($i=0 \n" +
                "     $i -le $number \n" +
                "     $i++){ \n" +
                "		$time = Get-Random -Minimum 1 -Maximum 8000 \n" +
                "		Write-Host $time + \" seconds\" \n" +
                "		Start-Sleep -s $time \n" +
                "		Add-Type -Path Program.cs, Sanitizer.cs  \n" +
                "		[fuzzyDataRelations.Program]::Main()  \n" +
                "		git add -A  \n" +
                "		git commit -a -m \"some tests + new DefaultBreakCollection class\"  \n" +
                "		git push origin master \n" +
                "	}  \n" +
                "} \n" +
                "");
        }

        private static string GenerateRandomWord(int time)
        {
            string result = string.Empty;
            List<string> words = GetSomeWordsFromData();
            Random random = new Random();
            int segments = random.Next(1+ time, 5+ time);
            for (int i = 0; i < segments; i++)
            {
                string chosenword= words[random.Next(0, words.Count - 1)];
                if(chosenword.Length>2)
                {
                    chosenword = chosenword[0].ToString().ToUpper() + chosenword.Substring(1);
                    result += chosenword;
                }
            }
            return result;
        }

        private static string GenerateRandomBlockFromData(string name)
        {
            string[] paths = Directory.GetFiles(filePath, "*.cs");
            Random random = new Random();
            int randomInt = random.Next(0, paths.Length - 1);
            string filename = Path.GetFileNameWithoutExtension(paths[randomInt]);
            string text = File.ReadAllText(paths[randomInt]);
            text = text.Replace(filename, name);
            return text;
        }

        private static List<string> GetSomeWordsFromData()
        {
            List<string> words = new List<string>();

            foreach (string path in Directory.GetFiles(filePath))
            {
                string text = File.ReadAllText(path);
                words.AddRange( Sanitizer.SanitizeString(text));
            }

            return words;
        }
    }
}