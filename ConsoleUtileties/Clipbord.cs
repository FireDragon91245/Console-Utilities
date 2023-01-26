using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtileties
{
    public sealed partial class Clipbord
    {

        private const int CF_UNICODETEXT = 13;

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool OpenClipboard (IntPtr hWndNewOwner);

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool CloseClipboard ();

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool SetClipboardData (uint uFormat, IntPtr data);

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool EmptyClipboard ();

        [LibraryImport("user32.dll", SetLastError = true)]
        private static partial IntPtr GetClipboardData (uint uFormat);

        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool IsClipboardFormatAvailable (uint uFormat);

        public static void SetClipbord (int value, int numBase) => SetClipboard(Convert.ToString(value, numBase));

        public static void SetClipboard (int value, IFormatProvider format = null) => SetClipboard(value.ToString(format ?? CultureInfo.CurrentCulture));

        public static void SetClipboard (double value, IFormatProvider format = null) => SetClipboard(value.ToString(format ?? CultureInfo.CurrentCulture));

        public static void SetClipboard (int value, string format = null) => SetClipboard(value.ToString(format ?? string.Empty));

        public static void SetClipboard (double value, string format = null) => SetClipboard(value.ToString(format ?? string.Empty));

        public static void SetClipboard (int value, IFormatProvider format = null, string formatString = null) => SetClipboard(value.ToString(formatString ?? string.Empty ,format ?? CultureInfo.CurrentCulture));

        public static void SetClipboard (double value, IFormatProvider format = null, string formatString = null) => SetClipboard(value.ToString(formatString ?? string.Empty ,format ?? CultureInfo.CurrentCulture));

        public static void SetClipboard (string value, params object[] args) => SetClipboard(string.Format(value, args));

        public static void SetClipboard (string value)
        {
            OpenClipboard(IntPtr.Zero);
            IntPtr data = Marshal.StringToCoTaskMemUni(value);
            SetClipboardData(CF_UNICODETEXT, data);
            CloseClipboard();
            Marshal.FreeHGlobal(data);
        }

        public static void ResetClipbord ()
        {
            OpenClipboard(IntPtr.Zero);
            EmptyClipboard();
        }

        //Maybe dangerous?
        public static bool TryGetClipbord (out string? data)
        {
            if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
            {
                data = null;
                return false;
            }

            OpenClipboard(IntPtr.Zero);

            IntPtr ptr = GetClipboardData(CF_UNICODETEXT);
            data = Marshal.PtrToStringAuto(ptr);

            return true;
        }

    }
}
