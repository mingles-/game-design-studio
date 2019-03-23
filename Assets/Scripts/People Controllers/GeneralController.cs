using UnityEngine;
using System.Collections;

public class GeneralController : MonoBehaviour {

	public QuestController controller;
	public CharacterTextController textController;
	public string characterName;
	public bool enter;
	public string newText;	
	public bool spoken;


	// Use this for initialization
	void Start () {
		enter = false;	
	}

	// Update is called once per frame
	void Update () {
		textController.enter = enter;
		spoken = textController.spoken;


		if (enter) {
			textController.newText = characterName + ": \n" + newText;
		}

		if (controller.getState () == 3.1) {
			gameObject.SetActive (false); 
		} else if (controller.getState () == 4.0 ) {
			gameObject.SetActive(true);
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