using UnityEngine;
using System.Collections;

public class TipsGuard : MonoBehaviour {

	public QuestController controller;
	public CharacterTextController textController;
	public string characterName;
	public bool enter;
	string newText;
	public bool spoken;
	string newTextA;
	string newTextB;
	string newTextC;
	string newTextD;
	string newTextE;



	// Use this for initialization
	void Start () {
		enter = false;
	}

	// Update is called once per frame
	void Update () {
		textController.enter = enter;
		spoken = textController.spoken;

		if (controller.state == 0.0) {
			newText = "Come to me for advice! You should get a room! I hear the Tavern has a few spare!";
		} if (controller.state >= 1.0 && controller.state < 2.0) {
			newTextA = "I hear there has been a murder in the gardens!";
			newTextB = "Rumour has it someone has been jailed in the barracks!";
			newTextC = "Apparently Flower Lady Lady Hazel is looking to buy flowers...";
			newTextD = "Have you heard someone has been sneaking around in the alley beside the barracks?";
			newTextE = "I've seen pupils skipping school. You should talk to the headmaster about it.";

			string[] state1 = {newTextA, newTextB, newTextC, newTextD, newTextE};

			int i = Random.Range(0, state1.Length);

			newText = state1 [i];

		} else if (controller.state >= 2.0) {
			newTextA = "I hear the witch is looking for something that might be in the castle!";
			newTextB = "Have you spoken to the General in front of the castle and saved the princess?!";
			newTextC = "Did you resolve the problem with the Thug outside the barracks?";
			newTextD = "I hope you got Flower Lady Hazel's flowers!";
			newTextE = "Did you talk to the headmaster reguarding his pupils?";

			string[] state1 = {newTextA, newTextB, newTextC, newTextD, newTextE};

			int i = Random.Range(0, state1.Length);

			newText = state1 [i];

		}


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
