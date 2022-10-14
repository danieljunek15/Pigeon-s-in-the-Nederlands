using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    //TextHolder van de game status Gewonnen of verloren.
    public TextMeshProUGUI gameStatusHolder;
    //TextHolder van de game diffeculty waarop is gespeeld.
    public TextMeshProUGUI difficultyHolder;

    //Hier worden de diffeculty en gamestatus var aangemaakt.
    private string gameStatus;
    private string difficulty;

    //Wanneer script word geladen laad deze functie dan als eerste een keer.
    public void Start()
    {
        //Var value geven van uit andere scene.
        gameStatus = MainMenu.gameStatus;
        //Var value geven van uit andere scene.
        difficulty = MainMenu.difficulty;

        //Aan geven wat er als text moet komen te staan in de TextHolder.
        gameStatusHolder.text = $"YOU are {gameStatus}";

        //Aan geven wat er als text moet komen te staan in de TextHolder.
        difficultyHolder.text = $"On {difficulty} game mode.";
    }

    //Dit is de restart functie die aangeroepen word wanneer de player op de restart knop drukt.
    public void Restart()
    {
        //Load scene 0.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //De quit functie wanneer player op quit drukt werkt alleen als het officieel is gelanceerd.
    public void Quit()
    {
        //Quit aplication.
        Application.Quit();
    }
}
