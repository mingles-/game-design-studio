using UnityEngine;
using System.Collections;

public class QuestThreeController : MonoBehaviour {
	public QuestController controller;
	public GeneralController2 general; // general before castle which gives you access to the castle if you've saved the princess
	public GeneralController general2;
	public QuestTwoAGuardMisc princess; // princess 
	public QuestTwoAGuardMisc guard;  // guard arresting mingles
	public MinglesController mingles1; // normal one that's always there
	public QuestTwoBThug mingles2; // back of guild - gives offer
	public QuestTwoBThug mingles3; // arrested one
	public QuestTwoAGuardMisc castleSeller;


	public QuestThreeButton button1;
	public QuestThreeButton button2;
	public QuestThreeDoor door;

	public QuestThreeCastleDoors castleDoor;

	double state;
	bool questStarted;

	// Use this for initialization
	void Start () {
		general.gameObject.SetActive (false);
		mingles3.gameObject.SetActive (false);
		guard.gameObject.SetActive (false);
		button2.gameObject.SetActive (false);
		questStarted = false;


	}
	
	// Update is called once per frame
	void Update () {
		state = controller.getState();
		castleSeller.newText = "Sorry you can't afford the penthouse. It's 5000 gold.";

		if (state == 2.0) {
			general.gameObject.SetActive (true);
			controller.questThreeStarted = true;

			general.newText = "Stranger help! The princess has been kidnapped by the Thieves Guild!";

			if (general.spoken) {
				general.spoken = false;
				controller.setState (2.1);
			}
		} else if (state == 2.1) {
			general2.gameObject.SetActive (false);
			general.newText = "Quick! To the Thieves Guild opposite the barracks!";
			questStarted = true;
			mingles1.gameObject.SetActive (false);
			button1.gameObject.SetActive (false);
			button2.gameObject.SetActive (true);

			if (button2.enter && Input.GetMouseButtonDown (0)) {
				controller.setState (2.2);
			}

		} else if (state == 2.2) {
			button1.gameObject.SetActive (true);
			button2.gameObject.SetActive (false);
			mingles2.newText = "You found me. I'll give you 5000 gold to walk away?";

			if (mingles2.spoken) {
				controller.setState (2.3);
				mingles2.spoken = false;
			}

		} else if (state == 2.3) {
			mingles2.newText = "Good choice my friend.";

			if (mingles2.spoken) {
				controller.setState (2.9);
				controller.addGold (5000);
				mingles2.spoken = false;
			}

			if (door.open) {
				controller.state = 2.5;
				mingles2.gameObject.SetActive (false);
			}

		} else if (state == 2.9) {
			controller.endingThreeGood = false;
			general.gameObject.SetActive (false);
			general2.gameObject.SetActive (true);
			general2.newText = "We failed her. What will become of the city?";

			controller.setState (2.95);
		
		} else if (state == 2.5) {
			princess.newText = "You are my saviour! Quick! Chase after the leader!";

			if (princess.spoken) {
				castleSeller.gameObject.SetActive (false);
				controller.setState (2.6);
				princess.spoken = false;
			}

		} else if (state == 2.6) {
			mingles3.gameObject.SetActive (true);
			guard.gameObject.SetActive (true);
			mingles3.newText = "Urgh! You'll pay for this!!";
			guard.newText = "Quick! Inform the general!";

			if (guard.spoken) {
				controller.setState (2.7);
				door.open = false;
				castleSeller.gameObject.SetActive (false);
			}

		} else if (state == 2.7) {
			general.newText = "I'll take it from here. Take the castle penthouse as thanks!";

			if (general.spoken) {
				controller.setState (2.8);
				controller.hasCastle = true;
				door.open = false;
			}

		} else if (state == 2.8) {
			general.newText = "Go up to the castle penthouse!";

			if (castleDoor.open) {
				controller.hasCastle = true;

				general.gameObject.SetActive (false);
				general2.gameObject.SetActive (true);
				general2.newText = "We did it! You are a hero of Castletown!";
				controller.setState (3.0);
			}


		} else if (state == 3.0) {
			controller.endingThreeGood = true;
			controller.questThreeFinished = true;

			princess.gameObject.SetActive (false);
			guard.gameObject.SetActive (false);
			mingles3.gameObject.SetActive (false);

		} else if (state >= 2.95 && !controller.hasCastle) {
			// buy castle
			if (controller.gold >= 5000) {
				castleSeller.newText = "Do you wish to buy the castle for 5000 gold?";
			
				if (castleSeller.spoken) {
					controller.hasCastle = true;
					castleSeller.spoken = false;
					controller.setState (3.1);
				}

			} // check this
		} else if (state == 3.1) {
			castleSeller.newText = "Thank you! Enjoy the penthouse!";
			if (castleSeller.spoken) {
				controller.removeGold (5000);
				controller.setState (3.2);
			}



		} else if (state == 3.2) {
			if (castleDoor.open) {
				castleSeller.gameObject.SetActive (false);
			}
		}


			

	
	}
}
