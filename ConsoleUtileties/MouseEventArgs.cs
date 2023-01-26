namespace ConsoleUtilitiesLibary
{
    public class MouseEventArgs
    {
        public MouseEventArgs (ushort MouseX, ushort MouseY, int ControlKeyState, int ButtonState, int EventFlags, bool LeftAltPressed, bool LeftCtrlPressed, bool ShiftPressed, bool CapsLockActivatet, bool RightAltPressed, bool RightCtrlPressed, bool EnhancedKey, bool NumLockActivatet, bool ScrolLockActivatet, bool Button1Pressed, bool Button2Pressed, bool Button3Pressed, bool Button4Pressed, bool RightMostButtonPressed, bool DoubleClicked, bool HorisontalMouseWheelMoved, bool MouseMoved, bool VerticalMouseWheelMoved, bool MouseWheelMoveDirection)
        {
            this.MouseX = MouseX;
            this.MouseY = MouseY;
            this.ControlKeyState = ControlKeyState;
            this.ButtonState = ButtonState;
            this.EventFlags = EventFlags;
            this.LeftAltPressed = LeftAltPressed;
            this.LeftCtrlPressed = LeftCtrlPressed;
            this.ShiftPressed = ShiftPressed;
            this.CapsLockActivatet = CapsLockActivatet;
            this.RightAltPressed = RightAltPressed;
            this.RightCtrlPressed = RightCtrlPressed;
            this.EnhancedKey = EnhancedKey;
            this.NumLockActivatet = NumLockActivatet;
            this.ScrolLockActivatet = ScrolLockActivatet;
            this.Button1Pressed = Button1Pressed;
            this.Button2Pressed = Button2Pressed;
            this.Button3Pressed = Button3Pressed;
            this.Button4Pressed = Button4Pressed;
            this.RightMostButtonPressed = RightMostButtonPressed;
            this.DoubleClicked = DoubleClicked;
            this.HorisontalMouseWheelMoved = HorisontalMouseWheelMoved;
            this.MouseMoved = MouseMoved;
            this.VerticalMouseWheelMoved = VerticalMouseWheelMoved;
            this.MouseWheelMoveDirection = MouseWheelMoveDirection;
        }

        public ushort MouseX
        {
            get;
        }
        public ushort MouseY
        {
            get;
        }
        public int ControlKeyState
        {
            get;
        }
        public int ButtonState
        {
            get;
        }
        public int EventFlags
        {
            get;
        }
        public bool LeftAltPressed
        {
            get;
        }
        public bool LeftCtrlPressed
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
        public bool RightAltPressed
        {
            get;
        }
        public bool RightCtrlPressed
        {
            get;
        }
        public bool EnhancedKey
        {
            get;
        }
        public bool NumLockActivatet
        {
            get;
        }
        public bool ScrolLockActivatet
        {
            get;
        }
        public bool Button1Pressed
        {
            get;
        }
        public bool Button2Pressed
        {
            get;
        }
        public bool Button3Pressed
        {
            get;
        }
        public bool Button4Pressed
        {
            get;
        }
        public bool RightMostButtonPressed
        {
            get;
        }
        public bool DoubleClicked
        {
            get;
        }
        public bool HorisontalMouseWheelMoved
        {
            get;
        }
        public bool MouseMoved
        {
            get;
        }
        public bool VerticalMouseWheelMoved
        {
            get;
        }
        public bool MouseWheelMoveDirection
        {
            get;
        }
    }
}