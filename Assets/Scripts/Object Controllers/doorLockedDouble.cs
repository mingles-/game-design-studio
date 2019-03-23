using UnityEngine;
using System.Collections;

public class doorLockedDouble : MonoBehaviour {

	public double lockedState = 0;
	public QuestController controller;
	public float smooth = 2;
	public float doorOpenAngleLeft = 90;
	public float doorOpenAngleRight = 90;
	bool enter;
	public bool open;
	public GameObject sound;

	public Transform leftDoor;
	public Transform rightDoor;

	Vector3 defaultRotLeft;
	Vector3 openRotLeft;

	Vector3 defaultRotRight;
	Vector3 openRotRight;

	void Start () {
		defaultRotLeft = leftDoor.eulerAngles;
		openRotLeft = new Vector3 (defaultRotLeft.x, (defaultRotLeft.y + doorOpenAngleLeft) % 360, defaultRotLeft.z);

		defaultRotRight = rightDoor.eulerAngles;
		openRotRight = new Vector3 (defaultRotRight.x, (defaultRotRight.y + doorOpenAngleRight) % 360, defaultRotRight.z);
	}

	void Update () {

		if (controller.getState () >= lockedState) {
			
			if (open) {
				leftDoor.eulerAngles = Vector3.Slerp (leftDoor.eulerAngles, openRotLeft, Time.deltaTime * smooth);
				rightDoor.eulerAngles = Vector3.Slerp (rightDoor.eulerAngles, openRotRight, Time.deltaTime * smooth);

			} else {
				leftDoor.eulerAngles = Vector3.Slerp (leftDoor.eulerAngles, defaultRotLeft, Time.deltaTime * smooth);
				rightDoor.eulerAngles = Vector3.Slerp (rightDoor.eulerAngles, defaultRotRight, Time.deltaTime * smooth);

			}

			if (Input.GetMouseButtonDown (0) && enter) {
				open = !open;
				sound.gameObject.SetActive (true);
			}
		}

	}

	void OnGUI(){
		if (controller.getState () >= lockedState) {
			if (enter && open) {
				GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Close Doors");
			} else if (enter && !open) {
				GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 30), "Open Doors");
			}
		} else {
			if (enter) {
				GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 150, 60), "Garden door is locked. Residency Deed Required");
			}
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
