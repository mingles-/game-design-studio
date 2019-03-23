using UnityEngine;
using System.Collections;

public class Prize : MonoBehaviour {

	public QuestController controller;
	bool enter;

	void Start () {

	}

	void Update () {

		if(Input.GetMouseButtonDown(0) && enter){
			controller.hasStatue = true;
			gameObject.SetActive(false);
		}

	}

	void OnGUI(){
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Steal General's Prize");
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
