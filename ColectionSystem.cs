using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColectionSystem : MonoBehaviour
{
    //Header zorgd er voor dat je een title kan zien in je Unity edditor.
    [Header("Spawn information")]
    //Vraag naar object to spawn moet aan geven in edditor.
    public GameObject objectToSpawn;
    //Vraag naar object locatie to spawn object aan geven in edditor
    public Transform locationToSpawn;

    //Var voor aantal patatjes in altar wanneer altaar iets moet doen.
    public int aantalPatatjesVoorAltarVol = 20;

    //Bool var.
    private bool whenToSpawn;
    //Float value voor timer.
    private float spawnTime;

    [Header("Altar to despawn")]
    //Object voor altar aan geven in edditor.
    public GameObject altar;

    [Header("Aantal patatjes in altar")]
    //Text object om waarden aan tegeven van uit de code aangeven welke TextMesh het is in edditor.
    public TextMeshProUGUI aantalPatatjesInAltarHolder;

    [Header("Player offer sound")]
    //De audio source van wanneer item in altaar word gelegd. Aan geven in edditor.
    public AudioSource offerToAltar;

    [Header("Player offer full sound")]
    //Audio source wanneer altaar vol is en een gun spawned. Aan geven in edditor.
    public AudioSource offerToAltarFull;

    //Int waar de aantal patatjes word bij gehouden.
    private int aantalPatatjes;

    //Functie die op start een paar variables waarden geeft.
    public void Start()
    {
        aantalPatatjes = 0;
        spawnTime = 0.1f;
        whenToSpawn = false;
    }

    //In de update word er afgeteld wanneer de altar moet despawnen en het item mag spawnen dit doet ie wanneer whenToSpawn true is.
    public void Update()
    {
        //Als whenToSpawn true is doe iets.
        if (whenToSpawn)
        {
            //Simpele timer
            spawnTime -= Time.deltaTime;

            //Wanneer spawnTime lager is of gelijk aan 0 doe iets.
            if (spawnTime <= 0)
            {
                //Deze functie werkt als volgd objectToSpawn waar het opbject moet spawnen in wat voor rotatie dit object moet spawnen.
                Instantiate(objectToSpawn, locationToSpawn.position, locationToSpawn.rotation);
                //Vernietig gameObject altar.
                Destroy(altar.gameObject);
            }
        }
    }

    //Wanneer er een coligen is op iets neem dit object mee en doe er iets mee.
    public void OnCollisionEnter(Collision other)
    {
        //Wanneer item op altar valt tel deze op in een var en destroy de item die op altar valt.
        if (other.gameObject.name == "Patatje")
        {
            //Elke keer dat er een patatje in het altaar wordt gestopt doe een extra met orginele waarden in var aantalPatatjes.
            aantalPatatjes += 1;

            //We passen de verzamelde patatjes dynamisch aan boven altar.
            aantalPatatjesInAltarHolder.text = $"Patatjes {aantalPatatjes}/20";

            //Destroy patatje die in altar is gelegd.
            Destroy(other.gameObject);

            //Wanneer er een patatje in de altaar word gegooid word er een audio gespeeld.
            offerToAltar.Play();

            //Als aantalPatatjes hoger is dan 5 dan doe iets.
            if (aantalPatatjes >= aantalPatatjesVoorAltarVol)
            {
                //whenToSpawn wordt nu actief gezet waardoor het de if triggert in de Update function.
                whenToSpawn = true;
                //Wanneer altaar vol is speel deze audio af.
                offerToAltarFull.Play();
            }
        }
    }
}
