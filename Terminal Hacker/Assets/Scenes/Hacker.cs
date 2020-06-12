using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        string playerName = "Jason";
        string greeting = "Hello " + playerName;
        ShowMainMenu(greeting);
    }
    void ShowMainMenu(string tagline) {
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
		if (input == "menu") {
            print("Returing to Main Menu.");
            string greeting = "Sure, " + playerName + ", have another go.";
            ShowMainMenu(greeting);
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
}
