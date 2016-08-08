using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class questOneSam : MonoBehaviour {

	public QuestController controller;
	public CharacterTextController textController;
	public string characterName;
	public bool enter;
	public string newText;	
	public bool spoken;

	void Start () {
		enter = false;	
	}

	void Update () {

		textController.enter = enter;
		spoken = textController.spoken;


		if (enter) {
			if (controller.questOneFinished) {
				newText = "Hope you are enjoying your stay!";
			}
			textController.newText = characterName + ": \n" + newText;
		}
	
	}
	void OnGUI(){
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Talk to " + characterName);
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
