using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float x;
    private float y;
    public float Speed = 5f;
    private Rigidbody rb;


	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
        x = Input.GetAxis("Horizontal"); // premet de deplacer le personnage laterallement avec les fleches
        y = Input.GetAxis("Vertical");        
        Mouvement(x, y);
    }
    void Mouvement(float x, float y)
    {
        Vector3 Deplacement = new Vector3(x * Speed, rb.velocity.y , y * Speed); // créé le deplacement
        rb.velocity = Deplacement;

    }
    
   
}
