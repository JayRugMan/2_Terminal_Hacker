using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration
    const string exitHint = "(Type \"exit\" for main menu)";
    string[][] allPasswords = { 
        new string[] { "apron", "knife", "sink", "noodle", "oven", "toaster" },
        new string[] { "microphone", "boombox", "melodious", "instrument", "legato", "synthesizer", "soprano" },
        new string[] { "motherboard", "hexidecimal", "virtualization", "interface", "environment", "initiator" }
    };
    string playerName = "";
    int attemptsLeft;
    string password;

    // Game State
    int level;
    string[] levelNames = { "kitchen", "sound system", "home system core" };
    enum screen { Intro, MainMenu, Password, Win, Caught }
    screen currentScreen;

    // Start is called before the first frame update
    void Start() {
        ShowIntro();
    }

    void ShowIntro() {
        currentScreen = screen.Intro;
        Terminal.WriteLine("Enter name: ");
    }

    void ShowMainMenu(string tagline) {
        currentScreen = screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(tagline);
        Terminal.WriteLine("\nBeware, using this program is illegal  in 48 states!");
        Terminal.WriteLine("Select from Access Menu:");
        Terminal.WriteLine("1- The Kitchen");
        Terminal.WriteLine("2- The Sound System");
        Terminal.WriteLine("3- The Smart-Home Core System");
    }

	void OnUserInput(string input) {
        if (currentScreen != screen.Caught) {
            if (input == "exit") {  // typing "exit" will always get you to main menu, unless caught
                string greeting = "Sure, " + playerName + ", have another go.";
                ShowMainMenu(greeting);
            }
            else{
                switch (currentScreen) {
                    case screen.Intro:
                        playerName = input;
                        string greeting = "Hello " + playerName;
                        ShowMainMenu(greeting);
                        break;
                    case screen.MainMenu:
                        RunMainMenu(input);
                        break;
                    case screen.Password:
                        CheckPassword(input);
                        break;
                    case screen.Win:
                        print("Not sure what yet"); // Need something you can do when you gain access
                        Terminal.WriteLine(exitHint);
                        break;
                }
            }
        }
        else if (input == "pkill -9 trace && reset") { // if caught, only killing the trace and resetting the system will get you back to the main menu
            string greeting = "Trace process killed\nSystem reset";
            ShowMainMenu(greeting);
        }
	}

    void RunMainMenu(string input) {
        bool isValidLevelNumber = ( input == "1" || input == "2" || input == "3" );
        if (isValidLevelNumber) {
            ValidLevelSelected(input);
        }
        else if (input == "1234") {  // easter egg
            EasterEggSelected();
        }
        else {
            Terminal.WriteLine("Select from the listed options:");
            Terminal.WriteLine(exitHint);
        }
    }

    void ValidLevelSelected(string input) {
        level = int.Parse(input);
        SetAttempts(level);
        SetRandomPassword(level);
        AskForPassword(attemptsLeft);
    }

    void EasterEggSelected() {
        print("That was a secret");
        string greeting = "Hey, who told you my luggage combo?!";
        ShowMainMenu(greeting);
    }

    void SetAttempts(int level) {
        attemptsLeft = (6 / level);  // gets harder at each level
    } 

    void SetRandomPassword(int level) {
        int index1 = level - 1;
        int index2 = Random.Range(0, allPasswords[index1].Length);
        password = allPasswords[index1][index2];
    }
    
    void AskForPassword(int attemptsLeft) { 
        currentScreen = screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine( attemptsLeft + " Attept(s) left to access " + levelNames[(level - 1)] );
        Terminal.WriteLine("enter password, hint: " + password.Anagram());
        Terminal.WriteLine(exitHint);
    }

    void CheckPassword(string input) {
        if (input == password) {
            DisplayWinScreen();
        }
        else {
            CheckFail();
        }
    }

    void DisplayWinScreen() {
        currentScreen = screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Connected to the " + levelNames[(level - 1)] );
        ShowLevelReward();
        Terminal.WriteLine(exitHint);
    }

    void CheckFail() {
        attemptsLeft--;
        if (attemptsLeft == 0) {
            DisplayFailScreen();
        }    
        else {
            AskForPassword(attemptsLeft);
        }
    }

    void ShowLevelReward() {
        switch(level) {
            case 1:
                Terminal.WriteLine(@"
                 S S S
                _| | |_
              _{._._._.}_
             { . _ . _ . }
           __(@#@#@#@#@#@)__
          ~~~~~C~~A~~K~~E~~~~
          "
                );
                break;
            case 2: 
                Terminal.WriteLine(@"

  |_________________________________|
  | | | | | | | | | | | | | | | | | |
  | L L | L L L | L L | L L L | L L |
  |_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
 "
                );
                break;
            case 3:
                Terminal.WriteLine(@"
  __                     _           
 (        _ _/  _  _    / )     _  _ 
__)  (/ _)  /  (- //)  (__  () /  (- 
     /                               
"
                );
                break;
        }
    }

    void DisplayFailScreen() {
        currentScreen = screen.Caught;
        Terminal.ClearScreen();
        Terminal.WriteLine("Unauthorized Access Attempts Detected!");
        Terminal.WriteLine("The authorities have been alerted!!!!!!");
        Terminal.WriteLine("Tracing has begun... CUT TAIL AND RUN!!");
    }
}
