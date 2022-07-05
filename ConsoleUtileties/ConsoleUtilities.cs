using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleExtension
{

    public static class ConsoleUtilities
    {
        private static string EmptyLine_
        {
            get;
            set;
        } = GetSpaces(ConsoleWidth);

        public static string EmptyLine
        {
            get
            {
                if (ConsoleWidth == OldConsoleWidth)
                {
                    return EmptyLine_;
                }
                else
                {
                    EmptyLine_ = GetSpaces(ConsoleWidth);
                    OldConsoleWidth = ConsoleWidth;
                    return EmptyLine_;
                }
            }
        }

        private static int ConsoleWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        static ConsoleUtilities ()
        {
            if (!Console.OutputEncoding.Equals(Encoding.Unicode))
            {
                Console.OutputEncoding = Encoding.Unicode;
            }
        }

        public static void ReplaceLine (int line, Func<string> p)
        {
            ReplaceLine(line, p.Invoke());
        }

        private static int OldConsoleWidth
        {
            get;
            set;
        } = ConsoleWidth;

        private static (int Left, int Top) OldCoursorPos
        {
            get;
            set;
        } = Console.GetCursorPosition();

        //Save the curent coursor Pos
        public static void SavePos ()
        {
            OldCoursorPos = Console.GetCursorPosition();
        }

        //Resor the previous sved coursor Pos
        public static void LoadPos ()
        {
            Console.SetCursorPosition(OldCoursorPos.Left, OldCoursorPos.Top);
        }

        //return the inputet number of the provided charackter
        public static string GetCharakters (int num, char charakter)
        {
            StringBuilder sb = new();
            for (int i = 0 ; i < num ; i++)
            {
                sb.Append(charakter);
            }
            return sb.ToString();
        }

        //return the inputet number of spaces
        public static string GetSpaces (int num)
        {
            return GetCharakters(num, ' ');
        }

        //Clear a line by replacing everything with spaces
        public static void ClearLine (int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(EmptyLine);
        }

        //Stop line index to course overflow by subtraction and replacing with empty lines
        public static int NormalizeLineIndex (int line)
        {
            if (line > Console.BufferHeight - 50)
            {
                for (int i = 0 ; i < Console.WindowHeight ; i++)
                {
                    Console.WriteLine(EmptyLine);
                }
                return 0;
            }
            return line;
        }

        public static void ClearLine (int line, bool resorePos = false)
        {
            if (resorePos)
            {
                SavePos();
                Console.SetCursorPosition(0, line);
                Console.Write(EmptyLine);
                LoadPos();
            }
            else
            {
                ClearLine(line);
            }
        }

        //clear old line and replace with new one
        public static void ReplaceLine (int line, string replaceWith)
        {
            ClearLine(line);
            Console.SetCursorPosition(0, line);
            Console.Write(replaceWith);
        }

        //clear old line and replace with new one
        public static void ReplaceLine (int line, string replaceWith, bool restorePos = false)
        {
            if (restorePos)
            {
                SavePos();
                ClearLine(line);
                Console.SetCursorPosition(0, line);
                Console.Write(replaceWith);
                LoadPos();
            }
            else
            {
                ReplaceLine(line, replaceWith);
            }
        }

        //clear old line and replace with new one can be centered
        public static void ReplaceLine (int line, string replaceWith, bool center = false, bool restorePos = false)
        {
            if (restorePos)
            {
                SavePos();
                if (center)
                {
                    ReplaceLine(line, CenterString(replaceWith));
                }
                else
                {
                    ReplaceLine(line, replaceWith);
                }
                LoadPos();
            }
            else
            {
                if (center)
                {
                    ReplaceLine(line, CenterString(replaceWith));
                }
                else
                {
                    ReplaceLine(line, replaceWith);
                }
            }
        }

        //Write the text in the line but keep text written before
        public static void OverwriteLine (int line, int startPos, string overwriteWith)
        {
            Console.SetCursorPosition(startPos, line);
            Console.Write(overwriteWith);
        }

        //Write the text in the line but keep text written before
        public static void OverwriteLine (int line, int startPos, string overwriteWith, bool restorePos = false)
        {
            if (restorePos)
            {
                SavePos();
                Console.SetCursorPosition(startPos, line);
                Console.Write(overwriteWith);
                LoadPos();
            }
            else
            {
                OverwriteLine(line, startPos, overwriteWith);
            }
        }

        //Write the text (Centered) in the line but keep text written before
        public static void OverwriteLine (int line, string overwriteWith, bool center = false)
        {
            if (center)
            {
                OverwriteLine(line, GetCenterOfString(overwriteWith), overwriteWith);
            }
            else
            {
                OverwriteLine(line, 0, overwriteWith);
            }
        }

        //Write the text (Centered) in the line but keep text written before
        public static void OverwriteLine (int line, string overwriteWith, bool center = false, bool restorePos = false)
        {
            if (restorePos)
            {
                SavePos();
                if (center)
                {
                    OverwriteLine(line, GetCenterOfString(overwriteWith), overwriteWith);
                }
                else
                {
                    OverwriteLine(line, 0, overwriteWith);
                }
                LoadPos();
            }
            else
            {
                if (center)
                {
                    OverwriteLine(line, GetCenterOfString(overwriteWith), overwriteWith);
                }
                else
                {
                    OverwriteLine(line, 0, overwriteWith);
                }
            }
        }

        //return an int with the starting posiotion of a string so when writen at this pos in console its centered
        public static int GetCenterOfString (string s)
        {
            return (int) Math.Round(( ConsoleWidth - s.Length ) / 2d);
        }

        //Return a string that is Paded with spaces so its in the midle of the console wehen written on a new line
        public static string CenterString (string s)
        {
            int spaces = (int) Math.Round(( ConsoleWidth - s.Length ) / 2d);
            return string.Format("{0}{1}{0}", GetSpaces(spaces), s);
        }

        //fomat a array to human readable format
        public static string FormatArray<T> (T[] array)
        {
            if (array is null)
                return "null";
            if (array.Length == 0)
                return "[]";

            StringBuilder sb = new("[");
            foreach (T item in array)
            {
                sb.Append($"{item}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');
            return sb.ToString();
        }
    }
}
