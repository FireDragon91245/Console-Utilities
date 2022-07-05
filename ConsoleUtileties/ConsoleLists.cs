using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExtension
{
    public static class ConsoleLists
    {
        private static int ConsoleWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

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

        private static class Conversions
        {
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
                if (index > s.Length)
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
