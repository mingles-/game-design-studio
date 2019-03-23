using UnityEngine;
using System.Collections;

public class QuestFourController : MonoBehaviour {

	public QuestController controller;
	public QuestTwoAGuardMisc witch;
	public double state;
	public CauldronController cauldron;

	// Use this for initialization
	void Start () {
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (state == 0) {
			witch.newText = "Tee hee, bring me a mysterious twig and I'll make a potion to see your future!";
			if (controller.hasTwig) {
				state = 0.1;
				witch.spoken = false;
			}
		} else if (state == 0.1) {
			witch.newText = "Give me that twig! Look into my Cauldron to see your future!";

			if (witch.spoken) {
				state = 0.2;
				witch.spoken = false;
			}
		
		} else if (state == 0.2) {
			controller.questFourFinished = true;
		}


	
	}
}
