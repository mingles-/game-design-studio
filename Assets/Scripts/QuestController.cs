using UnityEngine;
using System.Collections;

public class QuestController : MonoBehaviour {

	public int gold;
	public double state;
	public double aState;
	public double bState;

	public bool questOneFinished;
	public bool questTwoAFinished;
	public bool questTwoBFinished;
	public bool questThreeStarted;
	public bool questThreeFinished;
	public bool questFourFinished;

	public bool endingOneGood;
	public bool endingTwoAGood;
	public bool endingTwoBGood;
	public bool endingThreeGood;

	public bool inEnding;

	public bool hasCastle;
	public bool hasTwig;
	public bool hasStatue;

	public int flowerCount;
	public soundEffectThreeInteract goldNoises;

	void Start () {
		setState (0);
		this.questOneFinished = false;
		this.questTwoAFinished = false;
		this.questTwoBFinished = false;
		this.questThreeStarted = false;
		this.questThreeFinished = false;
		this.hasCastle = false;
		this.hasTwig = false;

		goldNoises.gameObject.SetActive (false);
	}



	void Update () {
		if (this.questOneFinished && this.questTwoAFinished && this.questTwoBFinished && !this.questThreeStarted) {
			setState (2.0);
		} 


	}

	void OnGUI(){
		//GUI.Label (new Rect (Screen.width - 100, Screen.height - 70, 150, 30), "Gold: " + this.gold);
		GUI.Label (new Rect (Screen.width - 100, 10, 150, 30), "Gold: " + this.gold);
	
	}


	public void addGold(int newGold) {
		gold += newGold;
		goldNoises.gameObject.SetActive (true);

	}

	public int getGold() {
		return this.gold;
	}

	public void removeGold(int goldAmount) {
		this.gold = this.gold - goldAmount;
		goldNoises.gameObject.SetActive (true);
	}

	public void setState(double newState) {
		this.state = newState;
	}

	public void setAState(double newState) {
		this.aState = newState;
	}

	public void setBState(double newState) {
		this.bState = newState;
	}

	public double getState() {
		return this.state;
	}

	public double getAState() {
		return this.aState;
	}

	public double getBState() {
		return this.bState;
	}

}
