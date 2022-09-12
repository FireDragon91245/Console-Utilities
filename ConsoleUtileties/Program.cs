using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Drawing;

namespace ConsoleUtilitiesLibary
{

    public class Program
    {
        public static void Main (string[] args)
        {
            /* 
             * This class is just for debuging and testing becourse you dont need a Programm Class or Main Function
             * in asemblys!!!
             */
            TableColor color = new TableColor(){
                BorderForegroundColor = Color.Purple,
                columnForegroundColors = new Color[] { Color.Red, Color.Green }
            };
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ID", typeof(int));
            for (int i = 0 ; i < 100 ; i++)
            {
                table.Rows.Add(new object[] { ConsoleUtilities.GetCharakters(i, 'a'), i });
            }
            ConsoleLists.PrintSmartList(1, table, TableLook.DoubleLines, color, 5, false);
            return;
        }
    }
}
