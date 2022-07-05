using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleUtilities
{
    /// <summary>
    /// A class for printing Lists
    /// </summary>
    public static class ConsoleLists
    {
        private static int ConsoleWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        /// <summary>
        /// Print a List With 1. Colum being the "What it is" and the second the value
        /// if the string gets loger then the console it automaticly gets formatet at the last space
        /// Key is ment as Kategory
        /// Value is ment as valu or info to that category
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the list is startet printing</param>
        /// <param name="list">The list</param>
        public static void PrintList<TKey, TValue> (int line, Dictionary<TKey, TValue> list)
        {
            int longestKey = 0;
            foreach (TKey key in list.Keys)
            {
                if (key.ToString().Length > longestKey)
                    longestKey = key.ToString().Length;
            }
            int valueLength = ConsoleWidth - longestKey - 8;
            int index = -1;
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                index++;
                index = ConsoleUtilities.NormalizeLineIndex(index);
                ConsoleUtilities.ReplaceLine(line + index, $" +{ConsoleUtilities.GetCharakters(longestKey + 2, '-')}+{ConsoleUtilities.GetCharakters(valueLength + 2, '-')}+");
                bool first = true;
                foreach (string s in Conversions.ChopValue(pair.Value.ToString(), valueLength))
                {
                    index++;
                    if (first)
                    {
                        first = false;
                        ConsoleUtilities.ReplaceLine(line + index, $" | {pair.Key}{ConsoleUtilities.GetSpaces(longestKey - pair.Key.ToString().Length)} | {s}{ConsoleUtilities.GetSpaces(valueLength - s.Length)} |");
                    }
                    else
                    {
                        ConsoleUtilities.ReplaceLine(line + index, $" | {ConsoleUtilities.GetSpaces(longestKey)} | {s}{ConsoleUtilities.GetSpaces(valueLength - s.Length)} |");
                    }
                }
            }
            ConsoleUtilities.ReplaceLine(line + index + 1, $" +{ConsoleUtilities.GetCharakters(longestKey + 2, '-')}+{ConsoleUtilities.GetCharakters(valueLength + 2, '-')}+");
        }

        /// <summary>
        /// Print a dictionary like a list 
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">the line to start printing at</param>
        /// <param name="list">the dictionary thats printet</param>
        /// <param name="style">Determins how the List looks</param>
        public static void PrintList<TKey, TValue> (int line, Dictionary<TKey, TValue> list, TableLook style)
        {
            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int longestKey = 0;
            foreach (TKey key in list.Keys)
            {
                if (key.ToString().Length > longestKey)
                    longestKey = key.ToString().Length;
            }
            int valueLength = ConsoleWidth - longestKey - 8;
            int index = -1;
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                index++;
                index = ConsoleUtilities.NormalizeLineIndex(index);
                ConsoleUtilities.ReplaceLine(line + index, $" {crosing}{ConsoleUtilities.GetCharakters(longestKey + 2, horizontal)}{crosing}{ConsoleUtilities.GetCharakters(valueLength + 2, horizontal)}{crosing}");
                bool first = true;
                foreach (string s in Conversions.ChopValue(pair.Value.ToString(), valueLength))
                {
                    index++;
                    if (first)
                    {
                        first = false;
                        ConsoleUtilities.ReplaceLine(line + index, $" {vertical} {pair.Key}{ConsoleUtilities.GetSpaces(longestKey - pair.Key.ToString().Length)} {vertical} {s}{ConsoleUtilities.GetSpaces(valueLength - s.Length)} {vertical}");
                    }
                    else
                    {
                        ConsoleUtilities.ReplaceLine(line + index, $" {vertical} {ConsoleUtilities.GetSpaces(longestKey)} {vertical} {s}{ConsoleUtilities.GetSpaces(valueLength - s.Length)} {vertical}");
                    }
                }
            }
            ConsoleUtilities.ReplaceLine(line + index + 1, $" {crosing}{ConsoleUtilities.GetCharakters(longestKey + 2, horizontal)}{crosing}{ConsoleUtilities.GetCharakters(valueLength + 2, horizontal)}{crosing}");
        }

        /// <summary>
        /// Prints a table like a list
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">the table thats printet</param>
        public static void PrintList (int line, DataTable table)
        {
            if (table.Columns.Count == 0)
                return;
            int spacePerColumn = (ConsoleWidth - (table.Columns.Count * 3 + 2)) / table.Columns.Count;
            List<string>[] headers = new List<string>[table.Columns.Count];
            int logestHeader = 0;
            string seperationLine = " +";
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(spacePerColumn + 2, '-') + "+";
                headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, spacePerColumn);
            }
            foreach (List<string> header in headers)
            {
                if(header.Count > logestHeader)
                    logestHeader = header.Count;
            }
            int index = line;
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            for (int i = 0 ; i < logestHeader ; i++)
            {
                string s = " |";
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    if (i < headers[j].Count)
                    {
                        s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(spacePerColumn - headers[j][i].Length)} |";
                    }
                    else
                    {
                        s += $" {ConsoleUtilities.GetSpaces(spacePerColumn)} |";
                    }
                }
                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, s);
            }
            index = ConsoleUtilities.NormalizeLineIndex(index + 1);
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            foreach (DataRow row in table.Rows)
            {
                List<string>[] vals = new List<string>[table.Columns.Count];
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    vals[i] = Conversions.ChopValue(row[i].ToString(), spacePerColumn);
                }
                int longest = 0;
                foreach (List<string> val in vals)
                {
                    if(val.Count > longest)
                        longest = val.Count;
                }
                for (int i = 0 ; i < longest ; i++)
                {
                    StringBuilder sb = new(" |");
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < vals[j].Count)
                        {
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(spacePerColumn - vals[j][i].Length)} |");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(spacePerColumn)} |");
                        }
                    }
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, sb.ToString());
                }
                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, seperationLine);
            }
        }

        /// <summary>
        /// Prints a table not like a Table but each row like a list
        /// </summary>
        /// <param name="line">The line to start printing at</param>
        /// <param name="table">The table thats printet</param>
        /// <param name="style">How The list looks</param>
        public static void PrintList (int line, DataTable table, TableLook style)
        {
            if (table.Columns.Count == 0)
                return;
            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int spacePerColumn = ( ConsoleWidth - ( table.Columns.Count * 3 + 2 ) ) / table.Columns.Count;
            List<string>[] headers = new List<string>[table.Columns.Count];
            int logestHeader = 0;
            string seperationLine = $" {crosing}";
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(spacePerColumn + 2, horizontal) + crosing;
                headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, spacePerColumn);
            }
            foreach (List<string> header in headers)
            {
                if (header.Count > logestHeader)
                    logestHeader = header.Count;
            }
            int index = line;
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            for (int i = 0 ; i < logestHeader ; i++)
            {
                string s = $" {vertical}";
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    if (i < headers[j].Count)
                    {
                        s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(spacePerColumn - headers[j][i].Length)} {vertical}";
                    }
                    else
                    {
                        s += $" {ConsoleUtilities.GetSpaces(spacePerColumn)} {vertical}";
                    }
                }
                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, s);
            }
            index = ConsoleUtilities.NormalizeLineIndex(index + 1);
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            foreach (DataRow row in table.Rows)
            {
                List<string>[] vals = new List<string>[table.Columns.Count];
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    vals[i] = Conversions.ChopValue(row[i].ToString(), spacePerColumn);
                }
                int longest = 0;
                foreach (List<string> val in vals)
                {
                    if (val.Count > longest)
                        longest = val.Count;
                }
                for (int i = 0 ; i < longest ; i++)
                {
                    StringBuilder sb = new($" {vertical}");
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < vals[j].Count)
                        {
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(spacePerColumn - vals[j][i].Length)} {vertical}");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(spacePerColumn)} {vertical}");
                        }
                    }
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, sb.ToString());
                }
                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, seperationLine);
            }
        }

        private static class Conversions
        {
            internal static (char vertical, char horizontal, char crosing) GetCharForStyle (TableLook style)
            {
                return style switch
                {
                    TableLook.Default => ('|', '-', '+'),
                    TableLook.Lines => ('|', '-', '+'),
                    TableLook.HashTag => ('#', '#', '#'),
                    TableLook.Solid => ('█', '█', '█'),
                    TableLook.DoubleLines => ('║', '═', '╬'),
                    _ => ('|', '-', '+'),
                };
            }

            internal static List<string> ChopValue (string value, int valueLength)
            {
                string rest = value;
                List<string> list = new();
                int limit = 0;
                while (limit++ < 100)
                {
                    if (FindLastSpaceBeforeIndex(rest, valueLength, out int index))
                    {
                        list.Add(rest[..index]);
                        rest = rest[(index + 1)..];
                    }
                    else
                    {
                        if (index == -1)
                        {
                            list.Add(rest[..( valueLength - 1 )] + "-");
                            rest = rest[( valueLength - 1 )..];
                        }
                        else
                        {
                            list.Add(rest);
                            break;
                        }
                    }
                }

                return list;
            }

            private static bool FindLastSpaceBeforeIndex (string s, int index, out int foundIndex)
            {
                if (index >= s.Length)
                {
                    foundIndex = -2;
                    return false;
                }

                for (int i = index ; i >= 0 ; i--)
                {
                    if (s[i] == ' ')
                    {
                        foundIndex = i;
                        return true;
                    }
                }

                foundIndex = -1;
                return false;
            }
        }
    }
}
