using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGunHandler : MonoBehaviour
{
    //Var wanneer to spawn.
    private bool whenToSpawn;
    //Var hoelang te wachten voordat spawnt.
    private float timeBeforeSpawning;

    //Game object aangeven van uit edditor voor player gun.
    public GameObject playerGun;
    //Game object aangeven van uit edditor voor gunspawn model.
    public GameObject spawnedGunModel;
    //Game object aangeven van uit edditor voor de boss to spawn.
    public GameObject bossToSpawn;

    [Header("SpawnLocatie")]
    //Spawn locatie aan geven met een Transform in edditor.
    public Transform locationGunModel;

    [Header("Bullet model to unlock")]
    //Game object aangeven van uit edditor voor de kogel.
    public GameObject bulletModel;

    //Deze functie zet twee variables wanneer game opgestart word.
    public void Start()
    {
        //Var is false.
        whenToSpawn = false;
        //Var voor timer waarden geven.
        timeBeforeSpawning = 5.0f;
    }

    //Roep deze functie aan bij elke frame.
    public void Update()
    {
        //Als whenToSpawn true is doe iets.
        if (whenToSpawn)
        {
            //Dit is een simpele timer.
            timeBeforeSpawning -= Time.deltaTime;
            //Als timeBeforeSpawning lager of gelijk is aan 0 doe iets.
            if (timeBeforeSpawning <= 0)
            {
                //Boss word actief gezet.
                bossToSpawn.SetActive(true);
                
                //GunModel word verwijderd.
                Destroy(spawnedGunModel.gameObject);
            }
        }
    }

    //Deze functie checkt of er iets tegen hem aan komt en geeft mee wat het is.
    public void OnCollisionEnter(Collision other)
    {
        //Als GameObject de naam Player heeft doe iets.
        if (other.gameObject.name == "Player")
        {
            //GameObject playerGun wordt true gezet.
            playerGun.SetActive(true);
            bulletModel.SetActive(true);
            //whenToSpawn wordt nu actief gezet waardoor het de if triggert in de Update function.
            whenToSpawn = true;
        }
    }
}
