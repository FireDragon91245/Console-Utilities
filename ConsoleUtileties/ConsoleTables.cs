using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleExtension
{

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

            ConsoleUtilities.ReplaceLine(line, () =>
            {
                StringBuilder sb = new(" |");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} |");
                }
                return sb.ToString();
            });

            ConsoleUtilities.ReplaceLine(line + 1, () =>
            {
                StringBuilder sb = new(" +");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, '-')}+");
                }
                return sb.ToString();
            });

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                ConsoleUtilities.ReplaceLine(line + i + 2, () =>
                {
                    StringBuilder sb = new(" |");
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        sb.Append($" {table.Rows[i][table.Columns[j]]}{ConsoleUtilities.GetSpaces(longest[j] - table.Rows[i][table.Columns[j]].ToString().Length)} |");
                    }
                    return sb.ToString();
                });
            }
        }

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

            ConsoleUtilities.ReplaceLine(line, () =>
            {
                StringBuilder sb = new(" |");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} |");
                }
                if (cutTableAtLineEnd)
                {
                    if (sb.Length > ConsoleWidth)
                    {
                        sb.Remove(ConsoleWidth - 3, sb.Length - ConsoleWidth + 3);
                        sb.Append("...");
                    }
                }
                return sb.ToString();
            });

            ConsoleUtilities.ReplaceLine(line + 1, () =>
            {
                StringBuilder sb = new(" +");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, '-')}+");
                }
                if (cutTableAtLineEnd)
                {
                    if (sb.Length > ConsoleWidth)
                    {
                        sb.Remove(ConsoleWidth - 3, sb.Length - ConsoleWidth + 3);
                        sb.Append("...");
                    }
                }
                return sb.ToString();
            });

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                ConsoleUtilities.ReplaceLine(line + i + 2, () =>
                {
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
                    return sb.ToString();
                });
            }
        }

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

            ConsoleUtilities.ReplaceLine(line, () =>
            {
                StringBuilder sb = new($" {vertikal}");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} {vertikal}");
                }
                return sb.ToString();
            });

            ConsoleUtilities.ReplaceLine(line + 1, () =>
            {
                StringBuilder sb = new($" {crossing}");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, horizontal)}{crossing}");
                }
                return sb.ToString();
            });

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                ConsoleUtilities.ReplaceLine(line + i + 2, () =>
                {
                    StringBuilder sb = new($" {vertikal}");
                    for (int j = 0 ; j < table.Columns.Count ; j++)
                    {
                        sb.Append($" {table.Rows[i][table.Columns[j]]}{ConsoleUtilities.GetSpaces(longest[j] - table.Rows[i][table.Columns[j]].ToString().Length)} {vertikal}");
                    }
                    return sb.ToString();
                });
            }
        }

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

            ConsoleUtilities.ReplaceLine(line, () =>
            {
                StringBuilder sb = new($" {vertikal}");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($" {table.Columns[i].ColumnName}{ConsoleUtilities.GetSpaces(longest[i] - table.Columns[i].ColumnName.Length)} {vertikal}");
                }
                if (cutTableAtLineEnd)
                {
                    if (sb.Length > ConsoleWidth)
                    {
                        sb.Remove(ConsoleWidth - 3, sb.Length - ConsoleWidth + 3);
                        sb.Append("...");
                    }
                }
                return sb.ToString();
            });

            ConsoleUtilities.ReplaceLine(line + 1, () =>
            {
                StringBuilder sb = new($" {crossing}");
                for (int i = 0 ; i < table.Columns.Count ; i++)
                {
                    sb.Append($"{ConsoleUtilities.GetCharakters(longest[i] + 2, horizontal)}{crossing}");
                }
                if (cutTableAtLineEnd)
                {
                    if (sb.Length > ConsoleWidth)
                    {
                        sb.Remove(ConsoleWidth - 3, sb.Length - ConsoleWidth + 3);
                        sb.Append("...");
                    }
                }
                return sb.ToString();
            });

            for (int i = 0 ; i < table.Rows.Count ; i++)
            {
                line = ConsoleUtilities.NormalizeLineIndex(line + i + 2) - i - 2;
                ConsoleUtilities.ReplaceLine(line + i + 2, () =>
                {
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
                    return sb.ToString();
                });
            }
        }

        public static void PrintTable<T> (int line, List<T> list, string name)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name));
        }

        public static void PrintTable<T> (int line, List<T> list, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name), cutTableAtLineEnd);
        }

        public static void PrintTable<T> (int line, List<T> list, string name, TableLook look)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name), look);
        }

        public static void PrintTable<T> (int line, List<T> list, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ListToDataTable(list, name), look, cutTableAtLineEnd);
        }

        public static void PrintTable<T> (int line, T[] array, string name)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name));
        }

        public static void PrintTable<T> (int line, T[] array, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name), cutTableAtLineEnd);
        }

        public static void PrintTable<T> (int line, T[] array, string name, TableLook look)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name), look);
        }

        public static void PrintTable<T> (int line, T[] array, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayToDataTable(array, name), look, cutTableAtLineEnd);
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, string keyName, string valueName)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName));
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, string keyName, string valueName, bool cutTableAtLineNnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName), cutTableAtLineNnd);
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, string keyName, string valueName, TableLook look)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName), look);
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, string keyName, string valueName, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, keyName, valueName), look, cutTableAtLineEnd);
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"));
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"), cutTableAtLineEnd);
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, TableLook look)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"), look);
        }

        public static void PrintTable<K, V> (int line, Dictionary<K, V> dictionary, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.DictionaryToDataTable(dictionary, "Key", "Value"), look, cutTableAtLineEnd);
        }

        public static void PrintTable (int line, ArrayList list, string name)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name));
        }

        public static void PrintTable (int line, ArrayList list, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name), cutTableAtLineEnd);
        }

        public static void PrintTable (int line, ArrayList list, string name, TableLook look)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name), look);
        }

        public static void PrintTable (int line, ArrayList list, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.ArrayListToDataTable(list, name), look, cutTableAtLineEnd);
        }

        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name));
        }

        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name), cutTableAtLineEnd);
        }

        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name, TableLook look)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name), look);
        }

        public static void PrintTable<T> (int line, LinkedList<T> linkedList, string name, TableLook look, bool cutTableAtLineEnd = false)
        {
            PrintTable(line, Conversions.LinkedListToDataTable(linkedList, name), look, cutTableAtLineEnd);
        }


        public static class Conversions
        {
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

            public static DataTable DictionaryToDataTable<K, V> (Dictionary<K, V> dictionary, string keyName, string valueName)
            {
                DataTable table = new();
                table.Columns.Add(keyName, typeof(K));
                table.Columns.Add(valueName, typeof(V));
                foreach (KeyValuePair<K, V> pair in dictionary)
                {
                    table.Rows.Add(pair.Key, pair.Value);
                }
                return table;
            }

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

    public enum TableLook
    {
        Default,
        Lines,
        HashTag,
        Solid,
        DoubleLines
    }
}
