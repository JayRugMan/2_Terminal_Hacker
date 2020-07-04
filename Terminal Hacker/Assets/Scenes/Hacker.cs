using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration
    string[][] allPasswords = { 
        new string[] { "apron", "knife", "sink", "noodle", "oven", "toaster" },
        new string[] { "microphone", "boombox", "melodious", "instrument" }
    };

    // Game State
    int level;
    string[] levelNames = { "kitchen", "sound system", "smarthome core system" };
    int attemptsLeft;
    string pw;
    enum screen { MainMenu, Password, Win, Caught }
    screen currentScreen;

    // Start is called before the first frame update
    void Start() {
        string playerName = "Jason";
        string greeting = "Hello " + playerName;
        ShowMainMenu(greeting);
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
        string playerName = "Jason";
        if (currentScreen != screen.Caught) {
		    if (input == "menu") {  // typing "menu" will always get you to main menu, unless caught
                print("Returing to Main Menu.");
                string greeting = "Sure, " + playerName + ", have another go.";
                ShowMainMenu(greeting);
            }
            else{
                switch (currentScreen) {
                    case screen.MainMenu:
                        RunMainMenu(input);
                        break;
                    case screen.Password:
                        GuessPassword(input);
                        break;
                    case screen.Win:
                        if (input == "exit") {
                            string greeting = "Hello " + playerName;
                            ShowMainMenu(greeting);
                        }
                        break;
                }
            }
        }
	}

    void RunMainMenu(string input) {
        bool isValidLevelNumber = ( input == "1" || input == "2" );
        if (isValidLevelNumber) {
            level = int.Parse(input);
            attemptsLeft = (6 / level);  // gets harder at each level
            int index1 = level - 1;
            int index2 = Random.Range(0, allPasswords[index1].Length);
            pw = allPasswords[index1][index2];
            StartGame(attemptsLeft);
        }
        else if (input == "1234") {  // easter egg
            print("That was a secret");
            string greeting = "Hey, who told you my luggage combo?!";
            ShowMainMenu(greeting);
        }
        else {
            Terminal.WriteLine("Select from the listed options:");
        }
    }
    
    void StartGame(int attemptsLeft) { 
        currentScreen = screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine( attemptsLeft + " Attept(s) left to access " + levelNames[(level - 1)] );
        Terminal.WriteLine("Password: ");
    }

    void GuessPassword(string input) {
        if (input == pw) {
            YouWin();
        }
        else {
            attemptsLeft--;
            if (attemptsLeft == 0) {
                YouFail();
            }    
            else {
                StartGame(attemptsLeft);
            }
        }
    }

    void YouWin() {
        currentScreen = screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Connected to the " + levelNames[(level - 1)] );
        Terminal.WriteLine("(type 'exit' to exit)");
    }

    void YouFail() {
        currentScreen = screen.Caught;
        Terminal.ClearScreen();
        Terminal.WriteLine("Unauthorized Access Detected!");
        Terminal.WriteLine("The authorities have been alerted!!!!!!");
        Terminal.WriteLine("Tracing has begun... CUT TAIL AND RUN!!");
    }
}
