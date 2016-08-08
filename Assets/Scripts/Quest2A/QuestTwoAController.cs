using UnityEngine;
using System.Collections;

public class QuestTwoAController : MonoBehaviour {

	public QuestController controller;
	public QuestTwoAGuardMisc solderReport;
	public QuestTwoAGuardMisc guardA;
	public QuestTwoAGuardMisc guardB;
	public QuestTwoADeadBody deadBody;
	public MinglesController mingles;
	public BlackSmithController blackSmith;

	public QuestTwoADagger dagger;

	public bool hasDagger;
	public bool questStarted;
	double state;

	// Use this for initialization
	void Start () {
		hasDagger = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		state = controller.getAState();

		if (state == 0.0) {

			mingles.newText = "Go away.";
			solderReport.newText = "There's been a murder! Report to me if you find anything.";
			guardA.newText = "Talk to the commander if you want to help.";
			guardB.newText = "Talk to the commander if want to help.";
			blackSmith.newText = "Have a look at my Stock.";


			if (solderReport.spoken) {
				Debug.Log (solderReport.spoken);
				solderReport.spoken = false;
				controller.setAState (0.1);
			}
			
		} else if (state == 0.1) {
			questStarted = true;

			solderReport.newText = "Report back to me if you find anything.";
			guardA.newText = "Scour the area for evidence!";
			guardB.newText = "A murder weapon must be nearby!";

			if (hasDagger) {
				controller.setAState (0.2);
			}

		
		} else if (state == 0.2) {

			solderReport.newText = "A dagger! Find where it was bought!";
			guardA.newText = "Was it made by the city smithy?";
			guardB.newText = "A Clue! Follow the lead! Tell the Commander!";

			blackSmith.newText = "That's one of mine! Was bought by someone from opposite the barracks!";

			if (blackSmith.spoken) {

				mingles.newText = "Dagger eh? I'll give you 1000 gold if you don't tell the guards. Think about it.";
				solderReport.newText = "Have a look opposite the barracks and check back immediately!";
				guardA.newText = "Don't let anyone bribe you!";
				guardB.newText = "Have a quick look and be back here as soon as you can!";
				blackSmith.newText = "Did you check in the house opposite the barracks?";

				mingles.spoken = false;
				blackSmith.spoken = false;
				blackSmith.spoken = false;
				solderReport.spoken = false;
				controller.setAState (0.3);
			}


		} else if (state == 0.3) {
			
			if (mingles.spoken) {
				mingles.spoken = false;
				controller.setAState (0.4);
			}

		} else if (state == 0.4) {

			mingles.newText = "Here you go. Good choice";
			solderReport.newText = "Thanks for reporting back! Here is a 100 gold reward!";
			guardA.newText = "Where did the clue lead? Tell the commander!";
			guardB.newText = "Tell the commander any new information!";

			if (mingles.spoken) {
				mingles.spoken = false;
				controller.setAState (0.6);
			}
			if (solderReport.spoken) {
				solderReport.spoken = false;
				controller.setAState (0.5);
			}

		} else if (state == 0.5) {

			mingles.newText = "You made a mistake my friend.";
			solderReport.newText = "Thanks for helping us out!";
			// finish on good ending
			controller.addGold(100);
			controller.endingTwoAGood = true;
			controller.setAState (0.7);

		} else if (state == 0.6) {

			// finish on bad ending
			mingles.newText = "Good choice indeed my friend";
			solderReport.newText = "You lost the dagger?! Typical Foolshness!";
			controller.addGold(1000);
			controller.endingTwoAGood = false;
			controller.setAState (0.7);

		} else if (state == 0.7) {
			
			controller.questTwoAFinished = true;
		
		}
	}
}
