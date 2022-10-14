using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortShitBalMove : MonoBehaviour
{
    //Aangeven wat de shitball is in edditor.
    [Header("De shitdisk prefab hier")]
    public Transform shitBall;

    //Aangeven wat de shitballHolder is in edditor.
    [Header("De shitball holder hier")]
    public Transform shortShitBallHolder;

    //Shitball stats en vars worden hier aangemaakt zonder waarden.
    [Header("De shitball stats hier")]
    public float shortAttackSpeed;
    public bool shortShitBallCooldown;
    public float shortShitSpeed;

    //Var voor timer.
    private float shortShotBallCooldownTime;

    //Wanneer game start gaat deze functie zich een keer aan roepen.
    public void Start()
    {
        //Var is var (Voor timer).
        shortShotBallCooldownTime = shortAttackSpeed;
    }

    //Functie word aangeroepen bij elke frame.
    public void Update()
    {
        //Als var true is doe iets.
        if (shortShitBallCooldown)
        {
            //Roept hier Functie aan voor atach animatie.
            ShortShitBallAnimation();

            //Var is false
            shortShitBallCooldown = false;
            //Reset timer waarden.
            shortShotBallCooldownTime = shortAttackSpeed;
        }
        //Anders als niet true.
        else if (!shortShitBallCooldown)
        {
            //Zet timmer.
            shortShotBallCooldownTime -= Time.deltaTime;
            //Als var lager is dan 0 doe iets.
            if (shortShotBallCooldownTime < 0)
            {
                //Var is true.
                shortShitBallCooldown = true;
            }
        }
    }

    //Functie voor de logica van de shitball.
    public void ShortShitBallAnimation()
    {
        //Spawn aangegeven Transform in deze positie en met deze rotatie.
        Transform shortShitTrans = Instantiate(shitBall, shortShitBallHolder.position, shortShitBallHolder.rotation);
        //Aan geven dat shortShitRB shortShitTrans zijn Rigidbody is en dat ophalen.
        Rigidbody shortShitRB = shortShitTrans.GetComponent<Rigidbody>();
        //shortShitRB force geven ricting vector.forward (De blauwe pijl) keer aangegeven speed.
        shortShitRB.AddRelativeForce(Vector3.forward * shortShitSpeed);
        //Destroy dit object na 0.4 sec.
        Destroy(shortShitRB.gameObject, 0.4f);
    }
}
