using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    //Var zetten voor cam rotatie
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        //Dit zorgt er voor dat de muis niet beweegt maar in het midden van het scherm blijft.
        Cursor.lockState = CursorLockMode.Locked;
        //Dit zorgt er voor dat je de muis niet kan zien wanneer in game.
        Cursor.visible = false;
    }

    //Bij elke frame voer dit uit deze functie is voor de player om zijn cam te bewegen met de muis.
    private void Update()
    {
        //Krijg muis input.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //Var is plus var.
        yRotation += mouseX;

        //Var is plus var.
        xRotation += mouseY;

        //Aangeven dat je via de x axes niet verder dan de helft kan bewegen.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate wanneer waarden word mee gegeven (Leterlijk elke frame.)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
