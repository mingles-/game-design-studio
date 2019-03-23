using UnityEngine;
using System.Collections;

public class QuestOneController : MonoBehaviour {

	public QuestController controller;
	public questOneSam Sam;
	public questOneDeed deed;
	double state;
	bool goldRemoved;
	public bool hasDeed;
	// Use this for initialization
	void Start () {
		goldRemoved = false;
		hasDeed = false;
	}
	
	// Update is called once per frame
	void Update () {

		state = controller.getState();

		if (state == 0.0) {
			// talk to sam
			Sam.newText = "Hi Stranger. It costs 200 gold for a room.";
			if (Sam.spoken) {
				Sam.spoken = false;
				controller.setState (0.1);
			}
		} else if (state == 0.1) {
			// spoken to Sam
			if (controller.getGold () < 200) {
				
				Sam.newText = "I'm afraid you can't afford a room for 200 gold.";
				Sam.spoken = false;
				 
			} else {

				Sam.newText = "Thanks for staying with us! Here is your key! Go Upstairs, second on the left!";

				if (Sam.spoken) {
					controller.setState (0.2);
				} 
			}



		} else if (state == 0.2) {

			// bought room
			if (!goldRemoved) {
				controller.removeGold (200);
				goldRemoved = true;
			}

			// has residency deed
			if (hasDeed) {
				controller.questOneFinished = true;
				controller.setState (1.0);
			}


		} else {
			controller.questOneFinished = true;
		}

	
	}
}
