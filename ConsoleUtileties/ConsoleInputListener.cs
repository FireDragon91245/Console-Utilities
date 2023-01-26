﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.NetworkInformation;
using Microsoft.Win32.SafeHandles;
using ConsoleUtileties;
using System.Collections.Immutable;

namespace ConsoleUtilitiesLibary
{
    public class ConsoleInputListener
    {

        private const int KEY_EVENT = 1;
        private const int MOUSE_EVENT = 2;

        private const int CAPSLOCK_ON = 0x0080;
        private const int ENHANCED_KEY = 0x0100;
        private const int LEFT_ALT_PRESSED = 0x0002;
        private const int LEFT_CTRL_PRESSED = 0x0008;
        private const int NUMLOCK_ON = 0x0020;
        private const int RIGHT_ALT_PRESSED = 0x0001;
        private const int RIGHT_CTRL_PRESSED = 0x0004;
        private const int SCROLLLOCK_ON = 0x0040;
        private const int SHIFT_PRESSED = 0x0010;

        private Thread Thread
        {
            get;
            init;
        }

        private CancellationToken CancellationToken
        {
            get;
            set;
        }

        public delegate void MouseEventHandler (MouseEventArgs args);

        public event MouseEventHandler OnMouseEvent;

        public delegate void KeyEventHandler (KeyEventArgs args);

        public event KeyEventHandler OnKeyEvent;

        public ConsoleInputListener()
        {
            Thread = new Thread(Listen);
        }

        public void StartListening(CancellationToken token)
        {
            ConsoleOptions.ConsoleInput.DisableMouseInput(false);
            ConsoleOptions.ConsoleInput.DisableWindowInput(false);
            CancellationToken = token;
            Thread.Start();
        }

        private void Listen()
        {
            uint numRead = 0;
            var handle = GetStdHandle(-10);
            InputRecords.INPUT_RECORD record = new();
            while (!CancellationToken.IsCancellationRequested)
            {
                ReadConsoleInput(handle, ref record, 1, ref numRead);

                switch (record.EventType)
                {
                    case MOUSE_EVENT:
                        if (OnMouseEvent is null)
                            return;
                        InvokeMouseEvent(record.MouseEvent);
                        break;
                    case KEY_EVENT:
                        if (OnKeyEvent is null)
                            return;
                        InvokeKeyEvent(record.KeyEvent);
                        break;
                }
            }
        }

        //Did you knwo ALT-GR = R-ALT + CTRL
        private void InvokeKeyEvent(InputRecords.KEY_EVENT_RECORD keyEvent)
        {
            var args = new KeyEventArgs(keyEvent.UnicodeChar,
                                        keyEvent.wVirtualKeyCode,
                                        keyEvent.AsciiChar,
                                        keyEvent.dwControlKeyState,
                                        MatchPattern(keyEvent.dwControlKeyState, LEFT_ALT_PRESSED),
                                        MatchPattern(keyEvent.dwControlKeyState, LEFT_CTRL_PRESSED),
                                        MatchPattern(keyEvent.dwControlKeyState, SHIFT_PRESSED),
                                        MatchPattern(keyEvent.dwControlKeyState, CAPSLOCK_ON),
                                        MatchPattern(keyEvent.dwControlKeyState, RIGHT_ALT_PRESSED),
                                        MatchPattern(keyEvent.dwControlKeyState, RIGHT_CTRL_PRESSED),
                                        MatchPattern(keyEvent.dwControlKeyState, ENHANCED_KEY),
                                        MatchPattern(keyEvent.dwControlKeyState, NUMLOCK_ON),
                                        MatchPattern(keyEvent.dwControlKeyState, SCROLLLOCK_ON));

            OnKeyEvent.Invoke(args);
        }

        private static bool MatchPattern(int pattern, int code)
        {
            pattern &= code;
            return pattern == code;
        }

        private void InvokeMouseEvent(InputRecords.MOUSE_EVENT_RECORD mouseEvent)
        {
            throw new NotImplementedException();
        }

        internal class ConsoleHandle : SafeHandleMinusOneIsInvalid
        {
            public ConsoleHandle() : base(false) { }
            protected override bool ReleaseHandle()
            {
                return true;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetConsoleMode(ConsoleHandle hConsoleHandle, ref int lpMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern ConsoleHandle GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadConsoleInput(ConsoleHandle hConsoleInput, ref InputRecords.INPUT_RECORD lpBuffer, uint nLength, ref uint lpNumberOfEventsRead);


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetConsoleMode(ConsoleHandle hConsoleHandle, int dwMode);
    }
}
