using ConsoleUtils;
using System.Data;

namespace ConsoleUtils_Testing
{
    internal class Program
    {
        static void Main (string[] args)
        {
            ConsoleOptions.SystemMenu.DisableConsoleResize(true);
            ConsoleOptions.SystemMenu.DisableConsoleMaximize(true);
            ConsoleOptions.SystemMenu.DisableConsoleMinimize(true);
            ConsoleOptions.SystemMenu.DisableConsoleClose(true);

            DataTable table= new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(uint));

            for (int i = 0 ; i < 100 ; i++)
            {
                table.Rows.Add(ConsoleUtilities.GetCharakters(i, 'a'), i);
            }

            //ConsoleOptions.SystemMenu.DisableConsoleClose(false);

            Console.ReadLine();

            //ConsoleIO.PrintFolder(1, new DirectoryInfo("C:\\Users\\vossk\\Desktop\\Programme"), IOSorting.SizeAsending, TableLook.DoubleLines, new IOColums[] { IOColums.Name, IOColums.Size, IOColums.Extension, IOColums.FullName });
        }
    }
}