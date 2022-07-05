using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleExtension
{
    public static class ConsoleOptions
    {
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_SIZE = 0xF000;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_CLOSE = 0xF060;

        private static List<int> DisabledAdresses = new();

        public static void EnableAll ()
        {
            DisabledAdresses.Clear();
            ResetWindowMenu();
        }

        public static void DisableAll ()
        {
            DisableConsoleResize(true);
            DisableConsoleMinimize(true);
            DisableConsoleMaximize(true);
            DisableConsoleClose(true);
        }

        public static void DisableConsoleResize (bool setTo = false)
        {
            if (setTo)
            {
                DisableCustomAdress(SC_SIZE);
            }
            else
            {
                EnableCustomAdress(SC_SIZE);
            }
        }

        public static void DisableConsoleMinimize (bool setTo = false)
        {
            if (setTo)
            {
                DisableCustomAdress(SC_MINIMIZE);
            }
            else
            {
                EnableCustomAdress(SC_MINIMIZE);
            }
        }

        public static void DisableConsoleMaximize (bool setTo = false)
        {
            if (setTo)
            {
                DisableCustomAdress(SC_MAXIMIZE);
            }
            else
            {
                EnableCustomAdress(SC_MAXIMIZE);
            }
        }

        public static void DisableConsoleClose (bool setTo = false)
        {
            if (setTo)
            {
                DisableCustomAdress(SC_CLOSE);
            }
            else
            {
                EnableCustomAdress(SC_CLOSE);
            }
        }

        private static void DisableCustomAdress (int adress)
        {
            if (!DisabledAdresses.Contains(adress))
                DisabledAdresses.Add(adress);
            IntPtr consoleWindow = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(consoleWindow, false);
            if (sysMenu != IntPtr.Zero)
            {
                _ = DeleteMenu(sysMenu, adress, MF_BYCOMMAND);
            }
            _ = DrawMenuBar(consoleWindow);
        }

        private static void EnableCustomAdress (int adress)
        {
            DisabledAdresses.Remove(adress);
            ResetWindowMenu();
            foreach (int adr in DisabledAdresses)
            {
                DisableCustomAdress(adr);
            }
        }

        private static void ResetWindowMenu ()
        {
            IntPtr consoleWindow = GetConsoleWindow();
            _ = GetSystemMenu(consoleWindow, true);
        }

        [DllImport("user32.dll")]
        private static extern int DrawMenuBar (IntPtr consoleWindow);

        [DllImport("user32.dll")]
        private static extern int DeleteMenu (IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow ();

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu (IntPtr hWnd, bool bRevert);
    }
}
