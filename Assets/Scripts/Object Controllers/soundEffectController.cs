using UnityEngine;
using System.Collections;

public class soundEffectController : MonoBehaviour {

	public GameObject audio;
	bool enter;

	// Use this for initialization
	void Start () {
		audio.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other ){
		if (other.gameObject.tag == "Player") {
			audio.SetActive(true);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			enter = false;
			audio.SetActive(false);
		}
	}


}
