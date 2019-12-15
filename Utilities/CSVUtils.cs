using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Tools
{
    public static class CSVUtils
    {
        public static readonly string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        public static readonly string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        public static readonly char[] TRIM_CHARS = { '\"' };

        public static string CleanCSV(string text)
        {
            text = text.Replace("\"\"", "'");

            if (text.IndexOf("\"") > -1)
            {
                string clean = "";
                bool insideQuote = false;
                for (int j = 0; j < text.Length; j++)
                {
                    if (!insideQuote && text[j] == '\"')
                    {
                        insideQuote = true;
                    }
                    else if (insideQuote && text[j] == '\"')
                    {
                        insideQuote = false;
                    }
                    else if (insideQuote)
                    {
                        if (text[j] == '\n')
                        {
                            clean += "<br>";
                        }
                        else if (text[j] == ',')
                        {
                            clean += "<c>";
                        }
                        else
                        {
                            clean += text[j];
                        }
                    }
                    else
                    {
                        clean += text[j];
                    }
                }
                text = clean;
            }
            return text;
        }

        public static List<List<string>> ReadCSV(string file)
        {
            var data = Resources.Load(file) as TextAsset;
            return ParseCSV(data.text);
        }

        public static List<List<string>> ParseCSV(string text)
        {
            text = CleanCSV(text);

            var list = new List<List<string>>();
            var lines = Regex.Split(text, LINE_SPLIT_RE);

            if (lines.Length <= 1) return list;

            var header = Regex.Split(lines[0], SPLIT_RE);

            bool jumpedFirst = false;

            foreach (var line in lines)
            {
                if (!jumpedFirst)
                {
                    jumpedFirst = true;
                    continue;
                }
                var values = Regex.Split(line, SPLIT_RE);

                var entry = new List<string>();
                for (var j = 0; j < header.Length && j < values.Length; j++)
                {
                    var value = values[j];
                    value = DecodeSpecialCharacters(value);
                    entry.Add(value);
                }
                list.Add(entry);
            }
            return list;
        }

        public static string DecodeSpecialCharacters(string value)
        {
            value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "").Replace("<br>", "\n").Replace("<c>", ",");
            return value;
        }
    }
}
