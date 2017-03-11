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




    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        groundcheck.GetComponent<GroundCheck>();


    }

    // Update is called once per frame
    void Update () {
        x = Input.GetAxis("Horizontal1"); // premet de deplacer le personnage laterallement avec les fleches
        y = Input.GetAxis("Vertical1");        
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
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Vector3 VecteurSaut = new Vector3(0f, ForceSaut, 0f);
            rb.AddForce(VecteurSaut, ForceMode.Impulse);
        }
    }
    void Rotation()
    {
        float rotate = Mathf.Atan(y / x);
        transform.eulerAngles = new Vector3(0, rotate, 0);
    }


}
