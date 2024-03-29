﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleUtils
{
    /// <summary>
    /// Class to customize The Console like Disabling the red X
    /// </summary>
    public static partial class ConsoleOptions
    {
        private const int STD_INPUT_HANDLE = -10;
        private const int STD_OUTPUT_HANDLE = -11;
        //internal const int STD_ERROR_HANDLE = -12;

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool SetConsoleMode(ConsoleHandle hConsoleHandle, int mode);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool GetConsoleMode(ConsoleHandle handle, ref int mode);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        private static partial ConsoleHandle GetStdHandle (int handle);


        private static void DisableCustomAdress (ConsoleHandle handle, int adress)
        {
            int mode = 0;
            GetConsoleMode(handle, ref mode);
            mode &= ~adress;
            SetConsoleMode(handle, mode);
        }

        private static void EnableCustomAdress (ConsoleHandle handle, int adress)
        {
            int mode = 0;
            GetConsoleMode(handle, ref mode);
            mode |= adress;
            SetConsoleMode(handle, mode);
        }

        public static ConsoleHandle ConsoleInputHandle
        {
            get
            {
                return GetStdHandle(STD_INPUT_HANDLE);
            }
        }

        public static ConsoleHandle ConsoleOutputHandle
        {
            get
            {
                return GetStdHandle(STD_OUTPUT_HANDLE);
            }
        }

        public static partial class SystemMenu
        {
            private static readonly List<uint> DisabledMenuItems = new();

            private const uint MF_BYCOMMAND = 0x00000000;

            private const int SC_SIZE = 0xF000;
            private const int SC_MINIMIZE = 0xF020;
            private const int SC_MAXIMIZE = 0xF030;
            private const int SC_CLOSE = 0xF060;

            [LibraryImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static partial bool DrawMenuBar(IntPtr consoleWindow);

            [LibraryImport("user32.dll")]
            private static partial IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

            [LibraryImport("kernel32.dll")]
            private static partial IntPtr GetConsoleWindow();

            [LibraryImport("user32.dll")]
            private static partial uint DeleteMenu (IntPtr hMenu, uint pos, uint uFlag);

            public static void ResetSystemMenu()
            {
                IntPtr consoleWindow = GetConsoleWindow();
                _ = GetSystemMenu(consoleWindow, true);
            }

            private static void DisableMenuItem(uint pos)
            {
                if (!DisabledMenuItems.Contains(pos))
                {
                    DisabledMenuItems.Add(pos);
                }
                IntPtr consoleWindow = GetConsoleWindow();
                IntPtr sysMenu = GetSystemMenu(consoleWindow, false);
                _ = DeleteMenu(sysMenu, pos, MF_BYCOMMAND);
                _ = DrawMenuBar(consoleWindow);
            }

            private static void EnableMenuItem(uint pos)
            {
                IntPtr consoleWindow = GetConsoleWindow();
                ResetSystemMenu();
                IntPtr sysMenu = GetSystemMenu(consoleWindow, false);
                DisabledMenuItems.RemoveAll(val => val == pos);

                foreach (var item in DisabledMenuItems)
                {
                    _ = DeleteMenu(sysMenu, item, MF_BYCOMMAND);
                }
                _ = DrawMenuBar(consoleWindow);
            }

            /// <summary>
            /// Disables or Enables The Resizabliety of The Console
            /// </summary>
            /// <param name="setTo">if true Disabled if false Enabled</param>
            public static void DisableConsoleResize (bool setTo = false)
            {
                if (setTo)
                {
                    DisableMenuItem(SC_SIZE);
                }
                else
                {
                    EnableMenuItem(SC_SIZE);
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
                    DisableMenuItem(SC_MINIMIZE);
                }
                else
                {
                    EnableMenuItem(SC_MINIMIZE);
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
                    DisableMenuItem(SC_MAXIMIZE);
                }
                else
                {
                    EnableMenuItem(SC_MAXIMIZE);
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
                    DisableMenuItem(SC_CLOSE);
                }
                else
                {
                    EnableMenuItem(SC_CLOSE);
                }
            }

        }

        public static class ConsoleInput
        {
            private const int ENABLE_ECHO_INPUT = 0x0004;
            private const int ENABLE_INSERT_MODE = 0x0020;
            private const int ENABLE_LINE_INPUT = 0x0002;
            private const int ENABLE_MOUSE_INPUT = 0x0010;
            private const int ENABLE_PROCESSED_INPUT = 0x0001;
            private const int ENABLE_QUICK_EDIT_MODE = 0x0040;
            private const int ENABLE_WINDOW_INPUT = 0x0080;
            private const int ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200;
            private const int ENABLE_EXTENDED_FLAGS = 0x0080;

            public static void DisableEchoInput(bool disable)
            {
                if (disable)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_ECHO_INPUT);
                }
                else
                {
                    DisableEchoInput(false);
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_ECHO_INPUT);
                }
            }

            public static void DisableInsertMode(bool disable)
            {
                if (disable)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_INSERT_MODE);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_INSERT_MODE);
                }
            }

            public static void DisableLineInput(bool disable)
            {
                if (disable)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_LINE_INPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_LINE_INPUT);
                }
            }


            public static void DisableMouseInput(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_MOUSE_INPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_MOUSE_INPUT);
                }
            }

            public static void DisableProcessInput(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_PROCESSED_INPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_PROCESSED_INPUT);
                }
            }
            public static void DisableQuickEditMode(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_EXTENDED_FLAGS);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_QUICK_EDIT_MODE | ENABLE_EXTENDED_FLAGS);
                }
            }

            public static void DisableWindowInput(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_WINDOW_INPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_WINDOW_INPUT);
                }
            }

            public static void DisableVirtualTerminalInput(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleInputHandle, ENABLE_VIRTUAL_TERMINAL_INPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleInputHandle, ENABLE_VIRTUAL_TERMINAL_INPUT);
                }
            }
        }

        public static class ConsoleOutput
        {
            internal const int ENABLE_PROCESSED_OUTPUT = 0x0001;
            internal const int ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002;
            internal const int ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
            internal const int DISABLE_NEWLINE_AUTO_RETURN = 0x0008;
            internal const int ENABLE_LVB_GRID_WORLDWIDE = 0x0010;

            public static void DisableProcessOutput(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleOutputHandle, ENABLE_PROCESSED_OUTPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleOutputHandle, ENABLE_PROCESSED_OUTPUT);
                }
            }

            public static void DisableWrapAtEOLOutput(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleOutputHandle, ENABLE_WRAP_AT_EOL_OUTPUT);
                }
                else
                {
                    EnableCustomAdress(ConsoleOutputHandle, ENABLE_WRAP_AT_EOL_OUTPUT);
                }
            }

            public static void DisableVirtualTerminalProcessing(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleOutputHandle, ENABLE_VIRTUAL_TERMINAL_PROCESSING);
                }
                else
                {
                    EnableCustomAdress(ConsoleOutputHandle, ENABLE_VIRTUAL_TERMINAL_PROCESSING);
                }
            }

            public static void DisablePNewLineAutoReturn(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleOutputHandle, DISABLE_NEWLINE_AUTO_RETURN);
                }
                else
                {
                    EnableCustomAdress(ConsoleOutputHandle, DISABLE_NEWLINE_AUTO_RETURN);
                }
            }

            public static void DisableLVBGridWorldwide(bool setTo)
            {
                if (setTo)
                {
                    DisableCustomAdress(ConsoleOutputHandle, ENABLE_LVB_GRID_WORLDWIDE);
                }
                else
                {
                    EnableCustomAdress(ConsoleOutputHandle, ENABLE_LVB_GRID_WORLDWIDE);
                }
            }
        }

        public static void EnableRGBConsoleMode ()
        {
            ConsoleOutput.DisableVirtualTerminalProcessing(false);
            ConsoleOutput.DisableProcessOutput(false);
        }

        internal static bool IsRGBModeEnabled ()
        {
            int mode = 0;
            GetConsoleMode(ConsoleOutputHandle, ref mode);
            int enabledMode = mode;
            enabledMode |= ConsoleOutput.ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            enabledMode |= ConsoleOutput.ENABLE_PROCESSED_OUTPUT;
            return enabledMode == mode;
        }

        /// <summary>
        /// Disables the RGB mode if enabled with <see cref="EnableRGBConsoleMode"/>
        /// </summary>
        public static void DisableRGBConsoleMode()
        {
            ConsoleOutput.DisableVirtualTerminalProcessing(true);
            ConsoleOutput.DisableProcessOutput(true);
        }
    }
}
