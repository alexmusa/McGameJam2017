using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour {
	
	float timeSinceLastQuake;

	// Use this for initialization
	void Start () {
		timeSinceLastQuake = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastQuake += Time.deltaTime;
		if (timeSinceLastQuake > 5f) {
			timeSinceLastQuake = 0f;
			StartCoroutine(Shake(1.0f, 3.0f));
		}
	}

	IEnumerator Shake(float magnitude, float duration) {

		float elapsed = 0.0f;
		float scale = 10.0f; // Plus ou moins sacadé.

		Vector3 originalCamPos = Camera.main.transform.position;
		Vector3 originalPos = this.transform.position;

		Debug.Log ("Séisme !!!");

		while (elapsed < duration) {
			elapsed += Time.deltaTime;          

			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Mathf.PerlinNoise(Time.time * scale, 0.0f) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0.0f, Time.time * scale) * 2.0f - 1.0f;
            float z = Mathf.PerlinNoise(0.0f, Time.time * scale) * 2.0f - 1.0f;
			x *= magnitude * damper;
            y *= magnitude * damper * 0.5f;
            z *= magnitude * damper;

			this.transform.position = new Vector3 (originalPos.x + x, originalPos.y + y, originalPos.z + z);
			//Camera.main.transform.position = new Vector3 (originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z + z);

			yield return null;
		}

		Camera.main.transform.position = originalCamPos;
		transform.position = originalPos;
     }
}