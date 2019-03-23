using UnityEngine;
using System.Collections;

public class ShelvesController : MonoBehaviour {
	
	public QuestController controller;
	// Use this for initialization
	double state;
	public Transform target;
	public float speed;

	Vector3 original;

	void Start () {
		original = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		state = controller.getState();



		if (state == 2.2) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		} 
	
	}
}
