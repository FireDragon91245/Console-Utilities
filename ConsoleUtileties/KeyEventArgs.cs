using System;

namespace ConsoleUtilitiesLibary
{
    public sealed class KeyEventArgs
    {

        public KeyEventArgs(char unicode, int virtualKeyCode, byte asciChar, int controlCode, bool altPressed, bool strgPressed, bool shiftPressed, bool capSlot, bool altGr, bool strgRigth, bool enchanced, bool numsLock, bool scrolLock)
        {
            UnicodeChar = unicode;
            VirtualKeyCode = virtualKeyCode;
            ASCIIByte = asciChar;
            ControlCode = controlCode;
            AltPressed = altPressed;
            StrgPressed = strgPressed;
            ShiftPressed = shiftPressed;
            CapsLockActivatet = capSlot;
            AltGrPressed = altGr;
            StrgRigthPressed = strgRigth;
            KeyEnchanced = enchanced;
            NumLockActivtet = numsLock;
            ScrolLockActivatet = scrolLock;
        }

        public char UnicodeChar
        { 
            get;
        }
        public int VirtualKeyCode
        { 
            get;
        }
        public ConsoleKey ConsoleKey
        {
            get
            {
                return (ConsoleKey)VirtualKeyCode;
            }
        }
        public byte ASCIIByte
        { 
            get;
        }
        public int ControlCode
        { 
            get;
        }
        public bool AltPressed
        { 
            get;
        }
        public bool StrgPressed
        { 
            get;
        }
        public bool ShiftPressed
        { 
            get;
        }
        public bool CapsLockActivatet
        { 
            get;
        }
        public bool AltGrPressed
        { 
            get;
        }
        public bool StrgRigthPressed
        { 
            get;
        }
        public bool KeyEnchanced
        {
            get;
        }
        public bool NumLockActivtet
        { 
            get;
        }
        public bool ScrolLockActivatet
        { 
            get;
        }

        public override string ToString()
        {
            return $"""
                Strg: {StrgPressed}
                Alt:  {AltPressed}
                Shift:{ShiftPressed}
                RStrg:{StrgRigthPressed}
                RAlt: {AltGrPressed}
                NumLock: {NumLockActivtet}
                CAPS: {CapsLockActivatet}
                """;
        }
    }
}