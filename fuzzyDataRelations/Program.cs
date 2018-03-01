using System;
using System.Collections.Generic;
using System.IO;

namespace fuzzyDataRelations
{
    public class Program
    {
        static string fileShell = "publish.ps1";
        static string[] messages = {
            "some tests {0} class",
            "debuging {0} class",
            "working on {0}",
            "{0} class bug",
            "fixing {0}",
            "trying again {0}",
            "next staff {0}",
            "{0} gui",
            "{0} update",
        };

        public static void Main()
        {
            Console.WriteLine("Statring to run!");
            FileFaker file = new FileFaker();
            Console.WriteLine("Got File " + file.FullFileName);
            string word = file.FakeFile();
            Console.WriteLine("File Faked with word " + word);
            string message = GetRandomMessage(word);
            Console.WriteLine("Got message " + message);
            GeneratePSScript(message);
            Console.WriteLine("Finished. ");
        }

        private static string GetRandomMessage(string word)
        {
            return string.Format(messages[(new Random()).Next(0, messages.Length - 1)], word);
        }

        private static void GeneratePSScript(string message)
        {
            if (File.Exists(fileShell))
                File.Delete(fileShell);
            File.WriteAllText(fileShell, "" +
                //"	$number = 10000 \n" +
                //"	Write-Host $number \" times\" \n" +
                //"	for($i=0 \n" +
                //"     $i -le $number \n" +
                //"     $i++){ \n" +
                "       \n" +
                "		Add-Type -Path Program.cs, Sanitizer.cs, FileFaker.cs  \n" +
                "		[fuzzyDataRelations.Program]::Main()  \n" +
                "		git add -A  \n" +
                "		git commit -a -m \"" + message + "\" \n" +
                "		git push origin master \n" +
                "       \n" +
                "		$time = Get-Random -Minimum 100 -Maximum 8000 \n" +
                "		Write-Host $time + \" seconds\" \n" +
                //"		Start-Sleep -s $time \n" +
                //"	}  \n" +
                "");
        }
        
    }
}