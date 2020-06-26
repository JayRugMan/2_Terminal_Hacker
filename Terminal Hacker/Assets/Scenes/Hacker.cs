using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game State
    string level;
    int fails = 3;
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
            else if (currentScreen == screen.MainMenu) {
                RunMainMenu(input);
            }
            else if (currentScreen == screen.Password) {
                GuessPassword(input);
            }
            else if (currentScreen == screen.Win) {
                if (input == "exit") {
                    string greeting = "Hello " + playerName;
                    ShowMainMenu(greeting);
                }
            }
        }
	}

    void RunMainMenu(string input) {
        if (input == "1") {
            level = "Kitchen";
            pw = "knife";
            StartGame();
        }
        else if (input == "2") {
            level = "Sound System";
            pw = "melodious";
            StartGame();
        }
        else if (input == "1234") {
            print("That was a secret");
            string greeting = "Hey, who told you my luggage combo?!";
            ShowMainMenu(greeting);
        }
        else {
            Terminal.WriteLine("Select from the listed options:");
        }
    }
    
    void StartGame() {
        currentScreen = screen.Password;
        Terminal.WriteLine("Attepting to access the " + level);
        Terminal.WriteLine("Password: ");
    }

    void GuessPassword(string input) {
        if (input == pw) {
            YouWin();
        }
        else {
            fails--;
            if (fails == 0) {
                YouFail();
            }    
            else {
                string greeting = "Password Failed! " + fails + " fail(s) left";
                currentScreen = screen.MainMenu;
                ShowMainMenu(greeting);
            }
        }
    }

    void YouWin() {
        currentScreen = screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Connected to the " + level);
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
