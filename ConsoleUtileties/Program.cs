using System;
using System.Threading;
using System.Drawing;
using ConsoleUtileties;

namespace ConsoleUtilitiesLibary
{
    public class Program
    {
        public static void Main (string[] args)
        {
            ConsoleInputListener list = new();
            list.OnKeyEvent += (args) => {
                //Console.WriteLine(args.ToString());

            };
            list.StartListening(new CancellationToken(false));

            Clipbord.SetClipboard("Hallo Uhrzeiz: {0}", DateTime.Now.ToLongTimeString());

            Console.WriteLine("Copy Something");
            Console.ReadLine();

            Console.WriteLine(Clipbord.TryGetClipbord(out string d));
            Console.WriteLine(d);

            ConsoleOptions.SystemMenu.DisableConsoleClose(false);

            ConsoleOptions.ConsoleOutput.DisableVirtualTerminalProcessing(false);

            ConsoleOptions.EnableRGBConsoleMode();

            ConsoleUtilities.SetRGBConsoleForegroundColor(Color.Red);

            Console.WriteLine();


            Console.ReadLine();
        }

    }

}
