using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using System.Runtime.CompilerServices;

[assembly: DisableRuntimeMarshalling]

namespace ConsoleUtilitiesLibary.ConsoleInput
{
    /// <summary>
    /// Listen to Key and mouse Events!
    /// 
    /// WARNING: Be carefull with creating many instances of this class each instance will slow down the others try to keep only 1 istance.
    /// </summary>
    public partial class ConsoleInputListener
    {

        //EventType
        private const int KEY_EVENT = 1;
        private const int MOUSE_EVENT = 2;

        //dwControlKeyState
        private const int CAPSLOCK_ON = 0x0080;
        private const int ENHANCED_KEY = 0x0100;
        private const int LEFT_ALT_PRESSED = 0x0002;
        private const int LEFT_CTRL_PRESSED = 0x0008;
        private const int NUMLOCK_ON = 0x0020;
        private const int RIGHT_ALT_PRESSED = 0x0001;
        private const int RIGHT_CTRL_PRESSED = 0x0004;
        private const int SCROLLLOCK_ON = 0x0040;
        private const int SHIFT_PRESSED = 0x0010;

        //dwButtonState
        private const int FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001;
        private const int FROM_LEFT_2ND_BUTTON_PRESSED = 0x0004;
        private const int FROM_LEFT_3RD_BUTTON_PRESSED = 0x0008;
        private const int FROM_LEFT_4TH_BUTTON_PRESSED = 0x0010;
        private const int RIGHTMOST_BUTTON_PRESSED = 0x0002;

        //dwEventFlags
        private const int DOUBLE_CLICK = 0x0002;
        private const int MOUSE_HWHEELED = 0x0008;
        private const int MOUSE_MOVED = 0x0001;
        private const int MOUSE_WHEELED = 0x0004;


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
            ConsoleOptions.ConsoleInput.DisableQuickEditMode(true);
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
                        InvokeMouseEvent(record.MouseEvent);
                        break;
                    case KEY_EVENT:
                        InvokeKeyEvent(record.KeyEvent);
                        break;
                }
            }
        }

        //Did you knwo ALT-GR = R-ALT + CTRL
        private void InvokeKeyEvent(InputRecords.KEY_EVENT_RECORD keyEvent)
        {
            if (OnKeyEvent is null)
                return;
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
            if (OnMouseEvent is null)
                return;
            var args = new MouseEventArgs(mouseEvent.dwMousePosition.X,
                                          mouseEvent.dwMousePosition.Y,
                                          mouseEvent.dwControlKeyState,
                                          mouseEvent.dwButtonState,
                                          mouseEvent.dwEventFlags,

                                          MatchPattern(mouseEvent.dwControlKeyState, LEFT_ALT_PRESSED),
                                          MatchPattern(mouseEvent.dwControlKeyState, LEFT_CTRL_PRESSED),
                                          MatchPattern(mouseEvent.dwControlKeyState, SHIFT_PRESSED),
                                          MatchPattern(mouseEvent.dwControlKeyState, CAPSLOCK_ON),
                                          MatchPattern(mouseEvent.dwControlKeyState, RIGHT_ALT_PRESSED),
                                          MatchPattern(mouseEvent.dwControlKeyState, RIGHT_CTRL_PRESSED),
                                          MatchPattern(mouseEvent.dwControlKeyState, ENHANCED_KEY),
                                          MatchPattern(mouseEvent.dwControlKeyState, NUMLOCK_ON),
                                          MatchPattern(mouseEvent.dwControlKeyState, SCROLLLOCK_ON),
                                          
                                          MatchPattern(mouseEvent.dwButtonState, FROM_LEFT_1ST_BUTTON_PRESSED),
                                          MatchPattern(mouseEvent.dwButtonState, FROM_LEFT_2ND_BUTTON_PRESSED),
                                          MatchPattern(mouseEvent.dwButtonState, FROM_LEFT_3RD_BUTTON_PRESSED),
                                          MatchPattern(mouseEvent.dwButtonState, FROM_LEFT_4TH_BUTTON_PRESSED),
                                          MatchPattern(mouseEvent.dwButtonState, RIGHTMOST_BUTTON_PRESSED),
                                          
                                          MatchPattern(mouseEvent.dwEventFlags, DOUBLE_CLICK),
                                          MatchPattern(mouseEvent.dwEventFlags, MOUSE_HWHEELED),
                                          MatchPattern(mouseEvent.dwEventFlags, MOUSE_MOVED),
                                          MatchPattern(mouseEvent.dwEventFlags, MOUSE_WHEELED),

                                          ( mouseEvent.dwButtonState >> 16 ) > 0 );

            OnMouseEvent.Invoke(args);
        }

        internal class ConsoleHandle : SafeHandleMinusOneIsInvalid
        {
            public ConsoleHandle() : base(false) { }
            protected override bool ReleaseHandle()
            {
                return true;
            }
        }

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool GetConsoleMode(ConsoleHandle hConsoleHandle, ref int lpMode);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        internal static partial ConsoleHandle GetStdHandle(int nStdHandle);

        [LibraryImport("kernel32.dll", SetLastError = true, EntryPoint = "ReadConsoleInputA")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool ReadConsoleInput(ConsoleHandle hConsoleInput, ref InputRecords.INPUT_RECORD lpBuffer, uint nLength, ref uint lpNumberOfEventsRead);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool SetConsoleMode(ConsoleHandle hConsoleHandle, int dwMode);
    }
}
