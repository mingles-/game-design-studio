using UnityEngine;
using System.Collections;

public class PersonTalkOnce : MonoBehaviour {

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

	}

	void OnGUI(){
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 60), "Talk to " + characterName);
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