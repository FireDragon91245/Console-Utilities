using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Drawing;
using Microsoft.Win32.SafeHandles;
using static ConsoleUtileties.InputRecords;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using ConsoleUtileties;

namespace ConsoleUtilitiesLibary
{
    public class Program
    {
        public static void Main (string[] args)
        {
            ConsoleInputListener list = new();
            list.StartListening(new CancellationToken(false));

            ConsoleOptions.SystemMenu.DisableConsoleClose(true);

            ConsoleOptions.EnableRGBConsoleMode();

            ConsoleUtilities.SetRGBConsoleForegroundColor(Color.Red);

            Console.WriteLine();


            Console.ReadLine();
        }

    }

}
