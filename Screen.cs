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

        private int mX;
        public int X { get => mX; set => mX = value; }

        private int mY;
        public int Y { get => mY; set => mY = value; }

        private int mXOffset;
        public int XOffset { get => mXOffset; set => mXOffset = value; }

        private int mYOffset;
        public int YOffset { get => mYOffset; set => mXOffset = value ; }

        private int mCols;
        public int Cols { get => mCols; set => mCols = value; }

        private int mRows;
        public int Rows { get => mRows; set => mRows = value; }

        private int mScreenBufferWidth;
        public int ScreenBufferWidth { get => mScreenBufferWidth; set => mScreenBufferWidth = value; }

        private int mScreenBufferHeight;
        public int ScreenBufferHeight { get => mScreenBufferHeight; set => mScreenBufferHeight = value; }

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

        private string mBereich;
        public string Bereich { get => mBereich; set => mBereich = value; }

        private string mGruppe;
        public string Gruppe { get => mGruppe; set => mGruppe = value; }

        private string mDocument;
        public string Document { get => mDocument; set => mDocument = value; }

        private string mDescription;
        public string Description { get => mDescription; set => mDescription = value; }


        public int CanvasLeftPos { get; set; }
        public int CanvasTopPos { get; set; }
        public int CanvasRightPos { get; set; }
        public int CanvasBottomPos { get; set; }
        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }



        public Screen(string title = "")
        {
            Active = true;

            ScreenTitle = title;

            ScreenWidth = Console.WindowWidth;
            ScreenHeight = Console.WindowHeight;

            ScreenBufferWidth = Console.BufferWidth;
            ScreenBufferHeight = Console.BufferHeight;

            CurrentCol = Console.GetCursorPosition().Left;
            CurrentRow = Console.GetCursorPosition().Top;

            Bereich = "XCOM";
            Gruppe = "LIBS";
            Document = "Curval.NET";
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


        private void WriteAt((int left, int top) position, char character)
        {
            Console.SetCursorPosition(position.left, position.top);
            Console.Write(character);
            CurrentCol++;
        }

        private void WriteAt(int left, int top, char character)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(character);
            CurrentCol++;
        }

        private void OnFrameUpdate()
        {
            DrawFooter();

            // SET DEFAULT STARTUP CURSOR POSITION
            OnCursorStartupLocation(1, 1);

            OnCommand();

            // Save Cursor Position
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;

            // Update Cursor Position
            Console.SetCursorPosition(80, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($"X: {left} Y: {top}");
    
            // Reset Cursor position
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(left, top);
        }

        private void OnCommand()
        {
            OnCommandText();

            switch (Command)
            {
                case ScreenCommand.QUIT:
                    ExitApp();
                    break;

                case ScreenCommand.HEADER:
                    OnShowHeader();
                    break;

                case ScreenCommand.LIST:
                    Console.SetCursorPosition(0, 4);
                    Console.ResetColor();

                    char character = 'H';
                    WriteAt(Console.GetCursorPosition(), character);
                    Console.WriteLine();

                    Console.Write($"Listing contents... {CurrentCol}:{CurrentRow}...");
                    Console.ReadKey(true);
                    break;

                case ScreenCommand.LDIR:
                    Console.SetCursorPosition(ScreenWidth-10,ScreenHeight-1);
                    Console.Write($"{CurrentCol}:{CurrentRow}");
                    Console.SetCursorPosition(1, 1);
                    break;

            }
        }

        private void OnCommandText()
        {
            string command = Console.ReadLine();

            // Clear the command text immediately
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("".PadRight(ScreenWidth, ' '));
            Console.ResetColor();

            // If there's no valid command, skip
            if (string.IsNullOrEmpty(command))
            {
                Command = ScreenCommand.NOOP;
                return;
            }

            // Trim spaces and convert to uppercase letters
            CommandText = command.Trim().ToUpper();
            
            switch (CommandText)
            {
                case "H":
                    Command = ScreenCommand.HEADER;
                    break;

                case "L":
                    Command = ScreenCommand.LIST;
                    break;

                case "L DIR":
                    Command = ScreenCommand.LDIR;
                    break;

                case "Q":
                    Command = ScreenCommand.QUIT;
                    break;

                default:
                    Command = ScreenCommand.NOOP;
                    break;
            }
        }

        private void DrawHeader()
        {
            // HEAD _____________________________________________________________________________________________________________________________________
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" M\\TEXT V4.6 {DOS.GetEnv("COMPUTERNAME")} WIDTH={ScreenWidth} HEIGHT={ScreenHeight}".PadRight(ScreenWidth, ' '));
            Console.ResetColor();

            // SEPARATOR LINE (3) )______________________________________________________________________________________________________________________
            Console.SetCursorPosition(0, 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"_".PadRight(ScreenWidth, '_'));
            Console.ResetColor();
        }

        private void DrawBasicHeaderAndFooter()
        {
            DrawHeader();

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
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"DOCUMENT={Document} | WIDTH={ScreenWidth} HEIGHT={ScreenHeight} | BUFFER WIDTH/COLS={ScreenBufferWidth} BUFFER HEIGHT/ROWS={ScreenBufferHeight}".PadRight(ScreenWidth, ' '));
            Console.ResetColor();
        }

        private void OnShowHeader()
        {
            Console.SetCursorPosition(15, 5);
            //
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("+------------------------+");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine("| HEADER OF DOCUMENT9999 |");
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("|                        |");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("|                        |");
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("|                        |");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("|                        |");
            Console.SetCursorPosition(15, 11);
            Console.WriteLine("|                        |");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("+------------------------+");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("| HEADER OF DOCUMENT9999 |");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("+------------------------+");
            //
            Console.ReadKey(true);
            Console.SetCursorPosition(1, 2);
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
                case ConsoleKey.UpArrow:
                    CurrentRow--;
                    break;
                case ConsoleKey.DownArrow:
                    CurrentRow++;
                    break;
                case ConsoleKey.LeftArrow:
                    CurrentCol--;
                    break;
                case ConsoleKey.RightArrow:
                    CurrentCol++;
                    break;
                case >= ConsoleKey.A and <= ConsoleKey.Z:  
                    sb.Append(consoleKey);
                    break;
            }

            Console.SetCursorPosition(CurrentCol, CurrentRow);
            CommandText = sb.ToString();
        }

        private void ExitApp()
        {
            Active = false;
            Console.Clear();
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
                Console.Write($" . ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("DOCUMENT{i}".PadRight(14, ' '));
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("This is the .DSC description");
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

        internal void SetScreenSize(int screenWidth, int screenHeight)
        {
            Console.SetWindowSize(screenWidth, screenHeight);
        }

        internal string GetCharacterAt(int columns, int rows)
        {
            for (int y = 0; y < columns; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    Console.SetCursorPosition(x, y);
                    // ToDo
                }
            }
            return string.Empty;
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
        LDIR,
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
        ROW,
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