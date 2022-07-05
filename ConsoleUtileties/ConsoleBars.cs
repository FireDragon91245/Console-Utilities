using System;

namespace ConsoleExtension
{

    public static class ConsoleBars
    {

        private static int ConsoleWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        public static void ProgressBar (int line, int val, int max)
        {
            int full = val * ConsoleWidth / max;
            ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, float val, float max)
        {
            int full = (int) Math.Round(val * ConsoleWidth / max);
            ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, double val, double max)
        {
            int full = (int) Math.Round(val * ConsoleWidth / max);
            ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, decimal val, decimal max)
        {
            int full = (int) Math.Round(val * ConsoleWidth / max);
            ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, int val, int max, string title)
        {
            int full = val * ConsoleWidth / max;
            ConsoleUtilities.ReplaceLine(line, title);
            ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, float val, float max, string title)
        {
            int full = (int) Math.Round(val * ConsoleWidth / max);
            ConsoleUtilities.ReplaceLine(line, title);
            ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }
        public static void ProgressBar (int line, double val, double max, string title)
        {
            int full = (int) Math.Round(val * ConsoleWidth / max);
            ConsoleUtilities.ReplaceLine(line, title);
            ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, decimal val, decimal max, string title)
        {
            int full = (int) Math.Round(val * ConsoleWidth / max);
            ConsoleUtilities.ReplaceLine(line, title);
            ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(full - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - full - 1)}]");
        }

        public static void ProgressBar (int line, int val, int max, string title, BarArangement style)
        {
            switch (style)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}]");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100d / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100d / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}]");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100d / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}]");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, float val, float max, string title, BarArangement style)
        {
            switch (style)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}]");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}]");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}]");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, double val, double max, string title, BarArangement style)
        {
            switch (style)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}]");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}]");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}]");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement style)
        {
            switch (style)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}]");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}]");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}]");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"[{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, '|')}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}]");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, int val, int max, string title, BarArangement arangement, BarLook style)
        {

            (char border1, char border2, char filling) = style switch
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

            switch (arangement)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}{border2}");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100d / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100d / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100d / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = val * ConsoleWidth / max;
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100d / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, float val, float max, string title, BarArangement arangement, BarLook style)
        {

            (char border1, char border2, char filling) = style switch
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

            switch (arangement)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}{border2}");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, double val, double max, string title, BarArangement arangement, BarLook style)
        {

            (char border1, char border2, char filling) = style switch
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

            switch (arangement)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}{border2}");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

        public static void ProgressBar (int line, decimal val, decimal max, string title, BarArangement arangement, BarLook style)
        {

            (char border1, char border2, char filling) = style switch
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

            switch (arangement)
            {
                case BarArangement.BarOnly:
                    ProgressBar(line, val, max);
                    break;
                case BarArangement.BarWithTitle:
                    ProgressBar(line, val, max, title);
                    break;
                case BarArangement.BarWithTitleCentered:
                    int fullBarWithTitleCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCentered - 1)}{border2}");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnder:
                    int fullBarWithTitleAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleAndPercentageUnderCentered:
                    int fullBarWithTitleAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleAndPercentageInBar:
                    int fullBarWithTitleAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)} %", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercentageUnder:
                    int fullBarWithTitleCenteredAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageUnderCentered:
                    int fullBarWithTitleCenteredAndPercantageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 2, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarWithTitleCenteredAndPercantageInBar:
                    int fullBarWithTitleCenteredAndPercantageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, title, true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarWithTitleCenteredAndPercantageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarWithTitleCenteredAndPercantageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageUnder:
                    int fullBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndPercentageUnderCentered:
                    int fullBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndPercentageInBar:
                    int fullBarAndPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentage:
                    int fullBarAndTitleFolowedByPercentage = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%");
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentage - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentage - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageCentered:
                    int fullBarAndTitleFolowedByPercentageCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageCentered - 1)}{border2}");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnder:
                    int fullBarAndTitleInBarAndPercentageUnder = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnder - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnder - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%");
                    break;
                case BarArangement.BarAndTitleInBarAndPercentageUnderCentered:
                    int fullBarAndTitleInBarAndPercentageUnderCentered = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleInBarAndPercentageUnderCentered - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleInBarAndPercentageUnderCentered - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, title, true);
                    ConsoleUtilities.ReplaceLine(line + 1, $"{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                case BarArangement.BarAndTitleFolowedByPercentageInBar:
                    int fullBarAndTitleFolowedByPercentageInBar = (int) Math.Round(val * ConsoleWidth / max);
                    ConsoleUtilities.ReplaceLine(line, $"{border1}{ConsoleUtilities.GetCharakters(fullBarAndTitleFolowedByPercentageInBar - 1, filling)}{ConsoleUtilities.GetSpaces(ConsoleWidth - fullBarAndTitleFolowedByPercentageInBar - 1)}{border2}");
                    ConsoleUtilities.OverwriteLine(line, $"{title}{Math.Round(val * 100 / max, 2)}%", true, false);
                    break;
                default:
                    return;
            }
        }

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
    }

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
