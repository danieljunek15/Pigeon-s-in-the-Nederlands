using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PickAndDDrop
{
    public class PickUpAndDrop : MonoBehaviour
    {
        //De header is er voor zodat we in Unity een title hebben voor de onderstaande settings.
        [Header("Pickup Settings")]
        //Var die de player pickup area object moet zijn.
        [SerializeField] Transform playerHand;
        //Dit moet het object zijn dat ik wil dragen als player.
        private GameObject heldItem;
        //Dit is de rigedBody van het object dat we willen vast houden.
        private Rigidbody heldItemRB;

        [Header("Physics Parameters")]
        //Deze var moet de range en force bevaten voor het interacten met items.
        [SerializeField] private float pickupRange = 5.0f;
        [SerializeField] private float pickupForce = 150.0f;

        private void Update()
        {
            //Als leftclick is ingedrukt
            if (Input.GetMouseButtonDown(0))
            {
                //Als player niks vast heeft, dus als heldItem is leeg.
                if (heldItem == null)
                {
                    //Var gezet voor de Raycast (raycast is de hit range voor player sperpective).
                    RaycastHit hit;
                    //Schiet de raycast om mogelijk een item vast te pakken als iets in range is.
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                    {
                        //De functie aan roepen om een item op te pakken, we geven een var mee van de item die we willen op pakken.
                        PickupItem(hit.transform.gameObject);
                    }
                }
                else
                {
                    //Roep functie aan DropItem();
                    DropItem();
                }
            }
            //Als heldItem niet gelijk is aan null doe iets
            if (heldItem != null)
            {
                //Roep functie aan MoveItem();
                MoveItem();
            }
        }

        public void PickupItem(GameObject item)
        {
            //Als item een Rigidbody heeft alleen dan willen we er wat mee doen.
            //Voor de toekomst wil ik er ook een layer aan vast binden anders kan ik alles vast pakken wat een Rigidbody heeft.
            if (item.GetComponent<Rigidbody>() && item.gameObject.layer == 12)
            {
                //Zet var voor item als het heeft voldaan aan item creteria.
                heldItemRB = item.GetComponent<Rigidbody>();
                //Item zwaartekracht weg halen (dus false zetten).
                heldItemRB.useGravity = false;
                heldItemRB.drag = 10;
                //Item geen toestemming geven om te draaien.
                heldItemRB.constraints = RigidbodyConstraints.FreezeRotation;

                //Locatie van item aan passen naar player hand
                heldItemRB.transform.parent = playerHand;
                //Waarden geven aan var dat de item moet bevatten dat de player wilt vastpakken.
                heldItem = item;
            }
        }

        //functie voor het droppen van item.
        public void DropItem()
        {
            //Zwaarte kracht weer aan zeten voor de item die player vast had.
            heldItemRB.useGravity = true;
            heldItemRB.drag = 1;
            //Rotation is weer mogelijk voor de item.
            heldItemRB.constraints = RigidbodyConstraints.None;

            //Aangeven dat er niks meer in hand zit.
            heldItemRB.transform.parent = null;
            //Aangeven dat er niks meer in hand zit.
            heldItem = null;
        }

        //Functie voor het verplaatsen van item wanneer vast gehouden.
        public void MoveItem()
        {
            //Als de afstand groter is dan 10CM (ingame) verplaats item naar plareyHand.
            if (Vector3.Distance(heldItem.transform.position, playerHand.position) > 0.1f)
            {
                //Aangeven waarnaartoe item zich moet verplaatsen en hoever.
                Vector3 moveDirection = (playerHand.position - heldItem.transform.position);
                //Verplaats item naar locatie met x snelheid.
                heldItemRB.AddForce(moveDirection * pickupForce);
            }
        }
    }
}