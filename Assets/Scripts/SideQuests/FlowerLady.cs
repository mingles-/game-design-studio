using UnityEngine;
using System.Collections;

public class FlowerLady : MonoBehaviour {

	public QuestController controller;
	public QuestTwoAGuardMisc flowerLady;

	double state;

	// Use this for initialization
	void Start () {
		state = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
			flowerLady.newText = "Bring me 10 flowers for a reward!";

			if (flowerLady.spoken) {
				flowerLady.spoken = false;
				state = 0.1;
			}

		} else if (state == 0.1) {
			
			if (controller.flowerCount >= 10) {
				state = 0.2;
				flowerLady.spoken = false;
			}
		} else if (state == 0.2) {
			flowerLady.newText = "Thank you for these flowers! Here is 500 gold!";

			if (flowerLady.spoken) {
				controller.addGold (500);
				state = 0.3;
			}
		} else if (state == 0.3) {
		
			flowerLady.newText = "Thank you for these flowers!";
		}
	}
}
