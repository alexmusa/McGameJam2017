using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

    //public GameObject enemy;                // The enemy prefab to be spawned.
    //public float spawnTime = 3f;            // How long between each spawn.
    //public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private GameObject salle;

    private int nbPlayers = 4;

    private Object joueur; // Prefab du joueur
    private Object debris; // Prefab du debris

    private float timeSinceLastQuake = 0.0f;

    void Start ()
	{
        salle = GameObject.Find("Salle"); // Trouve la salle, l'objet servir ensuite à déclancher des Shake().

        joueur = Resources.Load("Joueur");

        for (int i = 0; i< nbPlayers; i++){
            GameObject go = Instantiate(joueur, new Vector3(2 + i * (8/nbPlayers), 1, 5), Quaternion.Euler(Vector3.zero)) as GameObject;
            go.SendMessage("Create", i);
        }



        debris = Resources.Load("Debris");
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", 6.0f, 0.5f); // Après 6s, appeller toutes les 0.5s
    }


    void Spawn ()
	{
        // Instancie un debris avec une durée de vie limitée.
        float lifetime = 10.0f;

        Vector3 position = new Vector3(1.0f + 8.0f * Random.value,
                                       11.0f + 8.0f * Random.value,
                                       1.0f + 8.0f * Random.value);

        Quaternion rotation = Quaternion.Euler(new Vector3(360 * Random.value,
                                                           360 * Random.value,
                                                           360 * Random.value));

        Destroy(Instantiate (debris, position, rotation), lifetime);
	}

    // Update is called once per frame
    void Update () {
        timeSinceLastQuake += Time.deltaTime;
        if (timeSinceLastQuake > 5f)
        {
            timeSinceLastQuake -= 5f;
            salle.SendMessage("Quake", new float[] { 1.0f, 3.0f });
        }
    }
}

