using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Drawing;

namespace ConsoleUtilities
{

    public class Program
    {
        public static void Main (string[] args)
        {
            /* 
             * This class is just for debuging and testing becourse you dont need a Programm Class or Main Function
             * in asemblys!!!
             */
            BarColor col = new()
            {
                BarCasingForegroundColor = Color.Aqua,
                BarProgressForegroundColor = Color.Red,
                PercentageForegroundColor = Color.Orange
            };
            ConsoleBars.ProgressBar(1, 10, 100, "hey", BarArangement.BarAndTitleFolowedByPercentageInBar, BarLook.StarFilling, col);
            return;
        }
    }
}
