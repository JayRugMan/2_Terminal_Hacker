using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game State
    int level;
    enum screen { MainMenu, Password, Win }
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
        Terminal.WriteLine("\nBeware, using this program is illegal  in all 50 states!");
        Terminal.WriteLine("With that, what would you like to hack?");
        Terminal.WriteLine(" 1- The Kitchen");
        Terminal.WriteLine(" 2- The Sound System");
        Terminal.WriteLine(" 3- The Smart-Home Core System");
        Terminal.WriteLine("\nMake a selection:");
    }

	void OnUserInput(string input) {
        string playerName = "Jason";
		if (input == "menu") {  // typing "menu" will always get you to main menu
            print("Returing to Main Menu.");
            string greeting = "Sure, " + playerName + ", have another go.";
            ShowMainMenu(greeting);
        }
        else if (currentScreen == screen.MainMenu) {
            RunMainMenu(input);
        }
	}

    void RunMainMenu(string input) {
        if (input == "1") {
            level = 1;
            StartGame();
        }
        else if (input == "2") {
            level = 2;
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
        Terminal.WriteLine("You have chosed level " + level);
        Terminal.WriteLine("Password: ");
    }
}
