using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ConsoleUtilitiesLibary
{
    /// <summary>
    /// Class to customize The Console like Disabling the red X
    /// </summary>
    public static class ConsoleOptions
    {
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_SIZE = 0xF000;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_CLOSE = 0xF060;

        private static readonly List<int> DisabledAdresses = new();

        /// <summary>
        /// Resets all modifikations on the console
        /// </summary>
        public static void EnableAll ()
        {
            DisabledAdresses.Clear();
            ResetWindowMenu();
        }

        /// <summary>
        /// Disables everything:
        /// Resizing, Red X, Minimize, Maximize
        /// </summary>
        public static void DisableAll ()
        {
            DisableConsoleResize(true);
            DisableConsoleMinimize(true);
            DisableConsoleMaximize(true);
            DisableConsoleClose(true);
        }

        /// <summary>
        /// Disables or Enables The Resizabliety of The Console
        /// </summary>
        /// <param name="setTo">if true Disabled if false Enabled</param>
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

        /// <summary>
        /// Disables the Minimize button on the Console
        /// </summary>
        /// <param name="setTo">if true Disabled if false Enabled</param>
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

        /// <summary>
        /// Disables the Maximize button an the Console
        /// </summary>
        /// <param name="setTo">if true Disabled if false Enabled</param>
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

        /// <summary>
        /// Disables The Close button (Red X) on the console
        /// </summary>
        /// <param name="setTo">if true Disabled if false Enabled</param>
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

        private static int Mode = -1;
        /// <summary>
        /// Switch the Console mode to a RGB cabable mode
        /// </summary>
        public static void EnableRGBConsoleMode ()
        {
            IntPtr handle = GetStdHandle(-11);
            GetConsoleMode(handle, out int mode);
            Mode = mode;
            SetConsoleMode(handle, mode | 0x4);
        }

        internal static bool IsRGBModeEnabled ()
        {
            return Mode != -1;
        }

        /// <summary>
        /// Disables the RGB mode if enabled with <see cref="EnableRGBConsoleMode"/>
        /// </summary>
        public static void DisableRGBConsoleMode ()
        {
            if (Mode == -1)
                return;
            IntPtr handle = GetStdHandle(-11);
            SetConsoleMode(handle, Mode);
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

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode (IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode (IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle (int handle);
    }
}
