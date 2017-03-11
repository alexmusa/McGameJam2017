using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {

    private float x;
    private float y;
    public float Speed = 5f;
    private Rigidbody rb;
    public float ForceSaut = 2f;
    public GroundCheck groundcheck;
    public bool AuSol;

    private string XAxis;
    private string YAxis;
    private KeyCode jumpButton;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        groundcheck.GetComponent<GroundCheck>();


    }

    void Create(int playerIndex) {
        switch (playerIndex)
        {
            case 0:
                XAxis = "Horizontal1";
                YAxis = "Vertical1";
                jumpButton = KeyCode.Joystick1Button0;
                break;
            case 1:
                XAxis = "Horizontal2";
                YAxis = "Vertical2";
                jumpButton = KeyCode.Joystick2Button0;
                break;
            case 2:
                XAxis = "Horizontal3";
                YAxis = "Vertical3";
                jumpButton = KeyCode.Joystick3Button0;
                break;
            case 3:
                XAxis = "Horizontal4";
                YAxis = "Vertical4";
                jumpButton = KeyCode.Joystick4Button0;
                break;
            default:
                Debug.Log("Something's fucky");
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        x = Input.GetAxis(XAxis); // premet de deplacer le personnage laterallement avec les fleches
        y = Input.GetAxis(YAxis);        
        Mouvement(x, y);

        AuSol = groundcheck.isGrounded;
        if (AuSol)
        {
            Sauter();
        }

        Rotation();
        
    }
    void Mouvement(float x, float y)
    {
        Vector3 Deplacement = new Vector3(x * Speed, rb.velocity.y , y * Speed); // créé le deplacement
        rb.velocity = Deplacement;

    }
    void Sauter()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            Vector3 VecteurSaut = new Vector3(0f, ForceSaut, 0f);
            rb.AddForce(VecteurSaut, ForceMode.Impulse);
        }
    }
    void Rotation()
    {
		float rotate = Mathf.Atan(x / y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, rotate, 0f);
    }


}
