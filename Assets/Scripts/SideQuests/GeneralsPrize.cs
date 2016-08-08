using UnityEngine;
using System.Collections;

public class GeneralsPrize : MonoBehaviour {
	public QuestController controller;

	public Prize prize;
	public QuestTwoBThug thug; 

	double state; 


	// Use this for initialization
	void Start () {
		state = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (state == 0) {
			thug.newText = "Hehe, grab me the general's statue and I'll give you 500 gold!!";

			if (thug.spoken) {
				thug.newText = "Hurry up grab me the general's statue on the barracks third floor!";
				thug.spoken = false;
				state = 0.1;

			}
		
		} else if (state == 0.1) {
			if (controller.hasStatue) {
				state = 0.2;
				thug.spoken = false;
			}
		} else if (state == 0.2) {
			thug.newText = "Pleasure doing business with you. Here is 500 gold!";

			if (thug.spoken) {
				controller.addGold (500);
				state = 0.3;
				thug.newText = "Pleasure doing business with you.";
			}
		}
	
	}
}
