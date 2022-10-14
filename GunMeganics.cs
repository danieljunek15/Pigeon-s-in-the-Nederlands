using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunMeganics : MonoBehaviour
{
    //Holder en vars voor de kogel van player gun.
    [Header("De bullet")]
    public Transform bullet;
    public Transform bulletHolder;
    public float bulletSpeed;

    //Holder en vars voor de shel van player gun.
    [Header("De shell")]
    public Transform shel;
    public Transform shelHolder;
    public float shelSpeed;

    //Extra stats voor de player gun effects.
    [Header("Gun stats")]
    public float attackSpeed;
    public bool bulletCooldown;

    //Audio source van schot. Aangeven in de edditor.
    [Header("Gun shot sound")]
    public AudioSource gunShotAudio;

    //Een var die aan gemaakt word voor een timer met type float.
    private float bulletCooldownTime;

    //Wanneer game start doe dit een keer uit voeren.
    public void Start()
    {
        //bulletCooldownTime waarden geven voor timer.
        bulletCooldownTime = attackSpeed;
    }

    //Bij elke frame voer deze functie uit.
    public void Update()
    {
        //Als rechter muis knop en bulletCooldown true is doe iets.
        if (Input.GetMouseButton(1) && bulletCooldown == true)
        {
            //Zet waarden voor de timer weer goed.
            bulletCooldownTime = attackSpeed;
            //Roep functie aan voor kogel actie.
            BulletAnimation();
            //Roep functie aan voor shel actie.
            ShelAnimation();
            //Zet false.
            bulletCooldown = false;
        }
        //Anders als var hoger is dan 0 en var false is doe iets.
        else if (bulletCooldownTime > 0 && bulletCooldown == false)
        {
            //var is nu min Huidige tijd.
            bulletCooldownTime -= Time.deltaTime;
        }
        //Anders als var lager is dan 0 en var false is doe iets.
        else if (bulletCooldownTime < 0 && bulletCooldown == false)
        {
            //Var is true.
            bulletCooldown = true;
        }
    }

    //Functie van de shel
    public void ShelAnimation()
    {
        //Spawn aangegeven Transform in deze positie en met deze rotatie.
        Transform shelTrans = Instantiate(shel, shelHolder.position, shelHolder.rotation);
        //Aan geven dat shelRB shelTrans zijn Rigidbody is en dat ophalen.
        Rigidbody shelRB = shelTrans.GetComponent<Rigidbody>();
        //shelRB force geven ricting vector.forward (De blauwe pijl) keer aangegeven speed.
        shelRB.AddRelativeForce(Vector3.forward * shelSpeed);
        //Destroy dit object na 5 sec.
        Destroy(shelRB.gameObject, 5);
    }

    //Functie van de bullet
    public void BulletAnimation()
    {
        //Spawn aangegeven Transform in deze positie en met deze rotatie.
        Transform bulletTrans = Instantiate(bullet, bulletHolder.position, bulletHolder.rotation);
        //Aan geven dat bulletRB bulletTrans zijn Rigidbody is en dat ophalen.
        Rigidbody bulletRB = bulletTrans.GetComponent<Rigidbody>();
        //bulletRB force geven ricting vector.up (De groene pijl) keer aangegeven speed.
        bulletRB.AddRelativeForce(Vector3.up * bulletSpeed);
        //Destroy dit object na 3 sec.
        Destroy(bulletRB.gameObject, 3);
    }
}
