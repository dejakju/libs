using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace libs
{
    public class DOSException : System.Exception
    {
        public DOSException() { }
        public DOSException(string message) : base(message) { }
        // public DOSException(string message, System.Exception inner) : base(message, inner) { }
        // protected DOSException(
        //     System.Runtime.Serialization.SerializationInfo info,
        //     System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public static class DOS
    {
        #region File IO
        public static DirectoryInfo CreateDir(string name)
        {
            try
            {
                return Directory.CreateDirectory(name);
            }
            catch (IOException e)
            {
                throw new DOSException($"{e.ToString()}");
            }
            // catch (System.UnauthorizedAccessException e)
            // {
            //     Console.WriteLine($"You don't have the required permission.");
            // }
            // catch (System.ArgumentException e)
            // {
            //     Console.WriteLine($"The specified path '{name}' contains only white space, one or more invalid characters, or none at all.");
            // }
            // catch (System.ArgumentNullException e)
            // {
            //     Console.WriteLine($"The specified path '{name}' is null.");
            // }
            // catch (System.PathTooLongException e)
            // {
            //     Console.WriteLine($"The specified path, file name, or both exceed the system-defined maximum length.");
            // }
            // catch (System.DirectoryNotFoundException e)
            // {
            //     Console.WriteLine($"The specified path is invalid (e.g., it is on an unmapped drive).");
            // }
            // catch (System.NotSupportedException e)
            // {
            //     Console.WriteLine($"The specified path '{name}' contains a colon character (:) that is not part of a drive label (\"C:\")");
            // }
        }


        public static IEnumerable<T> GetActiveDrives<T>(this IEnumerable<T> items, Func<T, bool> f)
        {
            string[] drives = Environment.GetLogicalDrives();
            foreach (var drive in drives)
            {
                System.Console.WriteLine($"{drive}");
                foreach (var item in items)
                {
                    if (f(item))
                    {
                        yield return item;
                    }
                }
            }
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