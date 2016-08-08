using UnityEngine;
using System.Collections;

public class doorOpen : MonoBehaviour {

	public float smooth = 2;
	public float doorOpenAngle = 90;
	public GameObject sound;
	bool enter;
	bool open;

	Vector3 defaultRot;
	Vector3 openRot;

	void Start () {
		defaultRot = transform.eulerAngles;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
	}
	
	void Update () {

		if(open){
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
		}else{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
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
