using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Var voor player move speed.
    [Header("Movement")]
    public float moveSpeed;
    //Var voor player drag on ground.
    public float groundDrag;

    //Var voor player jump.
    public float jumpForce;
    //Var voor player jump cooldown.
    public float jumpCooldown;
    //Var voor wanneer player in de lucht zit speed controll.
    public float airMultiplier;
    //Bool voor wanneer player mag springen.
    bool readyToJump;

    [Header("Ground Check")]
    //Var voor player hoogte.
    public float playerHeight;
    //Layer aan geven voor wat de grond is.
    public LayerMask whatIsGround;
    //Bool voor wanneer player op grond staat of niet.
    [SerializeField] bool grounded;

    public Transform orientation;

    //Var voor mouse input.
    public float horizontalInput;
    public float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //Wanneer game opstart zet ik wat vars voor een keer.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //Hier roep ik een functie aan om de jump te restarten.
        ResetToJump();
    }

    //Bij elke frame roep deze functie aan.
    private void Update()
    {
        //Checken of er een grond is.
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 1.0f + 0.5f, whatIsGround);
    
        //Functie voor player input.
        PlayerInput();
        //Functie voor hoe snel de player mag.
        SpeedControl();

        //Als grounded true is doe iets.
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else 
        {
            rb.drag = 0;
        }
    }

    //Een andere soort functie net als Update.
    private void FixedUpdate()
    {   
        MovePlayer();
    }

    //Deze functie zet twee var met de user input.
    private void PlayerInput()
    {
        //Var maken voor het bewegen met de muis.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Als player space drukt niet een cooldown heeft en op de grond staat dan JUMP functie aan roepen.
        if (Input.GetKeyDown("space") && readyToJump && grounded)
        {
            //Roep functie jump aan
            Jump();
            //Var is false.
            readyToJump = false;
            //Voor tijd zetten. reset var.
            Invoke(nameof(ResetToJump), jumpCooldown);
        }
    }

    //Functie die voor de player movement moet zijn.
    private void MovePlayer()
    {
        //Bereken welke richting de player op wilt lopen.
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //Geef de player force om daadwerkelijk deze richting op te lopen.
        if (grounded)
        {
            //Deze var krijfgt force richting keer snelheid keer float en forceer dit.
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        //Anders als var is false doe iets.
        else if (!grounded)
        {
            //Deze var krijfgt force richting keer snelheid keer float keer var en forceer dit.
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        //Anders doe dit.
        else
        {
            //Error Log voor als er iets mis is.
            Debug.Log("Er is iets mis gegaan met de player movement.");
        }


    }

    //Functie voor de snelheid logica.
    private void SpeedControl()
    {
        //Zeggen wat de snelheid is van een bepaalde vector.
        Vector3 flatVel = new Vector3(rb.velocity.x, -5.0f, rb.velocity.z);

        //Als var hoger is dan var doe iets.
        if (flatVel.magnitude > moveSpeed)
        {
            //Zeggen wat de snelheid is van een bepaalde vector.
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    //Functie voor player jump logica.
    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //Geef var force ricting vector up (De groene pijl).
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    //Functie die de jump reset.
    private void ResetToJump()
    {
        //Bool word true.
        readyToJump = true;
    }
}
