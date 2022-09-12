using System;
using System.Drawing;
using System.Text;

namespace ConsoleUtilitiesLibary
{

    /// <summary>
    /// Utilety class with some usfull tols when working in a console application
    /// </summary>
    public sealed class ConsoleUtilities
    {
        /// <summary>
        /// The <see cref="ConsoleColor.Black"/> as RGB color
        /// </summary>
        public static readonly Color consoleBlack = Color.FromArgb(13, 13, 13);

        /// <summary>
        /// a string that resets the color when printet to the console only if RGB mode is active see <see cref="ConsoleOptions.EnableRGBConsoleMode"/> and <seealso cref="ConsoleOptions.IsRGBModeEnabled"/>
        /// </summary>
        public static readonly string colorResetString = GetForegroundColorString(Color.LightGray) + GetBackgroundColorString(consoleBlack);

        private static string EmptyLine_
        {
            get;
            set;
        } = GetSpaces(ConsoleWidth);

        /// <summary>
        /// A Console line of Spaces
        /// </summary>
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

        /// <summary>
        /// Replace a Line with a String
        /// </summary>
        /// <param name="line">The line replaced</param>
        /// <param name="p">Function that results the String</param>
        [Obsolete("Use ReplaceLine(int, string) instead if you can becourse invoking methods is slow!")]
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
        /// <summary>
        /// Save the current CursorPos, like PushMatrix
        /// </summary>
        public static void SavePos ()
        {
            OldCoursorPos = Console.GetCursorPosition();
        }

        //Resor the previous sved coursor Pos
        /// <summary>
        /// Load the Saved Cursor Pos and Setting it in the Console, like PopMatrix
        /// </summary>
        public static void LoadPos ()
        {
            Console.SetCursorPosition(OldCoursorPos.Left, OldCoursorPos.Top);
        }

        //return the inputet number of the provided charackter
        /// <summary>
        /// Get character x times
        /// </summary>
        /// <param name="num">how often you want the character</param>
        /// <param name="charakter">what character</param>
        /// <returns>streing of <paramref name="num"/> * <paramref name="charakter"/></returns>
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
        /// <summary>
        /// get x Spaces
        /// </summary>
        /// <param name="num">how many spaces</param>
        /// <returns>string of <paramref name="num"/> * ' '</returns>
        public static string GetSpaces (int num)
        {
            return GetCharakters(num, ' ');
        }

        /// <summary>
        /// Set a custom RGB color as console foreground color
        /// IMPORTANT: Only works on Windwos after Aneversary Update
        /// </summary>
        /// <param name="col">Color, alpha is ignored</param>
        public static void SetRGBConsoleForegroundColor (Color col)
        {
            if(!ConsoleOptions.IsRGBModeEnabled())
                ConsoleOptions.EnableRGBConsoleMode();
            Console.Write("\x1b[38;2;" + col.R + ";" + col.G + ";" + col.B + "m");
        }

        internal static string GetForegroundColorString (Color col)
        {
            return "\x1b[38;2;" + col.R + ";" + col.G + ";" + col.B + "m";
        }

        internal static string GetBackgroundColorString (Color col)
        {
            return "\x1b[48;2;" + col.R + ";" + col.G + ";" + col.B + "m";
        }

        /// <summary>
        /// Converts a color into a colorr string just concat the string onto what you printing to the console,
        /// the string will not show up in the console and the color gets chnchet
        /// see docs
        /// </summary>
        /// <param name="col">the color to encode in the string</param>
        /// <returns>color encoded in string</returns>
        public static string ForgroundColorString (Color col)
        {
            if (!ConsoleOptions.IsRGBModeEnabled())
                ConsoleOptions.EnableRGBConsoleMode();
            return "\x1b[38;2;" + col.R + ";" + col.G + ";" + col.B + "m";
        }

        /// <summary>
        /// Converts a color into a color string just concat the string in front of what you printing to the console,
        /// the string will not show up in the console and the color gets chnchet
        /// see docs
        /// </summary>
        /// <param name="col">Color to encode</param>
        /// <returns>color encoded in string</returns>
        public static string BackgroundColorString (Color col)
        {
            if (!ConsoleOptions.IsRGBModeEnabled())
                ConsoleOptions.EnableRGBConsoleMode();
            return "\x1b[48;2;" + col.R + ";" + col.G + ";" + col.B + "m";
        }

        /// <summary>
        /// Set a custom RGB color as console foreground color
        /// IMPORTANT: Only works on Windwos after Aneversary Update
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        public static void SetRGBConsoleForegroundColor (int r, int g, int b)
        {
            if (!ConsoleOptions.IsRGBModeEnabled())
                ConsoleOptions.EnableRGBConsoleMode();
            Console.Write("\x1b[38;2;" + r + ";" + g + ";" + b + "m");
        }

        /// <summary>
        /// Set a custom RGB color as console background color
        /// IMPORTANT: Only works on Windwos after Aneversary Update
        /// </summary>
        /// <param name="col">Color, alpha is ignored</param>
        public static void SetRGBConsoleBackgroundColor (Color col)
        {
            if (!ConsoleOptions.IsRGBModeEnabled())
                ConsoleOptions.EnableRGBConsoleMode();
            Console.Write("\x1b[48;2;" + col.R + ";" + col.G + ";" + col.B + "m");
        }

        /// <summary>
        /// Set a custom RGB color as console background color
        /// IMPORTANT: Only works on Windwos after Aneversary Update
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        public static void SetRGBConsoleBackgroundColor (int r, int g, int b)
        {
            if (!ConsoleOptions.IsRGBModeEnabled())
                ConsoleOptions.EnableRGBConsoleMode();
            Console.Write("\x1b[48;2;" + r + ";" + g + ";" + b + "m");
        }

        //Clear a line by replacing everything with spaces
        /// <summary>
        /// Clear the line
        /// </summary>
        /// <param name="line">the line to clear</param>
        public static void ClearLine (int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(EmptyLine);
        }

        //Stop line index to course overflow by subtraction and replacing with empty lines
        /// <summary>
        /// ATENTION: this is a dangerous method if you dont know how to use it,
        /// it can overwrite you conole text that was already written or can just start a new page so everything vanishes
        /// USAGE:
        ///     When your console is nearly full, it is about to reach the maximun BufferHeight <see cref="Console.BufferHeight"/> and
        ///     you want to print something at a line index out of range of the buffer size it will obious throw a error so this methods resets the line index
        ///     by seting the line index back to 0 but writing one ConsoleHeight <see cref="Console.WindowHeight"/> of empty lines,
        ///     This will akt like a new console begining so you can incese the index again, normaly this is automatic by the console with Console.WriteLine() but becourse my 
        ///     print Table and List Methods are relient on indexes i need to do so manualy
        ///     
        ///     Usecase: you reli on indexes like so 
        ///     index++;
        ///     int currline = Console.GetCursorPos().Top + index;
        ///     currline = NormalizeLineIndex(currline);
        /// </summary>
        /// <param name="line">line index to normalize</param>
        /// <returns>new line index</returns>
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

        /// <summary>
        /// Clear line
        /// </summary>
        /// <param name="line">the line to clear</param>
        /// <param name="resorePos">Save Coursor Pos before Clearing and Restoring Cursot Pos after clearing if true</param>
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
        /// <summary>
        /// Replace a line with a string
        /// </summary>
        /// <param name="line">the line to replace</param>
        /// <param name="replaceWith">the string the line is replaced with</param>
        public static void ReplaceLine (int line, string replaceWith)
        {
            ClearLine(line);
            Console.SetCursorPosition(0, line);
            Console.Write(replaceWith);
        }

        //clear old line and replace with new one
        /// <summary>
        /// Replace a line with a string
        /// </summary>
        /// <param name="line">the line to replace</param>
        /// <param name="replaceWith">the string the line is replaced with</param>
        /// <param name="restorePos">if true Custor Pos gests restored to before the ReplaceLine</param>
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
        /// <summary>
        ///  Replace a line with a string
        /// </summary>
        /// <param name="line">the line to replace</param>
        /// <param name="replaceWith">the string the line is replaced with</param>
        /// <param name="center">if true the string gets centered in the midle pf the console line</param>
        /// <param name="restorePos">if true the cursor pos gets restored to where it was before the replace</param>
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
        /// <summary>
        ///  Same as replace Line but it wont Cleat the entire line but only overwrite the part how long the string is
        /// </summary>
        /// <param name="line">the line to overwrite</param>
        /// <param name="startPos">starting pos of overwrite</param>
        /// <param name="overwriteWith">the string to overwrite with</param>
        public static void OverwriteLine (int line, int startPos, string overwriteWith)
        {
            Console.SetCursorPosition(startPos, line);
            Console.Write(overwriteWith);
        }

        //Write the text in the line but keep text written before
        /// <summary>
        ///  Same as replace Line but it wont Cleat the entire line but only overwrite the part how long the string is
        /// </summary>
        /// <param name="line">the line to overwrite</param>
        /// <param name="startPos">starting pos of overwrite</param>
        /// <param name="overwriteWith">the string to overwrite with</param>
        /// <param name="restorePos">if true the cursor pos gets restored to where it was before the replace</param>
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
        /// <summary>
        ///  Same as replace Line but it wont Cleat the entire line but only overwrite the part how long the string is
        /// </summary>
        /// <param name="line">the line to overwrite</param>
        /// <param name="overwriteWith">the string to overwrite with</param>
        /// <param name="center">if true the string gets automaticly centered</param>
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
        /// <summary>
        ///  Same as replace Line but it wont Cleat the entire line but only overwrite the part how long the string is
        /// </summary>
        /// <param name="line">the line to overwrite</param>
        /// <param name="overwriteWith">the string to overwrite with</param>
        /// <param name="restorePos">if true the cursor pos gets restored to where it was before the replace</param>
        /// <param name="center">if true the string gets automaticly centered</param>
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
        /// <summary>
        /// Dosnt Get The center index of string wherter the index where the string needs to be startet writing on a console line so its centered
        /// </summary>
        /// <param name="s">the string calculatet with</param>
        /// <returns>int index to start writing at</returns>
        public static int GetCenterOfString (string s)
        {
            return (int) Math.Round(( ConsoleWidth - s.Length ) / 2d);
        }

        //Return a string that is Paded with spaces so its in the midle of the console wehen written on a new line
        /// <summary>
        /// This encases the string in spaces so if written at begining of a line its centered
        /// </summary>
        /// <param name="s">the string to center</param>
        /// <returns>a string encased in spaces so centered in a console line</returns>
        public static string CenterString (string s)
        {
            int spaces = (int) Math.Round(( ConsoleWidth - s.Length ) / 2d);
            return string.Format("{0}{1}{0}", GetSpaces(spaces), s);
        }

        //fomat a array to human readable format
        /// <summary>
        /// A external ToStrung() Method for arrays so it acualy looks like a array
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="array">the array to convert</param>
        /// <returns>a string with a nicly formatet array</returns>
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
