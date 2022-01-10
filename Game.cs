using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace libs
{
    /// TODO: Export to subfolders?!
    /// and make much more dynamic...
    public class Game
    {
        public void Start()
        {
            Title = "The Title";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = "What would you like to do?";
            string[] options = { "Play", "About", "Exit" };
            string logo = @"

  █████▒█    ██  ███▄    █  ▄████▄  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ 
▓██   ▒ ██  ▓██▒ ██ ▀█   █ ▒██▀ ▀█  ▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ 
▒████ ░▓██  ▒██░▓██  ▀█ ██▒▒▓█    ▄ ▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   
░▓█▒  ░▓▓█  ░██░▓██▒  ▐▌██▒▒▓▓▄ ▄██▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒
░▒█░   ▒▒█████▓ ▒██░   ▓██░▒ ▓███▀ ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒
 ▒ ░   ░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒ ░ ░▒ ▒  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░
 ░     ░░▒░ ░ ░ ░ ░░   ░ ▒░  ░  ▒       ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░
 ░ ░    ░░░ ░ ░    ░   ░ ░ ░          ░       ▒ ░░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  
          ░              ░ ░ ░                ░      ░ ░           ░       ░  
                           ░                                                  
";
            DOS.CreateMenu(prompt, options, logo);
            int selectedIndex = DOS.SelectMenu();

            switch (selectedIndex)
            {
                case 0:
                    PlayGame();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }


        private void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            string about = @"

 ██▓     ██▓ ▄▄▄▄    ██▀███   ▄▄▄       ██▀███   ██▓▓█████   ██████ 
▓██▒    ▓██▒▓█████▄ ▓██ ▒ ██▒▒████▄    ▓██ ▒ ██▒▓██▒▓█   ▀ ▒██    ▒ 
▒██░    ▒██▒▒██▒ ▄██▓██ ░▄█ ▒▒██  ▀█▄  ▓██ ░▄█ ▒▒██▒▒███   ░ ▓██▄   
▒██░    ░██░▒██░█▀  ▒██▀▀█▄  ░██▄▄▄▄██ ▒██▀▀█▄  ░██░▒▓█  ▄   ▒   ██▒
░██████▒░██░░▓█  ▀█▓░██▓ ▒██▒ ▓█   ▓██▒░██▓ ▒██▒░██░░▒████▒▒██████▒▒
░ ▒░▓  ░░▓  ░▒▓███▀▒░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▒▓ ░▒▓░░▓  ░░ ▒░ ░▒ ▒▓▒ ▒ ░
░ ░ ▒  ░ ▒ ░▒░▒   ░   ░▒ ░ ▒░  ▒   ▒▒ ░  ░▒ ░ ▒░ ▒ ░ ░ ░  ░░ ░▒  ░ ░
  ░ ░    ▒ ░ ░    ░   ░░   ░   ░   ▒     ░░   ░  ▒ ░   ░   ░  ░  ░  
    ░  ░ ░   ░         ░           ░  ░   ░      ░     ░  ░      ░  
                  ░                                                                                                                                      
";
            Clear();
            WriteLine(about);
            ReadKey(true);
            RunMainMenu();
        }

        private void PlayGame()
        {
            string logo = @"
 ▄████▄   ▒█████   ██▓     ▒█████   ██▀███  
▒██▀ ▀█  ▒██▒  ██▒▓██▒    ▒██▒  ██▒▓██ ▒ ██▒
▒▓█    ▄ ▒██░  ██▒▒██░    ▒██░  ██▒▓██ ░▄█ ▒
▒▓▓▄ ▄██▒▒██   ██░▒██░    ▒██   ██░▒██▀▀█▄  
▒ ▓███▀ ░░ ████▓▒░░██████▒░ ████▓▒░░██▓ ▒██▒
░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░▓  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░
  ░  ▒     ░ ▒ ▒░ ░ ░ ▒  ░  ░ ▒ ▒░   ░▒ ░ ▒░
░        ░ ░ ░ ▒    ░ ░   ░ ░ ░ ▒    ░░   ░ 
░ ░          ░ ░      ░  ░    ░ ░     ░     
░                                           ";
            string prompt = "What color paint would you like to watch dry?";
            string[] options = { "Red", "Green", "Blue", "Yellow", "Magenta", "Cyan" };
            DOS.CreateMenu(prompt, options, logo);
            int selectedIndex = DOS.SelectMenu();

            BackgroundColor = ConsoleColor.Black;
            switch (selectedIndex)
            {
                case 0:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nHere is some riveting red paint drying for you...");
                    break;
                case 1:
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nHere is some riveting green paint drying for you...");
                    break;
                case 2:
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("\nHere is some riveting blue paint drying for you...");
                    break;
                case 3:
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("\nHere is some riveting yellow paint drying for you...");
                    break;
                case 4:
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine("\nHere is some riveting magenta paint drying for you...");
                    break;
                case 5:
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("\nHere is some riveting cyan paint drying for you...");
                    break;
            }
            ResetColor();
            ExitGame();

        }
    }
}
