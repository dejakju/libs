using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace libs
{
    public class DOSException : System.Exception
    {
        public DOSException()
        {
        }

        public DOSException(string message) : base(message)
        {
        }

        public DOSException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DOSException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    #region DOS Enumerations

    public enum DOSCode
    {
        ERROR_NO_FREE_STORE,
        ERROR_TASK_TABLE_FULL,
        ERROR_BAD_TEMPLATE,
        ERROR_BAD_NUMBER,
        ERROR_REQUIRED_ARG_MISSING,
        ERROR_KEY_NEEDS_ARG,
        ERROR_TOO_MANY_ARGS,
        ERROR_UNMATCHED_QUOTES,
        ERROR_LINE_TOO_LONG,
        ERROR_FILE_NOT_OBJECT,
        ERROR_INVALID_RESIDENT_LIBRARY,
        ERROR_NO_DEFAULT_DIR,
        ERROR_OBJECT_IN_USE,
        ERROR_OBJECT_EXISTS,
        ERROR_DIR_NOT_FOUND,
        ERROR_OBJECT_NOT_FOUND,
        ERROR_BAD_STREAM_NAME,
        ERROR_OBJECT_TOO_LARGE,
        ERROR_ACTION_NOT_KNOWN,
        ERROR_INVALID_COMPONENT_NAME,
        ERROR_INVALID_LOCK,
        ERROR_OBJECT_WRONG_TYPE,
        ERROR_DISK_NOT_VALIDATED,
        ERROR_DISK_WRITE_PROTECTED,
        ERROR_RENAME_ACROSS_DEVICES,
        ERROR_DIRECTORY_NOT_EMPTY,
        ERROR_TOO_MANY_LEVELS,
        ERROR_DEVICE_NOT_MOUNTED,
        ERROR_SEEK_ERROR,
        ERROR_COMMENT_TOO_BIG,
        ERROR_DISK_FULL,
        ERROR_DELETE_PROTECTED,
        ERROR_WRITE_PROTECTED,
        ERROR_READ_PROTECTED,
        ERROR_NOT_A_DOS_DISK,
        ERROR_NO_DISK,
        ERROR_NO_MORE_ENTRIES,
        ERROR_IS_SOFT_LINK,
        ERROR_OBJECT_LINKED,
        ERROR_BAD_HUNK,
        ERROR_NOT_IMPLEMENTED,
        ERROR_RECORD_NOT_LOCKED,
        ERROR_LOCK_COLLISION,
        ERROR_LOCK_TIMEOUT,
        ERROR_UNLOCK_ERROR,

        RETURN_OK,
        RETURN_WARN,
        RETURN_ERROR,
        RETURN_FAIL,

        SIGBREAKB_CTRL_C,
        SIGBREAKB_CTRL_D,
        SIGBREAKB_CTRL_E,
        SIGBREAKB_CTRL_F
    }

    #endregion

    public static class DOS
    {
        #region File IO

        public static DirectoryInfo CreateDir(string name)
        {
            return Directory.CreateDirectory(name);
        }

        #endregion

        #region Environment Methods

        public static string GetEnv(string variable)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                string var = Environment.GetEnvironmentVariable(variable);
                if (var != null)
                    return Environment.GetEnvironmentVariable(variable);
                else
                    return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Menu Variables

        private static int mMenuSelectedIndex;
        private static string[] mMenuOptions;
        private static string mMenuPrompt;
        private static string mMenuTitle;
        public static string mMenuPrefix { get; set; }
        public static string mMenuSuffix { get; set; }

        #endregion

        #region Menu Methods

        public static void CreateMenu(string prompt, string[] options, string title = "")
        {
            mMenuSelectedIndex = 0;
            mMenuPrompt = prompt;
            mMenuOptions = options;
            mMenuTitle = title;
        }

        private static void DisplayMenuOptions()
        {
            int maxLength = mMenuOptions.Max(o => o.Length) % 2 == 0 ? mMenuOptions.Max(o => o.Length) + 2 : mMenuOptions.Max(o => o.Length) + 1;

            Console.Title = mMenuTitle;

            DOS.SetForegroundColor(ConsoleColor.Green);
            DOS.WriteLine(mMenuPrompt);
            DOS.ResetColor();

            DOS.SetCursorInvisible();
            DOS.SetForegroundColor(ConsoleColor.Cyan);
            DOS.WriteLine($"{DOS.GetEnv("username")}@{DOS.GetEnv("computername")} running on {DOS.GetEnv("processor_identifier")} (OS: {DOS.GetEnv("os")})\n");
            DOS.ResetColor();

            for (int i = 0; i < mMenuOptions.Length; i++)
            {
                string currentOption = mMenuOptions[i];
                string prefix = mMenuPrefix;
                string suffix = mMenuSuffix;

                if (i == mMenuSelectedIndex)
                {
                    DOS.SetForegroundColor(ConsoleColor.Black);
                    DOS.SetBackgroundColor(ConsoleColor.Cyan);
                    DOS.WriteLine($"{prefix}{currentOption.PadLeft(maxLength, ' ')}{suffix}");
                }
                else
                {
                    DOS.SetForegroundColor(ConsoleColor.White);
                    DOS.SetBackgroundColor(ConsoleColor.Black);
                    DOS.WriteLine($"{currentOption.PadLeft(maxLength, ' ')}");
                }
            }
            DOS.ResetColor();
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPress ANY KEY to continue...\n");
            Console.ReadKey(true);
        }

        public static bool WaitForKey(ConsoleKey key)
        {
            ConsoleKey keyPressed;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == key)
                    return true;


            } while (keyPressed != key);

            return false;
        }

        public static int SelectMenu(int selectedIndex = 0)
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayMenuOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                CheckShortcuts(keyPressed);

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    mMenuSelectedIndex--;
                    if (mMenuSelectedIndex == -1)
                    {
                        mMenuSelectedIndex = mMenuOptions.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    mMenuSelectedIndex++;
                    if (mMenuSelectedIndex == mMenuOptions.Length)
                    {
                        mMenuSelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return mMenuSelectedIndex;
        }

        public static int CheckShortcuts(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.Q)
            {
                mMenuSelectedIndex = mMenuOptions.Length - 1;
                return mMenuSelectedIndex;
            }
            return 0;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Cls()
        {
            Console.Clear();
        }

        public static (int, int) GetCursorPos()
        {
            (int left, int top) mCursorPosition = Console.GetCursorPosition();

            return mCursorPosition;
        }

        public static int GetBufferHeight()
        {
            return Console.BufferHeight;
        }

        public static int GetBufferWidth()
        {
            return Console.BufferWidth;
        }

        public static int GetWindowHeight()
        {
            return Console.WindowHeight;
        }

        public static int GetWindowWidth()
        {
            return Console.WindowWidth;
        }

        public static int GetWindowMaxHeight()
        {
            return Console.LargestWindowHeight;
        }

        public static int GetWindowMaxWidth()
        {
            return Console.LargestWindowWidth;
        }

        public static void NewLine()
        {
            Console.Write(Environment.NewLine);
        }

        public static void SetCursorInvisible()
        {
            Console.CursorVisible = false;
        }

        public static void SetCursorPos(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public static void SetCursorVisible()
        {
            Console.CursorVisible = true;
        }

        public static void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public static void ResetColor()
        {
            Console.ResetColor();
        }

        public static void Write(string s)
        {
            Console.Write(s);
        }

        public static void Write(string value, object param)
        {
            Console.Write(value, param);
        }

        public static void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        #endregion

    }
}