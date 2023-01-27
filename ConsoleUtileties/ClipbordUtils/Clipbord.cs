using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUtilitiesLibary.ClipbordUtils
{
    public sealed partial class Clipbord
    {

        private const int CF_UNICODETEXT = 13;
        private const int CF_HDROP = 15;

        private const int WINDOWS_MAX_PATH_LENGTH = 260;

        private const uint HDROP_FILE_GET_FILE_COUNT = 0xFFFFFFFF;

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

        [LibraryImport("user32.dll", SetLastError = true)]
        private static partial uint EnumClipboardFormats(uint uFormat);

        //[LibraryImport("shell32.dll", EntryPoint = "DragQueryFileA")]
        //private static partial uint DragQueryFile(IntPtr hDrop, uint iFile, IntPtr lpszFile,  uint cch);

        [LibraryImport("shell32.dll", EntryPoint = "DragQueryFileA")]
        private static partial uint DragQueryFile(IntPtr hDrop, uint iFile, byte[] lpszFile,  uint cch);

        [LibraryImport("user32.dll", EntryPoint = "GetWindowTextA")]
        private static partial int GetWindowText(IntPtr hWnd, byte[] lpString, int maxCount);

        [LibraryImport("user32.dll", EntryPoint = "GetWindowTextLengthA")]
        private static partial int GetWindowTextLength(IntPtr hWnd);

        [LibraryImport("user32.dll")]
        private static partial IntPtr GetClipboardOwner();

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
            CloseClipboard();
        }

        //Maybe dangerous?
        public static bool TryGetClipbordString (out string? data)
        {
            if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
            {
                data = null;
                return false;
            }

            OpenClipboard(IntPtr.Zero);
            IntPtr ptr = GetClipboardData(CF_UNICODETEXT);


            data = Marshal.PtrToStringAuto(ptr);
            CloseClipboard();
            return true;
        }

        public static bool TryGetClipbordFiles(out string[]? filePaths)
        {
            if (!IsClipboardFormatAvailable(CF_HDROP))
            {
                filePaths = null;
                return false;
            }

            OpenClipboard(IntPtr.Zero);

            IntPtr ptr = GetClipboardData(CF_HDROP);

            uint fileCount = DragQueryFile(ptr, HDROP_FILE_GET_FILE_COUNT, null, 0);

            string[] res = new string[fileCount];

            for (uint i = 0; i < fileCount; i++)
            {

                uint bufferSize = DragQueryFile(ptr, i, null, 0);

                byte[] buffer = new byte[bufferSize + 1];

                DragQueryFile(ptr, i, buffer, (uint)buffer.Length);

                res[i] = Encoding.Default.GetString(buffer);
            }

            CloseClipboard();

            filePaths = res;
            return true;
        }

        public static List<ClipbordFormats> AvidableClipbordFormats()
        {
            List<ClipbordFormats> formats = new();

            OpenClipboard(IntPtr.Zero);

            uint format = 0;
            do
            {
                format = EnumClipboardFormats(format);
                formats.Add(Enum.IsDefined(typeof(ClipbordFormats), format) ? (ClipbordFormats)format : ClipbordFormats.Unknown);
            } while (format != 0);

            CloseClipboard();

            return formats;
        }

        public static ClipbordFormats GetCurrentClipbordFormat()
        {
            OpenClipboard(IntPtr.Zero);
            uint format = 0;
            do
            {
                format = EnumClipboardFormats(format);
                if (Enum.IsDefined(typeof(ClipbordFormats), format))
                    return (ClipbordFormats)format;
            } while (format != 0);

            CloseClipboard();

            return ClipbordFormats.Unknown;
        }

        /// <summary>
        /// gets the title of the window that owns the clipbord
        /// </summary>
        /// <returns>string with the title of the clipbord owner. <see cref="string.Empty"/> = no current owner</returns>
        public static string GetClipbordOnwerName()
        {
            IntPtr winHandle = GetClipboardOwner();
            int bufferLength = GetWindowTextLength(winHandle);
            byte[] buffer = new byte[bufferLength + 1];
            GetWindowText(winHandle, buffer, buffer.Length);
            return Encoding.Default.GetString(buffer);
        }

    }
}
