using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleUtilities
{
    /// <summary>
    /// Print Tables nicly Formatet
    /// </summary>
    public static class ConsoleTables
    {

        private static int ConsoleWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        //Print a table nicly formatet with header BUT keeps the original lenth and form of the thabe this can men the table leaves the console screeen, on extremly large tables like 5k+ Rows this can course some visual bugs in the console
        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables and the table gets Cut at the end of the console Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="table">The Table</param>
        public static void PrintTable (int line, DataTable table)
        {
            int[] longest = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (longest[i] < row[table.Columns[i]].ToString().Length)
                        longest[i] = row[table.Columns[i]].ToString().Length;
                }
                if (longest[i] < table.Columns[i].ColumnName.Length)
                    longest[i] = table.Columns[i].ColumnName.Length;
            }

            StringBuilder sb1 = new(" |");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb1.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} |");
            }
            ConsoleUtilities.ReplaceLine(line, sb1.ToString());

            StringBuilder sb2 = new(" +");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb2.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, '-')}+");
            }
            ConsoleUtilities.ReplaceLine(line + 1, sb2.ToString());

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                StringBuilder sb = new(" |");
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    sb.Append($" {table.Rows[i][table.Columns[j]]}{ConsoleUtilities.GetSpaces(longest[j] - table.Rows[i][table.Columns[j]].ToString().Length)} |");
                }
                ConsoleUtilities.ReplaceLine(line + i + 2, sb.ToString());
            }
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables and the table gets Cut at the end of the console Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="table">The Table</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable (int line, DataTable table, bool cutTableAtLineEnd = false)
        {
            int[] longest = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (longest[i] < row[table.Columns[i]].ToString().Length)
                        longest[i] = row[table.Columns[i]].ToString().Length;
                }
                if (longest[i] < table.Columns[i].ColumnName.Length)
                    longest[i] = table.Columns[i].ColumnName.Length;
            }

            StringBuilder sb0 = new(" |");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb0.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} |");
            }
            if (cutTableAtLineEnd)
            {
                if (sb0.Length > ConsoleWidth)
                {
                    sb0.Remove(ConsoleWidth - 3, sb0.Length - ConsoleWidth + 3);
                    sb0.Append("...");
                }
            }
            ConsoleUtilities.ReplaceLine(line, sb0.ToString());

            StringBuilder sb1 = new(" +");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb1.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, '-')}+");
            }
            if (cutTableAtLineEnd)
            {
                if (sb1.Length > ConsoleWidth)
                {
                    sb1.Remove(ConsoleWidth - 3, sb1.Length - ConsoleWidth + 3);
                    sb1.Append("...");
                }
            }
            ConsoleUtilities.ReplaceLine(line + 1, sb1.ToString());


            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                StringBuilder sb = new(" |");
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    sb.Append($" {table.Rows[i][table.Columns[j]]}{ConsoleUtilities.GetSpaces(longest[j] - table.Rows[i][table.Columns[j]].ToString().Length)} |");
                }
                if (cutTableAtLineEnd)
                {
                    if (sb.Length > ConsoleWidth)
                    {
                        sb.Remove(ConsoleWidth - 3, sb.Length - ConsoleWidth + 3);
                        sb.Append("...");
                    }
                }
                ConsoleUtilities.ReplaceLine(line + i + 2, sb.ToString());
            }
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables and the table gets Cut at the end of the console Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="table">The Table</param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable (int line, DataTable table, TableLook look)
        {
            (char vertikal, char horizontal, char crossing) = look switch
            {
                TableLook.Default => ('|', '-', '+'),
                TableLook.Lines => ('|', '-', '+'),
                TableLook.HashTag => ('#', '#', '#'),
                TableLook.Solid => ('█', '█', '█'),
                TableLook.DoubleLines => ('║', '═', '╬'),
                _ => ('|', '-', '+'),
            };

            int[] longest = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (longest[i] < row[table.Columns[i]].ToString().Length)
                        longest[i] = row[table.Columns[i]].ToString().Length;
                }
                if (longest[i] < table.Columns[i].ColumnName.Length)
                    longest[i] = table.Columns[i].ColumnName.Length;
            }

            StringBuilder sb0 = new($" {vertikal}");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb0.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} {vertikal}");
            }
            ConsoleUtilities.ReplaceLine(line, sb0.ToString());

            StringBuilder sb1 = new($" {crossing}");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb1.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, horizontal)}{crossing}");
            }
            ConsoleUtilities.ReplaceLine(line + 1, sb1.ToString());

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                StringBuilder sb2 = new($" {vertikal}");
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    sb2.Append($" {table.Rows[i][table.Columns[j]]}{ConsoleUtilities.GetSpaces(longest[j] - table.Rows[i][table.Columns[j]].ToString().Length)} {vertikal}");
                }
                ConsoleUtilities.ReplaceLine(line + i + 2, sb2.ToString());
            }
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables and the table gets Cut at the end of the console Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="table">The Table</param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable (int line, DataTable table, TableLook look, bool cutTableAtLineEnd = false)
        {
            (char vertikal, char horizontal, char crossing) = look switch
            {
                TableLook.Default => ('|', '-', '+'),
                TableLook.Lines => ('|', '-', '+'),
                TableLook.HashTag => ('#', '#', '#'),
                TableLook.Solid => ('█', '█', '█'),
                TableLook.DoubleLines => ('║', '═', '╬'),
                _ => ('|', '-', '+'),
            };

            int[] longest = new int[table.Columns.Count];
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (longest[i] < row[table.Columns[i]].ToString().Length)
                        longest[i] = row[table.Columns[i]].ToString().Length;
                }
                if (longest[i] < table.Columns[i].ColumnName.Length)
                    longest[i] = table.Columns[i].ColumnName.Length;
            }


            StringBuilder sb0 = new($" {vertikal}");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb0.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} {vertikal}");
            }
            if (cutTableAtLineEnd)
            {
                if (sb0.Length > ConsoleWidth)
                {
                    sb0.Remove(ConsoleWidth - 3, sb0.Length - ConsoleWidth + 3);
                    sb0.Append("...");
                }
            }
            ConsoleUtilities.ReplaceLine(line, sb0.ToString());


            StringBuilder sb1 = new($" {crossing}");
            for (int i = 0 ; i < table.Columns.Count ; i++)
            {
                sb1.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, horizontal)}{crossing}");
            }
            if (cutTableAtLineEnd)
            {
                if (sb1.Length > ConsoleWidth)
                {
                    sb1.Remove(ConsoleWidth - 3, sb1.Length - ConsoleWidth + 3);
                    sb1.Append("...");
                }
            }
            ConsoleUtilities.ReplaceLine(line + 1, sb1.ToString());

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;

                StringBuilder sb = new($" {vertikal}");
                for (int j = 0 ; j < table.Columns.Count ; j++)
                {
                    sb.Append($" {table.Rows[i][table.Columns[j]]}{ConsoleUtilities.GetSpaces(longest[j] - table.Rows[i][table.Columns[j]].ToString().Length)} {vertikal}");
                }
                if (cutTableAtLineEnd)
                {
                    if (sb.Length > ConsoleWidth)
                    {
                        sb.Remove(ConsoleWidth - 3, sb.Length - ConsoleWidth + 3);
                        sb.Append("...");
                    }
                }
                ConsoleUtilities.ReplaceLine(line + i + 2, sb.ToString());
            }
        }


        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables and the table gets Cut at the end of the console Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the List</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">List acting as all rows</param>
        /// <param name="name">acting as the colum header name for the list rows</param>
        public static void PrintTable<T> (int line, List<T> list, string name)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name));
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the List</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">List acting as all rows</param>
        /// <param name="name">acting as the colum header name for the list rows</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<T> (int line, List<T> list, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name), cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the List</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">List acting as all rows</param>
        /// <param name="name">acting as the colum header name for the list rows</param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable<T> (int line, List<T> list, string name, TableLook look)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name), look);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the List</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">List acting as all rows</param>
        /// <param name="name">acting as the colum header name for the list rows</param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<T> (int line, List<T> list, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name), look, cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the Array</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="array">Array acting as all rows</param>
        /// <param name="name">acting as the colum header name for the array rows</param>
        public static void PrintTable<T> (int line, T[] array, string name)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name));
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the Array</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="array">Array acting as all rows</param>
        /// <param name="name">acting as the colum header name for the array rows</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<T> (int line, T[] array, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name), cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the Array</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="array">Array acting as all rows</param>
        /// <param name="name">acting as the colum header name for the array rows</param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable<T> (int line, T[] array, string name, TableLook look)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name), look);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="T">Type of the Array</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="array">Array acting as all rows</param>
        /// <param name="name">acting as the colum header name for the array rows</param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<T> (int line, T[] array, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name), look, cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="keyName">acting as the colum header name for the Key rows</param>
        /// <param name="valueName">acting as the colum header name for the Value rows</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, string keyName, string valueName)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName));
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="keyName">acting as the colum header name for the Key rows</param>
        /// <param name="valueName">acting as the colum header name for the Value rows</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, string keyName, string valueName, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName), cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="keyName">acting as the colum header name for the Key rows</param>
        /// <param name="valueName">acting as the colum header name for the Value rows</param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, string keyName, string valueName, TableLook look)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName), look);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="keyName">acting as the colum header name for the Key rows</param>
        /// <param name="valueName">acting as the colum header name for the Value rows</param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, string keyName, string valueName, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName), look, cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"));
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"), cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, TableLook look)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"), look);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <typeparam name="TKey">Key Type</typeparam>
        /// <typeparam name="TValue">Value Type</typeparam>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="dictionary">Dictionary acting as all rows (2 Columns Key,Val) </param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<TKey, TValue> (int line, Dictionary<TKey, TValue> dictionary, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"), look, cutTableAtLineEnd);
        }

        [Obsolete("Use PrintTable(List<T>) or PrintTable(LinkedList<T>) instead if you can avoid ArrayList!")]
        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">ArrayList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        public static void PrintTable (int line, ArrayList list, string name)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name));
        }

        [Obsolete("Use PrintTable(List<T>) or PrintTable(LinkedList<T>) instead if you can avoid ArrayList!")]
        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">ArrayList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable (int line, ArrayList list, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name), cutTableAtLineEnd);
        }

        [Obsolete("Use PrintTable(List<T>) or PrintTable(LinkedList<T>) instead if you can avoid ArrayList!")]
        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">ArrayList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable (int line, ArrayList list, string name, TableLook look)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name), look);
        }

        [Obsolete("Use PrintTable(List<T>) or PrintTable(LinkedList<T>) instead if you can avoid ArrayList!")]
        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Tables
        /// and the table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="list">ArrayList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable (int line, ArrayList list, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name), look, cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Table
        /// and the Table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="linkedList">LinkedList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name));
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Table
        /// and the Table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="linkedList">LinkedList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name), cutTableAtLineEnd);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Table
        /// and the Table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="linkedList">LinkedList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        /// <param name="look">The look of the table printet</param>
        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name, TableLook look)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name), look);
        }

        /// <summary>
        /// Print a Table Nicly Formatet,
        /// Can course visual bugs in console on extreme large Table
        /// and the Table gets Cut at the end of the console
        /// Use ConsoleList.PrintList() to resolve the cutting at end of line
        /// </summary>
        /// <param name="line">The console line the table is startet printing at</param>
        /// <param name="linkedList">LinkedList representing all rows</param>
        /// <param name="name">acting as the colum header name for all row</param>
        /// <param name="look">The look of the table printet</param>
        /// <param name="cutTableAtLineEnd">If true and the table is longer then the console the 3 last characters get replaced with points</param>
        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name), look, cutTableAtLineEnd);
        }

        /// <summary>
        /// Some Private Conversions for PrintTable Methods but some usfull public Conversions if needed
        /// (Can be unsafe as it is made for PrintTable Methods)
        /// </summary>
        public static class Conversions
        {
            /// <summary>
            /// Convert Attay To DataTable
            /// </summary>
            /// <typeparam name="T">Array Type</typeparam>
            /// <param name="array">Acting as all rows</param>
            /// <param name="name">The Colum name</param>
            /// <returns>DataTable with 1 colum with name of name and rows from the array</returns>
            public static DataTable ArrayToDataTable<T> (T[] array, string name)
            {
                DataTable table = new();
                table.Columns.Add(name, typeof(T));
                foreach (T item in array)
                {
                    table.Rows.Add(item);
                }
                return table;
            }

            /// <summary>
            /// Converts Dictionary to DataTable
            /// </summary>
            /// <typeparam name="TKey">Key Type</typeparam>
            /// <typeparam name="TValue">Value Type</typeparam>
            /// <param name="dictionary">Input Dictionary acting as all rows in 2 diferent clums (Key, Val)</param>
            /// <param name="keyName">The Colum name of TKey</param>
            /// <param name="valueName">The Column name of TValue</param>
            /// <returns>Data table with 2 colums named <paramref name="keyName"/> and <paramref name="valueName"/> and all rows from <paramref name="dictionary"/></returns>
            public static DataTable DictionaryToDataTable<TKey, TValue> (Dictionary<TKey, TValue> dictionary, string keyName, string valueName)
            {
                DataTable table = new();
                table.Columns.Add(keyName, typeof(TKey));
                table.Columns.Add(valueName, typeof(TValue));
                foreach (KeyValuePair<TKey, TValue> pair in dictionary)
                {
                    table.Rows.Add(pair.Key, pair.Value);
                }
                return table;
            }

            [Obsolete("Use ArrayList<T> or List<T> instead of ArrayList if you can!")]
            /// <summary>
            /// Convert ArrayList to DataTable
            /// </summary>
            /// <param name="arrayList">The arraylist acting as all rows</param>
            /// <param name="name">Name of the collumn countaining the rows</param>
            /// <returns>DataTable with 1 column countaining all elements fom ArrayList</returns>
            public static DataTable ArrayListToDataTable (ArrayList arrayList, string name)
            {
                DataTable table = new();
                table.Columns.Add(name, typeof(object));
                foreach (object item in arrayList)
                {
                    table.Rows.Add(item);
                }
                return table;
            }

            /// <summary>
            /// Converts List<<typeparamref name="T"/>> to DataTable 
            /// </summary>
            /// <typeparam name="T">List Type</typeparam>
            /// <param name="list">List acting as all rows</param>
            /// <param name="name">Name of the column countainging all elemnts form list</param>
            /// <returns>Data Table with 1 row countaining all elements form list</returns>
            public static DataTable ListToDataTable<T> (List<T> list, string name)
            {
                DataTable table = new();
                table.Columns.Add(name, typeof(T));
                foreach (T item in list)
                {
                    table.Rows.Add(item);
                }
                return table;
            }

            /// <summary>
            /// Converts LinkedList to DataTable
            /// </summary>
            /// <typeparam name="T">LinkedList Type</typeparam>
            /// <param name="list">LinkedList acting as all rows</param>
            /// <param name="name">name of the column countaining all elements form list</param>
            /// <returns>DataTable with 1 column countaining all elements form list</returns>
            public static DataTable LinkedListToDataTable<T> (LinkedList<T> list, string name)
            {
                DataTable table = new();
                table.Columns.Add(name, typeof(T));
                foreach (T item in list)
                {
                    table.Rows.Add(item);
                }
                return table;
            }
        }
    }

    /// <summary>
    /// looks that are avaidable
    /// </summary>
    public enum TableLook
    {
        Default,
        Lines,
        HashTag,
        Solid,
        DoubleLines
    }
}
