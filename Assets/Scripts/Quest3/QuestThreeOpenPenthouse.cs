using UnityEngine;
using System.Collections;

public class QuestThreeOpenPenthouse : MonoBehaviour {
	
	bool enter;
	bool open;
	public GameObject player;
	public GameObject sound;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (open) {
			player.transform.position = new Vector3(0, 5, -44);
			open = false;
		}
		
		if(Input.GetMouseButtonDown(0) && enter){
			open = !open;
			sound.gameObject.SetActive (true);
		}
	
	}

	void OnGUI(){
		if (enter && open) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Close Door");
		} else if (enter && !open) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Open Door");
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