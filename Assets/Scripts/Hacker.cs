using UnityEngine;
public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    string greeting;
    string[] passw1 = { "note", "edit", "file", "easy" };//easy passwords
    string[] passw2 = { "caster", "trivial", "build", "tools", "sets" };//medium passwords
    string[] passw3 = { "medium", "control", "ready", "complete", "online" };//hard passwords
    const string menuHint = "Type menu to go back to the menu";
    string passw;
    //Game State
    public int level;
    public enum Screen { MainMenu, Password, Win };
    public Screen currentScreen;
    string close= "Type quit/close/exit to close the game";
    // Use this for initialization
    void Start()
    {
        greeting = "Hello There";
        ShowMainMenu(greeting);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine(close);
    }
    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")// Easter Egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
            Terminal.WriteLine(menuHint);
        }
        else if (input == "General Kenobi")// Easter Egg
        {
            Terminal.WriteLine("You are a bold one");
            Terminal.WriteLine(menuHint);
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }
    void OnUserInput(string input)
    {
        if (input == "menu") // we should always be able to go to main menu directly
        {
            ShowMainMenu(greeting);

        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            PasswordCheck(input);
        }
        else if (input == "exit" || input == "close" || input == "quit")
        {
            Terminal.WriteLine("If on the web, close the tab");
            Application.Quit();
        }
    }
    //Method to check password string
    void PasswordCheck(string input)
    {
        if (input == passw)
        {
            WinDisplay();//setting  game state to win
        }
        else
        {
            AskForPassword();
        }
    }

    void WinDisplay()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine(close);
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
  _   _ ___ ____ _____ 
 | \ | |_ _/ ___| ____|
 |  \| || | |   |  _|  
 | |\  || | |___| |___ 
 |_| \_|___\____|_____|
                            
");
                break;
            case 2:
                Terminal.WriteLine(@"
   ____  ___   ___  ____  
  / ___|/ _ \ / _ \|  _ \ 
 | |  _| | | | | | | | | |
 | |_| | |_| | |_| | |_| |
  \____|\___/ \___/|____/
                    
");
                break;
            case 3:
                Terminal.WriteLine(@"
   ____ ____  _____    _  _____ 
  / ___|  _ \| ____|  / \|_   _|
 | |  _| |_) |  _|   / _ \ | |  
 | |_| |  _ <| |___ / ___ \| |  
  \____|_| \_\_____/_/   \_\_|
                                                                                            
");
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + passw.Anagram());//for password hint
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine(close);
    }
    void SetRandomPassword()
    {
        int index;
        switch (level)
        {
            case 1:
                index = Random.Range(0, passw1.Length);
                passw = passw1[index];
                break;
            case 2:
                index = Random.Range(0, passw2.Length);
                passw = passw2[index];
                break;
            case 3:
                index = Random.Range(0, passw3.Length);
                passw = passw3[index];
                break;
            default:
                break;
        }
    }
}