using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Zet static var die van scene naar scene gelezen kan worden.
    public static string difficulty;
    public static string gameStatus;

    //Functie word aan geroepen wanneer player op de knop Eazy mode klickt.
    public void Eazy()
    {
        //Zet gamemode waarden.
        difficulty = "Eazy";
        //Load scene 1.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Functie word aan geroepen wanneer player op de knop Normal mode klickt.
    public void Normal()
    {
        //Zet gamemode waarden.
        difficulty = "Normal";
        //Load scene 1.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Functie word aan geroepen wanneer player op de knop Hard mode klickt.
    public void Hard()
    {
        //Zet gamemode waarden.
        difficulty = "Hard";
        //Load scene 1.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
