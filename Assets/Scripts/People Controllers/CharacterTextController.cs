using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterTextController : MonoBehaviour {
	public Text textLabel;
	public string newText;
	public bool enter;
	public bool spoken;

	// Use this for initialization
	void Start () {
		textLabel.text = "";
		enter = false;
		spoken = false;
	}

	// Update is called once per frame
	void Update () {

		if (enter && Input.GetMouseButtonDown (0) && textLabel.text == "") {
			textLabel.text = newText;
			spoken = true;
		} else if ((!enter && textLabel.text != "")) {
			textLabel.text = "";
		} else if (enter && textLabel.text != "" && Input.GetMouseButtonDown (0)) {
			textLabel.text = "";
			spoken = false;
		} else {
			spoken = false;
		}
			

	}
}
