using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

    public enum DOSCode
    {
        /*
        #define ERROR_NO_FREE_STORE		  103
        #define ERROR_TASK_TABLE_FULL		  105
        #define ERROR_BAD_TEMPLATE		  114
        #define ERROR_BAD_NUMBER		  115
        #define ERROR_REQUIRED_ARG_MISSING	  116
        #define ERROR_KEY_NEEDS_ARG		  117
        #define ERROR_TOO_MANY_ARGS		  118
        #define ERROR_UNMATCHED_QUOTES		  119
        #define ERROR_LINE_TOO_LONG		  120
        #define ERROR_FILE_NOT_OBJECT		  121
        #define ERROR_INVALID_RESIDENT_LIBRARY	  122
        #define ERROR_NO_DEFAULT_DIR		  201
        #define ERROR_OBJECT_IN_USE		  202
        #define ERROR_OBJECT_EXISTS		  203
        #define ERROR_DIR_NOT_FOUND		  204
        #define ERROR_OBJECT_NOT_FOUND		  205
        #define ERROR_BAD_STREAM_NAME		  206
        #define ERROR_OBJECT_TOO_LARGE		  207
        #define ERROR_ACTION_NOT_KNOWN		  209
        #define ERROR_INVALID_COMPONENT_NAME	  210
        #define ERROR_INVALID_LOCK		  211
        #define ERROR_OBJECT_WRONG_TYPE		  212
        #define ERROR_DISK_NOT_VALIDATED	  213
        #define ERROR_DISK_WRITE_PROTECTED	  214
        #define ERROR_RENAME_ACROSS_DEVICES	  215
        #define ERROR_DIRECTORY_NOT_EMPTY	  216
        #define ERROR_TOO_MANY_LEVELS		  217
        #define ERROR_DEVICE_NOT_MOUNTED	  218
        #define ERROR_SEEK_ERROR		  219
        #define ERROR_COMMENT_TOO_BIG		  220
        #define ERROR_DISK_FULL			  221
        #define ERROR_DELETE_PROTECTED		  222
        #define ERROR_WRITE_PROTECTED		  223
        #define ERROR_READ_PROTECTED		  224
        #define ERROR_NOT_A_DOS_DISK		  225
        #define ERROR_NO_DISK			  226
        #define ERROR_NO_MORE_ENTRIES		  232
        #define ERROR_IS_SOFT_LINK		  233
        #define ERROR_OBJECT_LINKED		  234
        #define ERROR_BAD_HUNK			  235
        #define ERROR_NOT_IMPLEMENTED		  236
        #define ERROR_RECORD_NOT_LOCKED		  240
        #define ERROR_LOCK_COLLISION		  241
        #define ERROR_LOCK_TIMEOUT		  242
        #define ERROR_UNLOCK_ERROR		  243

        #define RETURN_OK			 0
        #define RETURN_WARN			 5
        #define RETURN_ERROR		10
        #define RETURN_FAIL			20

        #define SIGBREAKB_CTRL_C   12
        #define SIGBREAKB_CTRL_D   13
        #define SIGBREAKB_CTRL_E   14
        #define SIGBREAKB_CTRL_F   15
        */

    }

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
        private static string mMenuLogo;

        #endregion

        #region Menu Methods

        public static void CreateMenu(string prompt, string[] options, string logo = "")
        {
            mMenuPrompt = prompt;
            mMenuOptions = options;
            mMenuSelectedIndex = 0;
            mMenuLogo = logo;
        }

        private static void DisplaymMenuOptions()
        {
            Console.Title = mMenuPrompt;
            Console.WriteLine(mMenuLogo);
            for (int i = 0; i < mMenuOptions.Length; i++)
            {
                string currentOption = mMenuOptions[i];
                string prefix;
                string suffix;

                if (i == mMenuSelectedIndex)
                {
                    prefix = "[";
                    suffix = "]";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    suffix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.ResetColor();
                Console.WriteLine($"{prefix, 3}{currentOption, -15}{suffix,  3}");
            }
            Console.ResetColor();
        }

        public static int RunMenu()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplaymMenuOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

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

        #endregion

    }
}