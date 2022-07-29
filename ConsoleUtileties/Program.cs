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
            ConsoleOptions.EnableRGBConsoleMode();
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("num", typeof(int));
            for (int i = 0 ; i < 111 ; i++)
            {
                dt.Rows.Add(new object[] {ConsoleUtilities.GetCharakters(i, 'a'), i});
            }
            TableColor color = new TableColor();
            color.BorderForegroundColor = Color.Red;
            color.columnForegroundColors = new Color[] {Color.LightGreen, Color.Blue};
            color.headerForegroundColors = new Color[] { Color.Purple };
            ConsoleTables.PrintTable(1, dt, TableLook.DoubleLines, color, true);
            Console.SetCursorPosition(0, 200);
            return;
        }
    }
}
