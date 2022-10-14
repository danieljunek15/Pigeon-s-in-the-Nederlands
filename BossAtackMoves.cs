using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtackMoves : MonoBehaviour
{
    //Hier vraag ik voor de shit bal model. Aan geven in edditor.
    [Header("De shitball")]
    public Transform shitBall;

    //Hier vraag ik voor wat de holder is en maak ik een paar variable aan. Aan geven in edditor.
    [Header("Shit long ball stats")]
    public Transform longShitBallHolder;
    public float longAttackSpeed;
    public bool longShitBallCooldown;
    public float longShitSpeed;

    //Audio source voor wanneer de bos aanvalt. Aan geven in edditor.
    [Header("Boss attack sound")]
    public AudioSource bossAttackSound;

    //Dit is een teidelijke var die ik gebruik voor de attackcooldown zo verander ik de orginele var niet waardoor ik een static atack speed krijg.
    private float longShitBallCooldownTime;
    
    //Wanneer game opstart set ik de waarde van var longShitBallCooldownTime.
    public void Start()
    {
        longShitBallCooldownTime = longAttackSpeed;
    }

    //Bij elke frame check ik wat de waarden is van longShitBallCooldown als true doe iets, anders als false doe iets.
    public void Update()
    {
        //Als longShitBallCooldown is true doe iets.
        if (longShitBallCooldown)
        {
            //Roep functie aan voor het schieten van de shit bal.
            LongShitBallAnimation();
            
            //De audio voor de attack move word nu afgespeeld. bossAttackSound is de audio file en Play() is de functie van unity om de audio af te spelen.
            bossAttackSound.Play();

            //Zet var false wanneer geschoten heb.
            longShitBallCooldown = false;
            //Zet time weer naar orginele waarden.
            longShitBallCooldownTime = longAttackSpeed;
        }
        //Als longShitBallCooldown is false doe iets.
        else if (!longShitBallCooldown)
        {
            //Makelijke timer.
            longShitBallCooldownTime -= Time.deltaTime;
            //Als longShitBallCooldownTime lager dan 0 is doe iets.
            if (longShitBallCooldownTime < 0)
            {
                //Zet var naar true.
                longShitBallCooldown = true;
            }
        }
    }

    //Functie waar ik de shit bal ophaal en gebruik. Doel is een shit bal af schieten.
    public void LongShitBallAnimation()
    {
        //Zeg wat ik van waar wil spawnen.
        Transform longShitTrans = Instantiate(shitBall, longShitBallHolder.position, longShitBallHolder.rotation);
        //Get rb van shit bal.
        Rigidbody longShitRB = longShitTrans.GetComponent<Rigidbody>();
        //Zech waarnaartoe ik shitbal moet schieten en hoehard.
        longShitRB.AddRelativeForce(Vector3.forward * longShitSpeed);
        Destroy(longShitRB.gameObject, 5);
    }
}
