using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        Terminal.ClearScreen();
        Terminal.WriteLine("WARNING:\nBeware, using this program is illegal  in all 50 states!");
        Terminal.WriteLine("With that, what would you like to hack?");
        Terminal.WriteLine(" 1- The Kitchen");
        Terminal.WriteLine(" 2- The Sound System");
        Terminal.WriteLine(" 3- The Smart-Home Core System");
        Terminal.WriteLine("\nMake a selection:");
    }

    // Update is called once per frame
    void Update() {
        
    }
}
