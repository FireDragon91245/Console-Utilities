using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            int sizePerColumn = ( ConsoleWidth - 9 ) / 2;
            int index = line;
            string septerationLine = $" +{ConsoleUtilities.GetCharakters(sizePerColumn + 2, '-')}+{ConsoleUtilities.GetCharakters(sizePerColumn + 2, '-')}+ ";

            ConsoleUtilities.ReplaceLine(index, septerationLine);
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                List<string>[] valus = { Conversions.ChopValue(pair.Key.ToString(), sizePerColumn), Conversions.ChopValue(pair.Value.ToString(), sizePerColumn) };
                int longestValue = valus[0].Count > valus[1].Count ? valus[0].Count : valus[1].Count;

                for (int i = 0 ; i < longestValue ; i++)
                {
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, $" | {( i > valus[0].Count - 1 ? ConsoleUtilities.GetSpaces(sizePerColumn) : valus[0][i] + ConsoleUtilities.GetSpaces(sizePerColumn - valus[0][i].Length) )} | {( i > valus[1].Count ? ConsoleUtilities.GetSpaces(sizePerColumn) : valus[1][i] + ConsoleUtilities.GetSpaces(sizePerColumn - valus[1][i].Length) )} | ");
                }

                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, septerationLine);
            }
        }

        /// <summary>
        /// Print a Dictionary as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">the line to start printing at</param>
        /// <param name="list">The DataTable to print</param>
        public static void PrintSmartList<TKey, TValue> (int line, Dictionary<TKey, TValue> list)
        {
            int[] columnCharCount = new int[2];
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                columnCharCount[0] += pair.Key.ToString().Length;
                columnCharCount[1] += pair.Value.ToString().Length;
            }
            int[] collSize = { columnCharCount[0] * (ConsoleWidth - 9) / (columnCharCount[0] + columnCharCount[1]), columnCharCount[1] * (ConsoleWidth - 9) / ( columnCharCount[0] + columnCharCount[1] ) };
            for (int i = 0 ; i < 2 ; i++)
            {
                if (collSize[i] < 2)
                {
                    collSize[i] = 2;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= 2;
                    }
                }
            }
            int index = line;
            string septerationLine = $" +{ConsoleUtilities.GetCharakters(collSize[0] + 2, '-')}+{ConsoleUtilities.GetCharakters(collSize[1] + 2, '-')}+ ";

            ConsoleUtilities.ReplaceLine(index, septerationLine);
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                List<string>[] valus = { Conversions.ChopValue(pair.Key.ToString(), collSize[0]), Conversions.ChopValue(pair.Value.ToString(), collSize[1]) };
                int longestValue = valus[0].Count > valus[1].Count ? valus[0].Count : valus[1].Count;

                for (int i = 0 ; i < longestValue ; i++)
                {
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, $" | {( i > valus[0].Count - 1 ? ConsoleUtilities.GetSpaces(collSize[0]) : valus[0][i] + ConsoleUtilities.GetSpaces(collSize[0] - valus[0][i].Length) )} | {( i > valus[1].Count ? ConsoleUtilities.GetSpaces(collSize[1]) : valus[1][i] + ConsoleUtilities.GetSpaces(collSize[1] - valus[1][i].Length) )} | ");
                }

                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, septerationLine);
            }
        }

        /// <summary>
        /// Print a Dictionary as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">the line to start printing at</param>
        /// <param name="list">The DataTable to print</param>
        /// <param name="style">How the list looks</param>
        public static void PrintSmartList<TKey, TValue> (int line, Dictionary<TKey, TValue> list, TableLook style)
        {
            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int[] columnCharCount = new int[2];
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                columnCharCount[0] += pair.Key.ToString().Length;
                columnCharCount[1] += pair.Value.ToString().Length;
            }
            int[] collSize = { columnCharCount[0] * ( ConsoleWidth - 9 ) / ( columnCharCount[0] + columnCharCount[1] ), columnCharCount[1] * ( ConsoleWidth - 9 ) / ( columnCharCount[0] + columnCharCount[1] ) };
            for (int i = 0 ; i < 2 ; i++)
            {
                if (collSize[i] < 2)
                {
                    collSize[i] = 2;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= 2;
                    }
                }
            }
            int index = line;
            string septerationLine = $" {crosing}{ConsoleUtilities.GetCharakters(collSize[0] + 2, horizontal)}{crosing}{ConsoleUtilities.GetCharakters(collSize[1] + 2, horizontal)}{crosing} ";

            ConsoleUtilities.ReplaceLine(index, septerationLine);
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                List<string>[] valus = { Conversions.ChopValue(pair.Key.ToString(), collSize[0]), Conversions.ChopValue(pair.Value.ToString(), collSize[1]) };
                int longestValue = valus[0].Count > valus[1].Count ? valus[0].Count : valus[1].Count;

                for (int i = 0 ; i < longestValue ; i++)
                {
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, $" {vertical} {( i > valus[0].Count - 1 ? ConsoleUtilities.GetSpaces(collSize[0]) : valus[0][i] + ConsoleUtilities.GetSpaces(collSize[0] - valus[0][i].Length) )} {vertical} {( i > valus[1].Count ? ConsoleUtilities.GetSpaces(collSize[1]) : valus[1][i] + ConsoleUtilities.GetSpaces(collSize[1] - valus[1][i].Length) )} {vertical} ");
                }

                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, septerationLine);
            }
        }

        /// <summary>
        /// Print a Dictionary as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">the line to start printing at</param>
        /// <param name="list">The DataTable to print</param>
        /// <param name="style">How the list looks</param>
        /// <param name="minColumnWidth">The minimum with that a colum can reach during automatic resize, if to smal gets defaultet to 2 if to large it gets defaultet to ( ConsoleWidth - 9 ) / 2</param>
        public static void PrintSmartList<TKey, TValue> (int line, Dictionary<TKey, TValue> list, TableLook style, int minColumnWidth)
        {
            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            if(minColumnWidth < 2)
                minColumnWidth = 2;
            if (minColumnWidth > ( ConsoleWidth - 9 ) / 2)
                minColumnWidth = ( ConsoleWidth - 9 ) / 2;
            int[] columnCharCount = new int[2];
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                columnCharCount[0] += pair.Key.ToString().Length;
                columnCharCount[1] += pair.Value.ToString().Length;
            }
            int[] collSize = { columnCharCount[0] * ( ConsoleWidth - 9 ) / ( columnCharCount[0] + columnCharCount[1] ), columnCharCount[1] * ( ConsoleWidth - 9 ) / ( columnCharCount[0] + columnCharCount[1] ) };
            for (int i = 0 ; i < 2 ; i++)
            {
                if (collSize[i] < minColumnWidth)
                {
                    collSize[i] = minColumnWidth;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= minColumnWidth;
                    }
                }
            }
            int index = line;
            string septerationLine = $" {crosing}{ConsoleUtilities.GetCharakters(collSize[0] + 2, horizontal)}{crosing}{ConsoleUtilities.GetCharakters(collSize[1] + 2, horizontal)}{crosing} ";

            ConsoleUtilities.ReplaceLine(index, septerationLine);
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                List<string>[] valus = { Conversions.ChopValue(pair.Key.ToString(), collSize[0]), Conversions.ChopValue(pair.Value.ToString(), collSize[1]) };
                int longestValue = valus[0].Count > valus[1].Count ? valus[0].Count : valus[1].Count;

                for (int i = 0 ; i < longestValue ; i++)
                {
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, $" {vertical} {( i > valus[0].Count - 1 ? ConsoleUtilities.GetSpaces(collSize[0]) : valus[0][i] + ConsoleUtilities.GetSpaces(collSize[0] - valus[0][i].Length) )} {vertical} {( i > valus[1].Count ? ConsoleUtilities.GetSpaces(collSize[1]) : valus[1][i] + ConsoleUtilities.GetSpaces(collSize[1] - valus[1][i].Length) )} {vertical} ");
                }

                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, septerationLine);
            }
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

            int sizePerColumn = ( ConsoleWidth - 9 ) / 2;
            int index = line;
            string septerationLine = $" {crosing}{ConsoleUtilities.GetCharakters(sizePerColumn + 2, horizontal)}{crosing} {ConsoleUtilities.GetCharakters(sizePerColumn + 2, horizontal)}{crosing} ";

            ConsoleUtilities.ReplaceLine(index, septerationLine);
            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                List<string>[] valus = { Conversions.ChopValue(pair.Key.ToString(), sizePerColumn), Conversions.ChopValue(pair.Value.ToString(), sizePerColumn) };
                int longestValue = valus[0].Count > valus[1].Count ? valus[0].Count : valus[1].Count;

                for (int i = 0 ; i < longestValue ; i++)
                {
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, $" {vertical} {( i > valus[0].Count - 1 ? ConsoleUtilities.GetSpaces(sizePerColumn) : valus[0][i] + ConsoleUtilities.GetSpaces(sizePerColumn - valus[0][i].Length) )} {vertical} {( i > valus[1].Count ? ConsoleUtilities.GetSpaces(sizePerColumn) : valus[1][i] + ConsoleUtilities.GetSpaces(sizePerColumn - valus[1][i].Length) )} {vertical} ");
                }

                index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                ConsoleUtilities.ReplaceLine(index, septerationLine);
            }
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
            int spacePerColumn = ( ConsoleWidth - ( table.Columns.Count * 3 + 2 ) ) / table.Columns.Count;
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
                if (header.Count > logestHeader)
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
                    if (val.Count > longest)
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
        /// Print a DataTable as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">The DataTable to print</param>
        public static void PrintSmartList (int line, DataTable table)
        {
            if (table.Columns.Count == 0)
                return;
            int[] columnCharCount = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnCharCount[i] += row[i].ToString().Length;
                }
                columnCharCount[i] += table.Columns[i].ColumnName.Length;
            }
            int charSum = columnCharCount.Sum();
            int[] collSize = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                collSize[i] = columnCharCount[i] * ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / charSum;
            }
            for (int i = 0 ; i < collSize.Length ; i++)
            {
                if (collSize[i] < 2)
                {
                    int rest = 2 - collSize[i];
                    collSize[i] = 2;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= rest;
                    }
                    else
                    {
                        for (int j = table.Columns.Count - 2 ; j >= 0 ; j--)
                        {
                            if (collSize[j] > 2)
                            {
                                collSize[j] -= rest;
                                if (collSize[j] < 2)
                                {
                                    rest = 2 - collSize[j];
                                    continue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<string>[] headers = new List<string>[table.Columns.Count];
            string seperationLine = " +";
            int longestHeader = 0;
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(collSize[i] + 2, '-') + "+";
                headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, collSize[i]);
                if(headers[i].Count > longestHeader)
                    longestHeader = headers[i].Count;
            }
            foreach (List<string> header in headers)
            {
                if (header.Count > longestHeader)
                    longestHeader = header.Count;
            }
            int index = line;
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            for (int i = 0 ; i < longestHeader ; i++)
            {
                string s = " |";
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    if (i < headers[j].Count)
                    {
                        s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - headers[j][i].Length)} |";
                    }
                    else
                    {
                        s += $" {ConsoleUtilities.GetSpaces(collSize[j])} |";
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
                    vals[i] = Conversions.ChopValue(row[i].ToString(), collSize[i]);
                }
                int longest = 0;
                foreach (List<string> val in vals)
                {
                    if (val.Count > longest)
                        longest = val.Count;
                }
                for (int i = 0 ; i < longest ; i++)
                {
                    StringBuilder sb = new(" |");
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < vals[j].Count)
                        {
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - vals[j][i].Length)} |");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(collSize[j])} |");
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
        /// Print a DataTable as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">The DataTable to print</param>
        /// <param name="style">How the list looks</param>
        public static void PrintSmartList (int line, DataTable table, TableLook style)
        {
            if (table.Columns.Count == 0)
                return;

            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int[] columnCharCount = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnCharCount[i] += row[i].ToString().Length;
                }
                columnCharCount[i] += table.Columns[i].ColumnName.Length;
            }
            int charSum = columnCharCount.Sum();
            int[] collSize = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                collSize[i] = columnCharCount[i] * ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / charSum;
            }
            for (int i = 0 ; i < collSize.Length ; i++)
            {
                if (collSize[i] < 2)
                {
                    int rest = 2 - collSize[i];
                    collSize[i] = 2;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= rest;
                    }
                    else
                    {
                        for (int j = table.Columns.Count - 2 ; j >= 0 ; j--)
                        {
                            if (collSize[j] > 2)
                            {
                                collSize[j] -= rest;
                                if (collSize[j] < 2)
                                {
                                    rest = 2 - collSize[j];
                                    continue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<string>[] headers = new List<string>[table.Columns.Count];
            string seperationLine = $" {crosing}";
            int longestHeader = 0;
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(collSize[i] + 2, horizontal) + crosing;
                headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, collSize[i]);
                if (headers[i].Count > longestHeader)
                    longestHeader = headers[i].Count;
            }
            foreach (List<string> header in headers)
            {
                if (header.Count > longestHeader)
                    longestHeader = header.Count;
            }
            int index = line;
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            for (int i = 0 ; i < longestHeader ; i++)
            {
                string s = $" {vertical}";
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    if (i < headers[j].Count)
                    {
                        s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - headers[j][i].Length)} {vertical}";
                    }
                    else
                    {
                        s += $" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}";
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
                    vals[i] = Conversions.ChopValue(row[i].ToString(), collSize[i]);
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
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - vals[j][i].Length)} {vertical}");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}");
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
        /// Print a DataTable as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">The DataTable to print</param>
        /// <param name="style">How the list looks</param>
        /// <param name="minColumnWidth">The minimum with that a colum can reach during automatic resize, if to smal gets defaultet to 2 if to large it gets defaultet to ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / table.Columns.Count</param>
        public static void PrintSmartList (int line, DataTable table, TableLook style, int minColumnWidth)
        {
            if (table.Columns.Count == 0)
                return;
            if(minColumnWidth < 2)
                minColumnWidth = 2;
            if (minColumnWidth > ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / table.Columns.Count)
                minColumnWidth = ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / table.Columns.Count;
            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int[] columnCharCount = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnCharCount[i] += row[i].ToString().Length;
                }
                columnCharCount[i] += table.Columns[i].ColumnName.Length;
            }
            int charSum = columnCharCount.Sum();
            int[] collSize = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                collSize[i] = columnCharCount[i] * ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / charSum;
            }
            for (int i = 0 ; i < collSize.Length ; i++)
            {
                if (collSize[i] < minColumnWidth)
                {
                    int rest = minColumnWidth - collSize[i];
                    collSize[i] = minColumnWidth;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= rest;
                    }
                    else
                    {
                        for (int j = table.Columns.Count - 2 ; j >= 0; j--)
                        {
                            if (collSize[j] > minColumnWidth)
                            {
                                collSize[j] -= rest;
                                if (collSize[j] < minColumnWidth)
                                {
                                    rest = minColumnWidth - collSize[j];
                                    continue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<string>[] headers = new List<string>[table.Columns.Count];
            string seperationLine = $" {crosing}";
            int longestHeader = 0;
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(collSize[i] + 2, horizontal) + crosing;
                headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, collSize[i]);
                if (headers[i].Count > longestHeader)
                    longestHeader = headers[i].Count;
            }
            foreach (List<string> header in headers)
            {
                if (header.Count > longestHeader)
                    longestHeader = header.Count;
            }
            int index = line;
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            for (int i = 0 ; i < longestHeader ; i++)
            {
                string s = $" {vertical}";
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    if (i < headers[j].Count)
                    {
                        s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - headers[j][i].Length)} {vertical}";
                    }
                    else
                    {
                        s += $" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}";
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
                    vals[i] = Conversions.ChopValue(row[i].ToString(), collSize[i]);
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
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - vals[j][i].Length)} {vertical}");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}");
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

        /// <summary>
        /// Print a DataTable as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">The DataTable to print</param>
        /// <param name="style">How the list looks</param>
        public static void PrintSmartList (int line, DataTable table, TableLook style, bool printHeader = true)
        {
            if (table.Columns.Count == 0)
                return;

            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int[] columnCharCount = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnCharCount[i] += row[i].ToString().Length;
                }
                if(printHeader)
                columnCharCount[i] += table.Columns[i].ColumnName.Length;
            }
            int charSum = columnCharCount.Sum();
            int[] collSize = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                collSize[i] = columnCharCount[i] * ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / charSum;
            }
            for (int i = 0 ; i < collSize.Length ; i++)
            {
                if (collSize[i] < 2)
                {
                    int rest = 2 - collSize[i];
                    collSize[i] = 2;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= rest;
                    }
                    else
                    {
                        for (int j = table.Columns.Count - 2 ; j >= 0 ; j--)
                        {
                            if (collSize[j] > 2)
                            {
                                collSize[j] -= rest;
                                if (collSize[j] < 2)
                                {
                                    rest = 2 - collSize[j];
                                    continue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<string>[]? headers = printHeader ? new List<string>[table.Columns.Count] : null;
            string seperationLine = $" {crosing}";
            int longestHeader = 0;
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(collSize[i] + 2, horizontal) + crosing;
                headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, collSize[i]);
                if (printHeader)
                {
                    if (headers[i].Count > longestHeader)
                        longestHeader = headers[i].Count;
                }
            }
            int index = line;
            if (printHeader)
            {
                foreach (List<string> header in headers)
                {
                    if (header.Count > longestHeader)
                        longestHeader = header.Count;
                }
                ConsoleUtilities.ReplaceLine(index, seperationLine);
                for (int i = 0 ; i < longestHeader ; i++)
                {
                    string s = $" {vertical}";
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < headers[j].Count)
                        {
                            s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - headers[j][i].Length)} {vertical}";
                        }
                        else
                        {
                            s += $" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}";
                        }
                    }
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, s);
                }
            }
            index = ConsoleUtilities.NormalizeLineIndex(index + 1);
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            foreach (DataRow row in table.Rows)
            {
                List<string>[] vals = new List<string>[table.Columns.Count];
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    vals[i] = Conversions.ChopValue(row[i].ToString(), collSize[i]);
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
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - vals[j][i].Length)} {vertical}");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}");
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
        /// Print a DataTable as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">The DataTable to print</param>
        /// <param name="style">How the list looks</param>
        /// <param name="minColumnWidth">The minimum with that a colum can reach during automatic resize, if to smal gets defaultet to 2 if to large it gets defaultet to ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / table.Columns.Count</param>
        public static void PrintSmartList (int line, DataTable table, TableLook style, int minColumnWidth, bool printHeader = true)
        {
            if (table.Columns.Count == 0)
                return;
            if (minColumnWidth < 2)
                minColumnWidth = 2;
            if (minColumnWidth > ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / table.Columns.Count)
                minColumnWidth = ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / table.Columns.Count;
            (char vertical, char horizontal, char crosing) = Conversions.GetCharForStyle(style);
            int[] columnCharCount = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnCharCount[i] += row[i].ToString().Length;
                }
                if(printHeader)
                columnCharCount[i] += table.Columns[i].ColumnName.Length;
            }
            int charSum = columnCharCount.Sum();
            int[] collSize = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                collSize[i] = columnCharCount[i] * ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / charSum;
            }
            for (int i = 0 ; i < collSize.Length ; i++)
            {
                if (collSize[i] < minColumnWidth)
                {
                    int rest = minColumnWidth - collSize[i];
                    collSize[i] = minColumnWidth;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= rest;
                    }
                    else
                    {
                        for (int j = table.Columns.Count - 2 ; j >= 0 ; j--)
                        {
                            if (collSize[j] > minColumnWidth)
                            {
                                collSize[j] -= rest;
                                if (collSize[j] < minColumnWidth)
                                {
                                    rest = minColumnWidth - collSize[j];
                                    continue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<string>[]? headers = printHeader ? new List<string>[table.Columns.Count] : null;
            string seperationLine = $" {crosing}";
            int longestHeader = 0;
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(collSize[i] + 2, horizontal) + crosing;
                if (printHeader)
                {
                    headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, collSize[i]);
                    if (headers[i].Count > longestHeader)
                        longestHeader = headers[i].Count;
                }
            }
            int index = line;
            if (printHeader)
            {
                foreach (List<string> header in headers)
                {
                    if (header.Count > longestHeader)
                        longestHeader = header.Count;
                }
                ConsoleUtilities.ReplaceLine(index, seperationLine);
                for (int i = 0 ; i < longestHeader ; i++)
                {
                    string s = $" {vertical}";
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < headers[j].Count)
                        {
                            s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - headers[j][i].Length)} {vertical}";
                        }
                        else
                        {
                            s += $" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}";
                        }
                    }
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, s);
                }
            }
            index = ConsoleUtilities.NormalizeLineIndex(index + 1);
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            foreach (DataRow row in table.Rows)
            {
                List<string>[] vals = new List<string>[table.Columns.Count];
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    vals[i] = Conversions.ChopValue(row[i].ToString(), collSize[i]);
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
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - vals[j][i].Length)} {vertical}");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(collSize[j])} {vertical}");
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
        /// Print a DataTable as List, colums get automaticly resized, size gets determined by amount of text in that column
        /// </summary>
        /// <param name="line">the line to start printing at</param>
        /// <param name="table">The DataTable to print</param>
        public static void PrintSmartList (int line, DataTable table, bool printHeader = true)
        {
            if (table.Columns.Count == 0)
                return;
            int[] columnCharCount = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    columnCharCount[i] += row[i].ToString().Length;
                }
                if(printHeader)
                columnCharCount[i] += table.Columns[i].ColumnName.Length;
            }
            int charSum = columnCharCount.Sum();
            int[] collSize = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                collSize[i] = columnCharCount[i] * ( ConsoleWidth - 3 - table.Columns.Count * 3 ) / charSum;
            }
            for (int i = 0 ; i < collSize.Length ; i++)
            {
                if (collSize[i] < 2)
                {
                    int rest = 2 - collSize[i];
                    collSize[i] = 2;
                    if (i < collSize.Length - 1)
                    {
                        collSize[i + 1] -= rest;
                    }
                    else
                    {
                        for (int j = table.Columns.Count - 2 ; j >= 0 ; j--)
                        {
                            if (collSize[j] > 2)
                            {
                                collSize[j] -= rest;
                                if (collSize[j] < 2)
                                {
                                    rest = 2 - collSize[j];
                                    continue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            List<string>[]? headers = printHeader ? new List<string>[table.Columns.Count] : null;
            string seperationLine = " +";
            int longestHeader = 0;
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                seperationLine += ConsoleUtilities.GetCharakters(collSize[i] + 2, '-') + "+";
                if (printHeader)
                {
                    headers[i] = Conversions.ChopValue(table.Columns[i].ColumnName, collSize[i]);
                    if (headers[i].Count > longestHeader)
                        longestHeader = headers[i].Count;
                }
            }
            int index = line;

            if (printHeader)
            {
                foreach (List<string> header in headers)
                {
                    if (header.Count > longestHeader)
                        longestHeader = header.Count;
                }
                ConsoleUtilities.ReplaceLine(index, seperationLine);
                for (int i = 0 ; i < longestHeader ; i++)
                {
                    string s = " |";
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < headers[j].Count)
                        {
                            s += $" {headers[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - headers[j][i].Length)} |";
                        }
                        else
                        {
                            s += $" {ConsoleUtilities.GetSpaces(collSize[j])} |";
                        }
                    }
                    index = ConsoleUtilities.NormalizeLineIndex(index + 1);
                    ConsoleUtilities.ReplaceLine(index, s);
                }
            }
            index = ConsoleUtilities.NormalizeLineIndex(index + 1);
            ConsoleUtilities.ReplaceLine(index, seperationLine);
            foreach (DataRow row in table.Rows)
            {
                List<string>[] vals = new List<string>[table.Columns.Count];
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    vals[i] = Conversions.ChopValue(row[i].ToString(), collSize[i]);
                }
                int longest = 0;
                foreach (List<string> val in vals)
                {
                    if (val.Count > longest)
                        longest = val.Count;
                }
                for (int i = 0 ; i < longest ; i++)
                {
                    StringBuilder sb = new(" |");
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        if (i < vals[j].Count)
                        {
                            sb.Append($" {vals[j][i]}{ConsoleUtilities.GetSpaces(collSize[j] - vals[j][i].Length)} |");
                        }
                        else
                        {
                            sb.Append($" {ConsoleUtilities.GetSpaces(collSize[j])} |");
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
                        rest = rest[( index + 1 )..];
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
