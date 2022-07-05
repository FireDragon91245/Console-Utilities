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
            ConsoleIO.PrintFolder(1, @"C:\", IOSorting.SizeAsending, TableLook.DoubleLines, new IOColums[] { IOColums.Name, IOColums.Extension, IOColums.CreationDate, IOColums.Size });
        }
    }
}
