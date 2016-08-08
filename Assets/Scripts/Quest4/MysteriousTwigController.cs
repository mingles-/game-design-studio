using UnityEngine;
using System.Collections;

public class MysteriousTwigController : MonoBehaviour {

	public QuestController controller;
	bool enter;

	void Start () {

	}

	void Update () {

		if(Input.GetMouseButtonDown(0) && enter){
			controller.hasTwig = true;
			gameObject.SetActive(false);
		}

	}

	void OnGUI(){
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Pick up Mysterious Twig");
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