using System;
using System.Threading;
using System.Drawing;

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
