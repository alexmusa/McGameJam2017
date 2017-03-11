using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float x;
    private float y;
    public float Speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal"); // premet de deplacer le personnage laterallement avec les fleches
        y = Input.GetAxis("Vertical");
        Mouvement(x, y);
    }
    void Mouvement(float x, float y)
    {
        Vector3 Deplacement = new Vector3(x * Speed * Time.deltaTime, 0, y * Speed * Time.deltaTime); // créé le deplacement
        transform.Translate(Deplacement);// ***
    }
}
