using System;
using System.Threading;
using System.Drawing;
using System.IO;
using ConsoleUtils.ClipbordUtils;
using ConsoleUtils.ConsoleInput;
using System.Threading.Tasks;

namespace ConsoleUtils
{
    public class Program
    {
        public static void Main (string[] args)
        {
            int c1 = 0;
            int c2 = 0;
            ConsoleInputListener list = new();
            ConsoleInputListener list2 = new();
            list.OnKeyEvent += (args) => {
                Console.SetCursorPosition(0, 2);
                c1++;
                Console.WriteLine($"l1: {c1}");
            };
            list2.OnKeyEvent += (args) =>
            {
                Console.SetCursorPosition(0, 4);
                c2++;
                Console.WriteLine($"l1: {c2}");
            };
            list.StartListening(new CancellationToken(false));
            list2.StartListening(new CancellationToken(false));

            while (true)
            {
                Task.Delay(10).GetAwaiter().GetResult();
            }
        }

    }

}
