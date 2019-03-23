using UnityEngine;
using System.Collections;

public class SchoolQuest : MonoBehaviour {
	public QuestController controller;

	public QuestTwoAGuardMisc teacher;

	public QuestTwoAGuardMisc pupil1;
	public QuestTwoAGuardMisc pupil2;

	public GameObject pupil1Class;
	public GameObject pupil2Class;

	double state;

	bool pupil1Found;
	bool pupil2Found;

	// Use this for initialization
	void Start () {
		state = 0;

		pupil1Class.SetActive (false);
		pupil2Class.SetActive (false);

		teacher.newText = "I'm missing two pupils. I'll reward you for finding them!";
		pupil1.newText = "I'm having a great time!"; 
		pupil2.newText = "I'm having a great time!"; 
	}
	
	// Update is called once per frame
	void Update () {

		if (state == 0) {
			if (teacher.spoken) {
				state = 0.1;
				teacher.spoken = false;
				pupil2.spoken = false;
				pupil1.spoken = false;
			}
		} else if (state == 0.1) {
			if (!pupil1Found) {
				pupil1.newText = "Aww, I'll make my way back to class now."; 
				if (pupil1.spoken) {
					state = 0.9;
				}
			}

			if (!pupil2Found) {
				pupil2.newText = "Aww, I'll make my way back to class now."; 
				if (pupil2.spoken) {
					state = 0.95;
				}
			}

			if (pupil1Found && pupil2Found) {
				state = 0.2;
			}

		} else if (state == 0.2) {
			teacher.newText = "Thanks, they just got back. Here's 500 gold.";

			if (teacher.spoken) {
				pupil1Class.SetActive (true);
				pupil2Class.SetActive (true);
				pupil1.gameObject.SetActive (false);
				pupil2.gameObject.SetActive (false);
				controller.addGold (500);
				state = 0.3;


			}

		} else if (state == 0.3) {
			teacher.newText = "Thanks for your help. They're studying hard now!";

		} else if (state == 0.9) {
			
			pupil1Found = true;
			pupil1.newText = "I'm just going!!"; 
			state = 0.1;

		} else if (state == 0.95) {
			
			pupil2Found = true;
			pupil2.newText = "I'm just going!!"; 
			state = 0.1;
		}
	
	}
}
