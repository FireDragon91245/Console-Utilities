using System;

namespace ConsoleUtilitiesLibary
{

    /// <summary>
    /// Pint Progress bars to  the console
    /// </summary>
    public sealed class ConsoleBars
    {
        private static string ResetColorString => ConsoleUtilities.colorResetString;
        private static readonly BarColor defaultColor = new();

        private static int ConsoleWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        public static void ProgressBar (int line, int val, int max)
        {
            int fill = val * ConsoleWidth / max;
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, string.Empty, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        public static void ProgressBar (int line, float val, float max)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, string.Empty, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        public static void ProgressBar (int line, double val, double max)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, string.Empty, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        public static void ProgressBar (int line, decimal val, decimal max)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = decimal.ToDouble(val * 100 / max);
            ProgressBarPrinter(line, fill, percent, string.Empty, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        public static void ProgressBar (int line, int val, int max, string title)
        {
            int fill = val * ConsoleWidth / max;
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        public static void ProgressBar (int line, float val, float max, string title)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        public static void ProgressBar (int line, double val, double max, string title)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = decimal.ToDouble(val * 100 / max);
            ProgressBarPrinter(line, fill, percent, title, BarArangement.BarOnly, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="style">how the progressBar is aranged and what components it countains</param>
        public static void ProgressBar (int line, int val, int max, string title, BarArangement style)
        {
            int fill = val * ConsoleWidth / max;
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, style, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="style">how the progressBar is aranged and what components it countains</param>
        public static void ProgressBar (int line, float val, float max, string title, BarArangement style)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, style, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="style">how the progressBar is aranged and what components it countains</param>
        public static void ProgressBar (int line, double val, double max, string title, BarArangement style)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, style, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="style">how the progressBar is aranged and what components it countains</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement style)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percent = decimal.ToDouble(val * 100 / max);
            ProgressBarPrinter(line, fill, percent, title, style, BarLook.Default, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        public static void ProgressBar (int line, int val, int max, string title, BarArangement arangement, BarLook style)
        {
            int fill = val * ConsoleWidth / max;
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, arangement, style, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        /// <param name="color">Determin the color of the progress bar components</param>
        public static void ProgressBar (int line, int val, int max, string title, BarArangement arangement, BarLook style, BarColor color)
        {
            int fill = val * ConsoleWidth / max;
            double percent = val * 100d / max;
            ProgressBarPrinter(line, fill, percent, title, arangement, style, color);
        }

        private static void ProgressBarPrinter (int line, int progress, double percentage, string title, BarArangement arangement, BarLook style, BarColor color)
        {

            (char border1, char border2, char filling) = Conversions.GetCharsFromStyle(style);
            ReadOnlySpan<char> titleColor = ConsoleUtilities.GetForegroundColorString(color.TitleForegroundColor) + ConsoleUtilities.GetBackgroundColorString(color.TitleBackgroundColor);
            ReadOnlySpan<char> percentageColor = ConsoleUtilities.GetForegroundColorString(color.PercentageForegroundColor) + ConsoleUtilities.GetBackgroundColorString(color.PercentageBackgroundColor);
            ReadOnlySpan<char> borderColor = ConsoleUtilities.GetForegroundColorString(color.BarCasingForegroundColor) + ConsoleUtilities.GetBackgroundColorString(color.BarCasingBackgroundColor);
            ReadOnlySpan<char> progressColor = ConsoleUtilities.GetForegroundColorString(color.BarProgressForegroundColor) + ConsoleUtilities.GetBackgroundColorString(color.BarProgressBackgroundColor);

            int avaidableConsoleWidth = 0;

            if (progress > 1 && progress < ConsoleWidth - 1)
            {
                avaidableConsoleWidth = ConsoleWidth - 2;
                progress -= 1;
            }
            else if (progress < 3)
            {
                avaidableConsoleWidth = ConsoleWidth - 2;
            }
            else if (progress > ConsoleWidth - 3)
            {
                progress -= 2;
            }

            switch (arangement)
            {
                case BarArangement.BarOnly:
                    ConsoleUtilities.ReplaceLine(line, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}{ResetColorString}");
                    break;
                case BarArangement.BarWithTitle:
                    ConsoleUtilities.ReplaceLine(line, $"{titleColor}{title}", false, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}{ResetColorString}");
                    break;
                case BarArangement.BarWithTitleCentered:
                    Console.Write(titleColor.ToString());
                    ConsoleUtilities.ReplaceLine(line, $"{title}", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}{ResetColorString}");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    ConsoleUtilities.ReplaceLine(line, $"{titleColor}{title}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{percentageColor}{Math.Round(percentage, 2)}%{ResetColorString}");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    ConsoleUtilities.ReplaceLine(line, $"{titleColor}{title}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    ConsoleUtilities.ReplaceLine(line, $"{titleColor}{title}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    Console.Write(titleColor.ToString());
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{percentageColor}{Math.Round(percentage, 2)}%{ResetColorString}");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    Console.Write(titleColor.ToString());
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    Console.Write(titleColor.ToString());
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    ConsoleUtilities.ReplaceLine(line, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{percentageColor}{Math.Round(percentage, 2)}%{ResetColorString}");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    ConsoleUtilities.ReplaceLine(line, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    ConsoleUtilities.ReplaceLine(line, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    ConsoleUtilities.ReplaceLine(line, $"{titleColor}{title}{percentageColor}{Math.Round(percentage, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}{ResetColorString}");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    string raw = $"{title}{Math.Round(percentage, 2)}%";
                    string centered = titleColor.ToString() + ConsoleUtilities.CenterString(raw).Insert(ConsoleUtilities.GetCenterOfString(raw) + title.Length, percentageColor.ToString());
                    ConsoleUtilities.ReplaceLine(line, centered, false, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}{ResetColorString}");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    ConsoleUtilities.ReplaceLine(line, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(titleColor.ToString());
                    ConsoleUtilities.OverwriteLine(line, $"{title}", true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{percentageColor}{Math.Round(percentage, 2)}%{ResetColorString}");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    ConsoleUtilities.ReplaceLine(line, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.Write(titleColor.ToString());
                    ConsoleUtilities.OverwriteLine(line, $"{title}", true);
                    Console.Write(percentageColor.ToString());
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    ConsoleUtilities.ReplaceLine(line, $"{titleColor}{title}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{borderColor}{border1}{progressColor}{ConsoleUtilities.GetCharakters(progress, filling)}{ConsoleUtilities.GetSpaces(avaidableConsoleWidth - progress)}{borderColor}{border2}");
                    Console.WriteLine(percentageColor.ToString());
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(percentage, 2)}%", true, false);
                    Console.Write(ResetColorString);
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        public static void ProgressBar (int line, float val, float max, string title, BarArangement arangement, BarLook style)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percentage = val * 100d / max;
            ProgressBarPrinter(line, fill, percentage, title, arangement, style, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        /// <param name="color">Determin the color of the progress bar components</param>
        public static void ProgressBar (int line, float val, float max, string title, BarArangement arangement, BarLook style, BarColor color)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percentage = val * 100d / max;
            ProgressBarPrinter(line, fill, percentage, title, arangement, style, color);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        public static void ProgressBar (int line, double val, double max, string title, BarArangement arangement, BarLook style)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percentage = val * 100d / max;
            ProgressBarPrinter(line, fill, percentage, title, arangement, style, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        /// <param name="color">Determin the color of the progress bar components</param>
        public static void ProgressBar (int line, double val, double max, string title, BarArangement arangement, BarLook style, BarColor color)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percentage = val * 100d / max;
            ProgressBarPrinter(line, fill, percentage, title, arangement, style, color);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement arangement, BarLook style)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percentage = decimal.ToDouble(val * 100 / max);
            ProgressBarPrinter(line, fill, percentage, title, arangement, style, defaultColor);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="title">the title of the ProgresBar</param>
        /// <param name="arangement">how the progressBar is aranged and what components it countains</param>
        /// <param name="style">How the ProgresBar Looks</param>
        /// <param name="color">Determin the color of the progress bar components</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement arangement, BarLook style, BarColor color)
        {
            int fill = (int) Math.Round(val * ConsoleWidth / max);
            double percentage = decimal.ToDouble(val * 100 / max);
            ProgressBarPrinter(line, fill, percentage, title, arangement, style, color);
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        public static void ProgressBar (int line, int val, int max, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        public static void ProgressBar (int line, float val, float max, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        public static void ProgressBar (int line, double val, double max, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        public static void ProgressBar (int line, decimal val, decimal max, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        public static void ProgressBar (int line, int val, int max, string title, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        public static void ProgressBar (int line, float val, float max, string title, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        public static void ProgressBar (int line, double val, double max, string title, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="style">how the Progress bar is aranged and what components it countains</param>
        public static void ProgressBar (int line, int val, int max, string title, BarArangement style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="style">how the Progress bar is aranged and what components it countains</param>
        public static void ProgressBar (int line, float val, float max, string title, BarArangement style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="style">how the Progress bar is aranged and what components it countains</param>
        public static void ProgressBar (int line, double val, double max, string title, BarArangement style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="style">how the Progress bar is aranged and what components it countains</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="arangement">how the Progress bar is aranged and what components it countains</param>
        /// <param name="style">how the progressBar looks</param>
        public static void ProgressBar (int line, int val, int max, string title, BarArangement arangement, BarLook style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, arangement, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, arangement, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="arangement">how the Progress bar is aranged and what components it countains</param>
        /// <param name="style">how the progressBar looks</param>
        public static void ProgressBar (int line, float val, float max, string title, BarArangement arangement, BarLook style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, arangement, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, arangement, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="arangement">how the Progress bar is aranged and what components it countains</param>
        /// <param name="style">how the progressBar looks</param>
        public static void ProgressBar (int line, double val, double max, string title, BarArangement arangement, BarLook style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, arangement, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, arangement, style);
            }
        }

        /// <summary>
        /// Prints a Progress bar clculatet from val to max value percentage
        /// </summary>
        /// <param name="line">the console line to begin printing the ProgressBar</param>
        /// <param name="val">the current value</param>
        /// <param name="max">the max value</param>
        /// <param name="restorePos">if coursor pos should be restored after progress bar print</param>
        /// <param name="title">How the progressBar is named</param>
        /// <param name="arangement">how the Progress bar is aranged and what components it countains</param>
        /// <param name="style">how the progressBar looks</param>
        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement arangement, BarLook style, bool restorePos = false)
        {
            if (restorePos)
            {
                ConsoleUtilities.SavePos();
                ProgressBar(line, val, max, title, arangement, style);
                ConsoleUtilities.LoadPos();
            }
            else
            {
                ProgressBar(line, val, max, title, arangement, style);
            }
        }

        private static class Conversions
        {
            internal static (char, char, char) GetCharsFromStyle (BarLook style)
            {
                return style switch
                {
                    BarLook.Default => ('[', ']', '|'),
                    BarLook.SquareBracketsBorder => ('[', ']', '|'),
                    BarLook.AngleBracketsBorder => ('<', '>', '|'),
                    BarLook.NormalBracketsBorder => ('(', ')', '|'),
                    BarLook.CurlyBracketsBorder => ('{', '}', '|'),
                    BarLook.MinusFilling => ('[', ']', '-'),
                    BarLook.PlussFilling => ('[', ']', '+'),
                    BarLook.StarFilling => ('[', ']', '*'),
                    BarLook.HashTagFilling => ('[', ']', '#'),
                    BarLook.LineFilling => ('[', ']', '|'),
                    BarLook.SquareBracketsBorderAndMinusFilling => ('[', ']', '-'),
                    BarLook.AngleBracketsBorderAndMinusFilling => ('<', '>', '-'),
                    BarLook.NormalBracketsBorderAndMinusFilling => ('(', ')', '-'),
                    BarLook.CurlyBracketsBorderAndMinusFilling => ('{', '}', '-'),
                    BarLook.SquareBracketsBorderAndPlussFilling => ('[', ']', '+'),
                    BarLook.AngleBracketsBorderAndPlussFilling => ('<', '>', '+'),
                    BarLook.NormalBracketsBorderAndPlussFilling => ('(', ')', '+'),
                    BarLook.CurlyBracketsBorderAndPlussFilling => ('{', '}', '+'),
                    BarLook.SquareBracketsBorderAndStarFilling => ('[', ']', '*'),
                    BarLook.AngleBracketsBorderAndStarFilling => ('<', '>', '*'),
                    BarLook.NormalBracketsBorderAndStarFilling => ('(', ')', '*'),
                    BarLook.CurlyBracketsBorderAndStarFilling => ('{', '}', '*'),
                    BarLook.SquareBracketsBorderAndHashTagFilling => ('[', ']', '#'),
                    BarLook.AngleBracketsBorderAndHashTagFilling => ('<', '>', '#'),
                    BarLook.NormalBracketsBorderAndHashTagFilling => ('(', ')', '#'),
                    BarLook.CurlyBracketsBorderAndHashTagFilling => ('{', '}', '#'),
                    BarLook.SquareBracketsBorderAndLineFilling => ('[', ']', '|'),
                    BarLook.AngleBracketsBorderAndLineFilling => ('<', '>', '|'),
                    BarLook.NormalBracketsBorderAndLineFilling => ('(', ')', '|'),
                    BarLook.CurlyBracketsBorderAndLineFilling => ('{', '}', '|'),
                    BarLook.NoBorder => (' ', ' ', '|'),
                    BarLook.NoBorderAndMinusFilling => (' ', ' ', '-'),
                    BarLook.NoBorderAndPlussFilling => (' ', ' ', '+'),
                    BarLook.NoBorderAndStarFilling => (' ', ' ', '*'),
                    BarLook.NoBorderAndHashTagFilling => (' ', ' ', '#'),
                    BarLook.NoBorderAndLineFilling => (' ', ' ', '|'),
                    _ => ('[', ']', '|')
                };
            }
        }
    }

    /// <summary>
    /// Where the diferent components of the progress bar are locatet
    /// </summary>
    public enum BarArangement
    {
        BarOnly,
        BarWithTitle,
        BarWithTitleCentered,
        BarWithTitleAndPercentageUnder,
        BarWithTitleAndPercentageUnderCentered,
        BarWithTitleAndPercentageInBar,
        BarWithTitleCenteredAndPercentageUnder,
        BarWithTitleCenteredAndPercantageUnderCentered,
        BarWithTitleCenteredAndPercantageInBar,
        BarAndPercentageUnder,
        BarAndPercentageUnderCentered,
        BarAndPercentageInBar,
        BarAndTitleFolowedByPercentage,
        BarAndTitleFolowedByPercentageCentered,
        BarAndTitleInBarAndPercentageUnder,
        BarAndTitleInBarAndPercentageUnderCentered,
        BarAndTitleFolowedByPercentageInBar
    }

    /// <summary>
    /// What characters are used to display the bar
    /// </summary>
    public enum BarLook
    {
        Default,
        SquareBracketsBorder,
        AngleBracketsBorder,
        NormalBracketsBorder,
        CurlyBracketsBorder,
        MinusFilling,
        PlussFilling,
        StarFilling,
        HashTagFilling,
        LineFilling,
        SquareBracketsBorderAndMinusFilling,
        AngleBracketsBorderAndMinusFilling,
        NormalBracketsBorderAndMinusFilling,
        CurlyBracketsBorderAndMinusFilling,
        SquareBracketsBorderAndPlussFilling,
        AngleBracketsBorderAndPlussFilling,
        NormalBracketsBorderAndPlussFilling,
        CurlyBracketsBorderAndPlussFilling,
        SquareBracketsBorderAndStarFilling,
        AngleBracketsBorderAndStarFilling,
        NormalBracketsBorderAndStarFilling,
        CurlyBracketsBorderAndStarFilling,
        SquareBracketsBorderAndHashTagFilling,
        AngleBracketsBorderAndHashTagFilling,
        NormalBracketsBorderAndHashTagFilling,
        CurlyBracketsBorderAndHashTagFilling,
        SquareBracketsBorderAndLineFilling,
        AngleBracketsBorderAndLineFilling,
        NormalBracketsBorderAndLineFilling,
        CurlyBracketsBorderAndLineFilling,
        NoBorder,
        NoBorderAndMinusFilling,
        NoBorderAndPlussFilling,
        NoBorderAndStarFilling,
        NoBorderAndHashTagFilling,
        NoBorderAndLineFilling
    }
}
