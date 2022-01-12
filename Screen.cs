using System;

namespace libs
{

    public class Screen
    {
        private string mTitle;
        public string Title { get => mTitle; set => mTitle = value; }

        private int mCols;
        public int Cols { get => mCols; set => mCols = value; }

        private int mRows;
        public int Rows { get => mRows; set => mRows = value; }

        private int mWidth;
        public int Width { get => mWidth; set => mWidth = value; }

        private int mHeight;
        public int Height { get => mHeight; set => mHeight = value; }

        private int mCurrentCol;
        public int CurrentCol { get => mCurrentCol; set => mCurrentCol = value; }

        private int mCurrentRow;
        public int CurrentRow { get => mCurrentRow; set => mCurrentRow = value; }

        private int mSelectedIndex;
        public int SelectedIndex { get => mSelectedIndex; set => mSelectedIndex = value; }
 
        private int  mOptionsCount;
        public int OptionsCount { get => mOptionsCount; set => mOptionsCount = value; }


        public Screen(string title = "")
        {
            Title = title;
            Cols = Console.BufferWidth;
            Rows = Console.BufferHeight;
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
            CurrentCol = Console.GetCursorPosition().Left;
            CurrentRow = Console.GetCursorPosition().Top;
        }

        public void Run()
        {
            Console.Clear();

            // Draw a basic frame (later more dynamic)
            OnFramePaint();

            // Update status bar (footer)
            OnFrameUpdate();

        }

        private void OnFramePaint()
        {
            // HEAD
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" M\\TEXT V4.6 {DOS.GetEnv("COMPUTERNAME")}".PadRight(Width, ' '));
            Console.ResetColor();
            Console.SetCursorPosition(0, 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"_".PadRight(Width, '_'));

            // BODY
            Console.SetCursorPosition(0, 3);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("my content");
            Console.ResetColor();


            // FOOT
            Console.SetCursorPosition(0, Height - 2);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"COL={CurrentCol} ROW={CurrentRow}\t\tCOLS={Cols} ROWS={Rows}".PadRight(Width, ' '));
            Console.ResetColor();

            // Load content (disk operations)
            OnLoadContent();

            // On selected cell index change
            OnCellChange();

            // SET DEFAULT STARTUP CURSOR POSITION
            OnCursorStartupLocation();
        }

        private void OnLoadContent()
        {
            // START OF BODY
            Console.SetCursorPosition(3, 5);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- Frame");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("- Task");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("- Mask");
            Console.ResetColor();
        }

        private void OnFrameUpdate()
        {
            // UPDATE FOOT
            Console.SetCursorPosition(0, Height - 2);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"COL={CurrentCol} ROW={CurrentRow}\t\tCOLS={Cols} ROWS={Rows}".PadRight(Width - 5, ' '));
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