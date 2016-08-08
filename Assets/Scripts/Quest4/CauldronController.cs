using UnityEngine;
using System.Collections;

public class CauldronController : MonoBehaviour {

	public QuestController controller;
	bool enter;
	bool open;

	public GameObject goodEnding;
	public GameObject badEnding;
	public GameObject desertedEnding;

	public GameObject uniqueNPC;
	public GameObject nonUniqueNPC;

	void Start () {
		goodEnding.SetActive (false);
		badEnding.SetActive (false);
		desertedEnding.SetActive (false);
	}

	void Update () {

		if(Input.GetMouseButtonDown(0) && enter){
			open = true;
		}


		if (open && controller.questFourFinished) {

			if (!controller.inEnding) {
				//load new scene

				if (controller.questFourFinished) {
					if (controller.endingThreeGood) {
						// load good ending
						Debug.Log("good ending");
						uniqueNPC.SetActive (false);
						goodEnding.SetActive (true);
						controller.inEnding = true;

					} else {
						if (controller.endingTwoAGood || controller.endingTwoBGood) {
							// load deserted ending
							Debug.Log("deserted ending");

							uniqueNPC.SetActive (false);
							nonUniqueNPC.SetActive (false);

							desertedEnding.SetActive (true);
							controller.inEnding = true;
						} else {
							// load bad ending
							Debug.Log("bad ending");

							uniqueNPC.SetActive (false);
							nonUniqueNPC.SetActive (false);

							badEnding.SetActive (true);
							controller.inEnding = true;


						}
					}
				}
			} else {
				Debug.Log("comeBack");

				goodEnding.SetActive (false);
				badEnding.SetActive (false);
				desertedEnding.SetActive (false);

				uniqueNPC.SetActive (true);
				nonUniqueNPC.SetActive (true);

				controller.inEnding = false;

			}

			open = false;
		}

	}

	void OnGUI(){
		if (controller.questFourFinished && enter && !controller.inEnding) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Look into your future...");
		} else if (controller.questFourFinished && enter && controller.inEnding) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 60), "Come back to the present...");
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