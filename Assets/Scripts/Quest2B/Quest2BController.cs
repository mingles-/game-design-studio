using UnityEngine;
using System.Collections;

public class Quest2BController : MonoBehaviour {

	public QuestController controller;

	public GeneralController general;
	public QuestTwoBThug gardenThug;
	public QuestTwoBThug jailedThug;
	public QuestTwoBThug bankThug;
	public QuestTwoBThug coyle;
	public QuestTwoBBankDoor bankDoor;

	public bool questStarted;
	bool openedDoor;
	bool generalTold;

	public string ending;

	double state;

	// Use this for initialization
	void Start () {
		questStarted = false;
		generalTold = false;
		openedDoor = false;
	}

	public double getState() {
		return this.state;
	}

	// Update is called once per frame
	void Update () {

		state = controller.getBState();

		// override for good ending
		if (state >= 0.1 && generalTold && !controller.questTwoBFinished) {
			controller.addGold (50);
			controller.setBState (1.0);
		}


		if (state == 0.0) {

			jailedThug.newText = "Hey you! I've got a job for you. Talk to me if you're interested!";
			gardenThug.newText = "Go Way. I'm busy...";
			bankThug.newText = "Go Way. I'm busy...";
			coyle.newText = "Hi, I'm afraid you don't have a bank account with us."; 
			general.newText = "Some group keeps robbing the bank. Let me know if you hear anything!";

			if (jailedThug.spoken) {
				jailedThug.spoken = false;
				controller.setBState (0.1);
			}

		} else if (state == 0.1) {

			jailedThug.newText = "Meet my associate in the garden. Don't tell the general upstairs!!";


			if (jailedThug.spoken) {
				gardenThug.spoken = false;
				controller.setBState (0.2);
			}

		} else if (state == 0.2) {
			
			gardenThug.newText = "Took your time! Here's the key. Meet with my associate in the bank...";
			general.newText = "A bank robery? I'll send the guards immediately! Here's 100 gold.";

			if (gardenThug.spoken) {
				gardenThug.spoken = false;
				controller.setBState (0.3);
			}
				
			if (general.spoken) {
				general.spoken = false;
				generalTold = true;
			}
			
		} else if (state == 0.3) {

			gardenThug.newText = "Hurry and meet with my associate in the bank...";
			bankThug.newText = "Finally. Get that door open and talk to me for payment.";


			if (bankThug.spoken) {
				bankThug.spoken = false;
				controller.setBState (0.4);
			}

			if (general.spoken) {
				general.spoken = false;
				generalTold = true;
			}
			
		} else if (state == 0.4) {

			bankThug.newText = "Hurry up. I hope you haven't told the general.";

			if (bankDoor.open) {
				openedDoor = true;
			}

			if (openedDoor) {
				controller.setBState (0.5);
			}

			if (general.spoken) {
				general.spoken = false;
				generalTold = true;
			}

		} else if (state == 0.5) {

			bankThug.newText = "Nice one! Knew we could trust you. Here's 1000 gold.";
			coyle.newText = "Shame on you, now those thugs can get in!";
			if (bankThug.spoken) {
				bankThug.spoken = false;
				controller.addGold (1000);
				controller.setBState (0.7);
			} 


		} else if (state == 0.6) {

		} else if (state == 0.7) {

			bankThug.newText = "Hehe, now get out of here while I turn this place upside down!";

			controller.questTwoBFinished = true;
			controller.endingTwoBGood = false;

		} else if (state == 1.0) {
			gardenThug.newText = "Go Way. I'm busy...";
			bankThug.newText = "Go Way. I'm busy...";
			controller.questTwoBFinished = true;
			controller.endingTwoBGood = true;
		}
	}

}
