using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;

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
            DataTable dt = new DataTable();
            dt.Columns.Add("Col1", typeof(int));
            dt.Columns.Add("col2", typeof(string));
            dt.Columns.Add("col3", typeof(DateTime));
            for (int i = 0 ; i < 1000 ; i++)
            {
                dt.Rows.Add(new object[] { i, ConsoleUtilities.GetCharakters(i / 5, 'a'), DateTime.Now });
            }
            ConsoleLists.PrintSmartList(1, dt, TableLook.DoubleLines, 100);
            return;
        }
    }
}
