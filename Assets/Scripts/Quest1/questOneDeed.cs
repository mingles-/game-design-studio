using UnityEngine;
using System.Collections;

public class questOneDeed : MonoBehaviour {

	public QuestOneController controller;
	bool enter;

	void Start () {
		
	}

	void Update () {

		if(Input.GetMouseButtonDown(0) && enter){
			controller.hasDeed = true;
			gameObject.SetActive(false);
		}

	}

	void OnGUI(){
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Pick up Residency Deed.");
		}
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
