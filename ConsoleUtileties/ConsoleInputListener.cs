using System;
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

namespace ConsoleUtilitiesLibary
{
    public class ConsoleInputListener
    {

        private const int KEY_EVENT = 1;
        private const int MOUSE_EVENT = 2;

        private const int CONTROL_CODE_ALT = 0b0000000010;
        private const int CONTROL_CODE_STRG = 0b0000001000;
        private const int CONTROL_CODE_SHIFT = 0b0000010000;
        private const int CONTROL_CODE_CAPS = 0b0010000000;
        private const int CONTROL_CODE_ALTGR = 0b0100001001;
        private const int CONTROL_CODE_RIGHT_STRG = 0b0010000100;

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
            InputRecords.INPUT_RECORD record = new InputRecords.INPUT_RECORD();
            while (true)
            {
                ReadConsoleInput(handle, ref record, 1, ref numRead);

                switch (record.EventType)
                {
                    case MOUSE_EVENT:
                        InvokeMouseEvent(record.MouseEvent);
                        break;
                    case KEY_EVENT:
                        InvokeKeyEvent(record.KeyEvent);
                        break;
                }
            }
        }

        private void InvokeKeyEvent(InputRecords.KEY_EVENT_RECORD keyEvent)
        {
            var args = new KeyEventArgs(keyEvent.UnicodeChar,
                                        keyEvent.wVirtualKeyCode,
                                        keyEvent.AsciiChar,
                                        keyEvent.dwControlKeyState,
                                        MatchPattern(keyEvent.dwControlKeyState, CONTROL_CODE_ALT),
                                        MatchPattern(keyEvent.dwControlKeyState, CONTROL_CODE_STRG),
                                        MatchPattern(keyEvent.dwControlKeyState, CONTROL_CODE_SHIFT),
                                        MatchPattern(keyEvent.dwControlKeyState, CONTROL_CODE_CAPS),
                                        MatchPattern(keyEvent.dwControlKeyState, CONTROL_CODE_ALTGR),
                                        MatchPattern(keyEvent.dwControlKeyState, CONTROL_CODE_RIGHT_STRG));

            OnKeyEvent.Invoke(args);
        }

        private bool MatchPattern(int dwControlKeyState, int code, params int[] coisions)
        {
            throw new NotImplementedException();
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


        [DllImportAttribute("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleMode(ConsoleHandle hConsoleHandle, Int32 dwMode);
    }
}
