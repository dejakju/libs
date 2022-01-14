using System;
using System.Text;

namespace libs
{

    public class Screen
    {
        private bool mActive;
        public bool Active { get => mActive; set => mActive = value; }

        private string mCommandText;
        public string CommandText { get => mCommandText; set => mCommandText = value; }

        private ScreenCommand mCommand;
        public ScreenCommand Command { get => mCommand; set => mCommand = value; }

        private string mScreenTitle;
        public string ScreenTitle { get => mScreenTitle; set => mScreenTitle = value; }

        private int mCols;
        public int Cols { get => mCols; set => mCols = value; }

        private int mRows;
        public int Rows { get => mRows; set => mRows = value; }

        private int mScreenWidth;
        public int ScreenWidth { get => mScreenWidth; set => mScreenWidth = value; }

        private int mScreenHeight;
        public int ScreenHeight { get => mScreenHeight; set => mScreenHeight = value; }

        private int mCurrentCol;
        public int CurrentCol { get => mCurrentCol; set => mCurrentCol = value; }

        private int mCurrentRow;
        public int CurrentRow { get => mCurrentRow; set => mCurrentRow = value; }

        private int mSelectedIndex;
        public int SelectedIndex { get => mSelectedIndex; set => mSelectedIndex = value; }
 
        private int  mOptionsCount;
        public int OptionsCount { get => mOptionsCount; set => mOptionsCount = value; }

        private int mOptionsMaxWidth;
        public int OptionsMaxWidth { get => mOptionsMaxWidth; set => mOptionsMaxWidth = value; }




        public Screen(string title = "")
        {
            Active = true;

            ScreenTitle = title;

            ScreenWidth = Console.WindowWidth;
            ScreenHeight = Console.WindowHeight;

            Cols = Console.BufferWidth;
            Rows = Console.BufferHeight;
            CurrentCol = Console.GetCursorPosition().Left;
            CurrentRow = Console.GetCursorPosition().Top;
        }

        public void Run()
        {
            Console.Clear();

            while (Active)
            {
                // Draw a basic frame (later more dynamic)
                OnFramePaint();

                // Update status bar (footer)
                OnFrameUpdate();
            }

        }

        private void OnFramePaint()
        {
            // Draw basic header and footer frame
            DrawBasicHeaderAndFooter();

            // Draw the dynamic part of the app... the raw meat of the app (data!)
            OnLoadDynamicContent();
        }

        private void DrawBasicHeaderAndFooter()
        {
            // HEAD
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" M\\TEXT V4.6 {DOS.GetEnv("COMPUTERNAME")} WIDTH={ScreenWidth} HEIGHT={ScreenHeight}".PadRight(ScreenWidth, ' '));
            Console.ResetColor();
            Console.SetCursorPosition(0, 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"_".PadRight(ScreenWidth, '_'));
            Console.ResetColor();

            // BODY
            Console.SetCursorPosition(0, 3);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" . DOCUMENT9999  This is the .DSC description");
            Console.WriteLine(" . DOCUMENT999   This is the .DSC description");
            Console.WriteLine(" . DOCUMENT99    This is the .DSC description");
            Console.WriteLine(" . DOCUMENT0     This is the .DSC description");
            Console.WriteLine(" . DOCUMENT      This is the .DSC description");
            Console.ResetColor();

            DrawFooter();
        }

        private void DrawFooter()
        {
            // UPDATE FOOT
            Console.SetCursorPosition(0, ScreenHeight - 2);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"COL={CurrentCol} ROW={CurrentRow} -- COLS={Cols} ROWS={Rows}".PadRight(ScreenWidth, ' '));
            Console.ResetColor();
        }

        private void OnFrameUpdate()
        {
            DrawFooter();

            // SET DEFAULT STARTUP CURSOR POSITION
            OnCursorStartupLocation(0, 1);

            OnCommand();
        }

        private void OnCommand()
        {
            OnCommandText();

            switch (Command)
            {
                case ScreenCommand.QUIT:
                    ExitApp();
                    break;

                case ScreenCommand.LIST:
                    Console.SetCursorPosition(0, 4);
                    Console.ResetColor();
                    Console.Write($"Listing contents... {mCurrentCol}:{CurrentRow}...");
                    break;
            }
        }

        private void OnCommandText()
        {
            OnKeyDown();

            string command = Console.ReadLine();

            // Clear the command text immediately
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("".PadRight(ScreenWidth, ' '));
            Console.ResetColor();

            // If there's no valid command, skip
            if (string.IsNullOrEmpty(command))
                return;

            // Trim spaces and convert to uppercase letters
            CommandText = command.Trim().ToUpper();

            switch (CommandText)
            {
                case "L":
                    Command = ScreenCommand.LIST;
                    break;

                case "L DIR":
                    Console.SetCursorPosition(80, 25);
                    Console.Write($"{mCurrentCol}:{CurrentRow}");
                    Console.SetCursorPosition(0, 1);
                    break;

                case "Q":
                    Command = ScreenCommand.QUIT;
                    break;
            }
        }

        private void OnKeyDown()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleKey consoleKey;
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

            consoleKey = consoleKeyInfo.Key;

            switch (consoleKey)
            {
                case ConsoleKey.Backspace:
                    RedrawFrame();
                    break;
                case ConsoleKey.Enter:
                    RedrawFrame();
                    break;
                case ConsoleKey.UpArrow:
                    RedrawFrame();
                    break;
                case ConsoleKey.DownArrow:
                    RedrawFrame();
                    break;
                case ConsoleKey.LeftArrow:
                    RedrawFrame();
                    break;
                case ConsoleKey.RightArrow:
                    RedrawFrame();
                    break;
                default:
                    sb.Append(consoleKey);
                    break;
            }
        }

        private void ExitApp()
        {
            Active = false;
            Environment.Exit(0);
        }

        private void RedrawFrame()
        {
            Console.Clear();
            DrawBasicHeaderAndFooter();
            OnLoadDynamicContent();
        }

        private void OnLoadDynamicContent()
        {
            // START OF BODY
            Console.SetCursorPosition(0, 10);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 10; i++)
            {
                Console.Write($" .");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("DOCUMENT{i}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(" This is the .DSC description");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ResetColor();
        }


        private void OnCellChange()
        {
            ConsoleKey keyPressed;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = OptionsCount - 1;
                    }
                    CurrentRow--;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == OptionsCount)
                    {
                        SelectedIndex = 0;
                    }
                    CurrentRow++;
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = OptionsCount - 1;
                    }
                    CurrentCol--;
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == OptionsCount)
                    {
                        SelectedIndex = 0;
                    }
                    CurrentCol++;
                }

            } while (keyPressed != ConsoleKey.Enter && Console.KeyAvailable);
        }

        private void OnCursorStartupLocation(int left = 0, int top = 2)
        {
            Console.SetCursorPosition(left, top);
        }

    }   // CLASS


   public enum ScreenCommand
    {
        NOOP,
        LIST,
        EDIT,
        DELETE,
        HEADER,
        ZORDER,
        CONFIRM,
        YES,
        NO,
        OK,
        CANCEL,
        MESSAGE,
        PLUS,
        MINUS,
        COLUMN,
        QUIT,
        FIND,
        DIRECTORY,
        PRINT
    }

    public enum ScreenMode
    {
        CUSTOM = 0,
        LIST = 1,
        VIEW = 2,
        EDIT = 4,
        DELETE = 8,
        MASK = 16,
        PREFS = 32,
        USER = 64,
        SYSOP = 128
    }

}