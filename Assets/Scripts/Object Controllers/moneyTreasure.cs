using UnityEngine;
using System.Collections;

public class moneyTreasure : MonoBehaviour {

	public int gold;
	public QuestController controller;
	bool enter;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown(0) && enter){
			controller.addGold(this.gold);
			gameObject.SetActive(false);
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

	void OnGUI(){
		if (enter) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Pick Up Gold");
		}
	}
}
