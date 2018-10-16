using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    string greeting;
    string[] passw1 = {"file", "edit", "view", "search"};
    string[] passw2 = { "hamster", "weasel", "mammoth", "dragon" };
    public string passw;
    //Game State
    public int level;
    public enum Screen { MainMenu, Password, Win };
    public Screen currentScreen;
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
    }
    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2");
        if(isValidLevel)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
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
    }
    //Method to check password string
    void PasswordCheck(string input)
    {
        if (input == passw)
        {
            WinDisplay();
        }
        else
        {
            Terminal.WriteLine("Wrong Password. Try Again!");
        }
    }

    void WinDisplay()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Correct Password. Have a book!");
                Terminal.WriteLine(@"    
                    _________
                   /________//
                  /________//                         
                 /________//                                   
                (________(/
                                    ");
                break;
            case 2:
                Terminal.WriteLine(@"
.__   __.  __    ______  _______ 
|  \ |  | |  |  /      ||   ____|
|   \|  | |  | |  ,----'|  |__   
|  . `  | |  | |  |     |   __|  
|  |\   | |  | |  `----.|  |____ 
|__| \__| |__|  \______||_______|
                                  ");
                break;
            default:
                break;
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, passw1.Length);
                passw = passw1[index1];
                break;
            case 2:
                int index2 = Random.Range(0, passw2.Length);
                passw = passw2[index2];
                break;
            default:
                break;
        }
    }
}

    
