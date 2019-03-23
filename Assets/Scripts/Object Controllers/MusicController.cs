using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {


	public bool enter;
	// Use this for initialization

	public GameObject mainTheme;
	public GameObject newTheme;

	public bool entered; 
	bool lastEntered;

	void Start () {
		//mainTheme.SetActive(true);
		newTheme.SetActive (false);
		entered = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (lastEntered != enter) {

			if (enter && !entered) {
				entered = true;
				Debug.Log ("turn on");
			} else if (enter && entered) {
				entered = false;
				Debug.Log ("turn off");
			} 




			if (entered && !enter) {
				newTheme.SetActive (true);
				mainTheme.SetActive (false);
			} else if (!entered) {
				mainTheme.SetActive (true);
				newTheme.SetActive (false);
			}
		} 
			lastEntered = enter;

	}


	void OnTriggerEnter (Collider other ){
		if (other.gameObject.tag == "Player") {
			enter = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			enter = false;
		}
	}

}
