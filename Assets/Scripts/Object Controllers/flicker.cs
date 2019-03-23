using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	public Light flickerLight;
	float interval = 0.15f; 
	float nextTime = 0;

	void Start () {
	}

	void Update () {

		// intensity of light is randomly varied every interval time
		if (Time.time >= nextTime) {
			float intensity = Random.Range (2.5F, 3.5F);
			flickerLight.intensity = intensity;
			nextTime += interval; 
		}



	}
}
