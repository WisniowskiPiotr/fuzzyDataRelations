using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace fuzzyDataRelations
{
    static class Sanitizer
    {
        static private string _goodChars = string.Empty;
        static public string goodChars {
            get {
                if (string.IsNullOrWhiteSpace(_goodChars))
                    _goodChars = GetGoodChars();
                return _goodChars;
            }
        }

        static private string _lowercaseChars = string.Empty;
        static public string lowercaseChars
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_lowercaseChars))
                    _lowercaseChars = GetLowercaseChars();
                return _lowercaseChars;
            }
        }

        static private string _uppercaseChars = string.Empty;
        static public string uppercaseChars
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_uppercaseChars))
                    _uppercaseChars = GetCapitalChars();
                return _uppercaseChars;
            }
        }


        static public List<string> SanitizeString(string text)
        {
            List<string> result = new List<string>();
            char[] srcString = text.ToCharArray();
            for (int i = 0; i < srcString.Length; i++)
            {
                if (!goodChars.Contains(srcString[i]))
                {
                    srcString[i] = ' ';
                }
            }
            string processedtext = SplitCapitalLerretWords(new string(srcString), lowercaseChars, uppercaseChars);
            string[] splited = processedtext.Split(new char[] { ' ' });
            foreach (string s in splited)
            {
                int start = 0;
                int end = s.Length - 1;
                while (start < end && (s[start] == ' ' || s[start] == '-'))
                {
                    start++;
                }
                while (start < end && (s[end] == ' ' || s[end] == '-'))
                {
                    end--;
                }
                if (start < end)
                {
                    string word = (s.Substring(start, end - start + 1)).ToLowerInvariant();
                    // split if more than one -
                    if (word.IndexOf('-') != word.LastIndexOf('-'))
                    {
                        word = word.Replace('-', ' ');
                        string[] splited2 = word.Split(new char[] { ' ' });
                        foreach (string s2 in splited2)
                        {
                            result.Add(s2);
                        }
                    }
                    else
                    {
                        result.Add(word);
                    }
                }
            }
            return result;
        }

        static private string SplitCapitalLerretWords(string text, string lowercaseChars, string uppercaseChars)
        {
            if (text.Length < 2)
                return string.Empty;
            StringBuilder result = new StringBuilder();
            for (int i = 1; i < text.Length; i++)
            {
                result.Append(text[i - 1]);
                if (uppercaseChars.Contains(text[i]) && lowercaseChars.Contains(text[i - 1]))
                    result.Append(" ");
            }
            result.Append(text[text.Length - 1]);
            return result.ToString();
        }

        static private string GetGoodChars()
        {
            string preprocessedText = "";
            Regex rgx = new Regex("[\\p{L}-]");
            for (int i = 0; i < 65536; i++)
            {
                Char c = Convert.ToChar(i);
                Match m = rgx.Match("" + c);
                if (m.Success)
                    preprocessedText = preprocessedText + c;
            }
            return preprocessedText;
        }

        static private string GetCapitalChars()
        {
            string preprocessedText = "";
            Regex rgx = new Regex("[\\p{Lu}]");
            for (int i = 0; i < 65536; i++)
            {
                Char c = Convert.ToChar(i);
                Match m = rgx.Match("" + c);
                if (m.Success)
                    preprocessedText = preprocessedText + c;
            }
            return preprocessedText;
        }

        static private string GetLowercaseChars()
        {
            string preprocessedText = "";
            Regex rgx = new Regex("[\\p{Ll}]");
            for (int i = 0; i < 65536; i++)
            {
                Char c = Convert.ToChar(i);
                Match m = rgx.Match("" + c);
                if (m.Success)
                    preprocessedText = preprocessedText + c;
            }
            return preprocessedText;
        }
    }
}
