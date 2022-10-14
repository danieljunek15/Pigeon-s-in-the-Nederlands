using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    //De HP bar van de boss. Aan geven in edditor.
    public Slider hpBar;

    //De boss GameObject zelf. Aan geven in edditor.
    [Header("Bos to despawn")]
    public GameObject bosToDespawn;

    //Boss death sound source. Aan geven in edditor.
    [Header("Boss death sound")]
    public AudioSource bossDeathSound;

    //Boss whenHit damage sound source. Aan geven in edditor.
    [Header("Boss damage sound")]
    public AudioSource bossDamageSound;

    //Hier word een var aangemaakt om later de static value in te stoppen van de game diffeculty.
    private string difficulty;

    //Bij elke frame word Update() uitgevoerd.
    public void Update()
    {
        //Als hpBar.value lager of gelijk is aan nul doe iets.
        if (hpBar.value <= 0)
        {
            //Speel death audio van boss.
            bossDeathSound.Play();
            //Muis word weer zicht baar.
            Cursor.visible = true;
            //Muis word niet meer vast gehouden op de zelfde plek.
            Cursor.lockState = CursorLockMode.None;
            //Aan geven wat de static var gameStatus in class MainMenu is voor volgende scene.
            MainMenu.gameStatus = "Victory";
            //Destroy GameObject van boss.
            Destroy(bosToDespawn.gameObject);
            //Start nu de scene RestartScene.
            SceneManager.LoadScene("RestartScene");
        }
    }

    //Wanneer er een botsing is tussen twee objecten geef dan mee wat de boss heeft geraakt.
    public void OnCollisionEnter(Collision other)
    {
        //Var zetten met de diffeculty dat is aan gegeven in de mainMenue.
        difficulty = MainMenu.difficulty;

        //Als var gelijk is aan string doe iets.
        if (other.gameObject.name == "Bullet(Clone)")
        {
            //Als var gelijk is aan string doe iets.
            if (difficulty == "Eazy")
            {
                hpBar.value -= 1000;
                bossDamageSound.Play();
            }
            //Anders als var gelijk is aan string doe iets.
            else if (difficulty == "Normal")
            {
                hpBar.value -= 100;
                bossDamageSound.Play();
            }
            //Anders als var gelijk is aan string doe iets.
            else if (difficulty == "Hard")
            {
                hpBar.value -= 10;
                bossDamageSound.Play();
            }
        }
    }
}
