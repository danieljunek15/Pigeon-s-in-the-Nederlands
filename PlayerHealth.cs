using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Var zetten voor HP bar player aangeven in edditor.
    public Slider hpBar;

    //Audio source voor wanneer player dm krijgt. Aangeven in edditor.
    [Header("Player DM sound")]
    public AudioSource getHit;

    //Bij elke frame doe dit.
    public void Update()
    {
        //Als hpBar.value lager of gelijk is aan 0 doe iets.
        if (hpBar.value <= 0)
        {
            //Zet muis zichtbaar.
            Cursor.visible = true;
            //Muis mag weer bewegen zit niet meer vast.
            Cursor.lockState = CursorLockMode.None;
            //Aan geven welke waarden gameStatus heeft voor volgende scene.
            MainMenu.gameStatus = "Loser";
            //Load scene 2.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Wanneer iets player raakt roep deze functie aan.
    public void OnCollisionEnter(Collision other)
    {
        //Als var gelijk is aan string of var gelijk is aan andere string doe iets.
        if (other.gameObject.name == "SHITBall(Clone)" || other.gameObject.name == "SHITDisk(Clone)")
        {
            //var is min 10.
            hpBar.value -= 10;
            //Roep een audio aan wanneer player geraakt word.
            getHit.Play();
        }
    }
}
