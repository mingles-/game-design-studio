using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour {

	float timeCounter = 0;

	float speed;
	float width;
	float height;


	void Start () {
		speed = 0.1f;
		width = 9f;
		height = width;

	}

	void Update () {

		timeCounter += Time.deltaTime * speed;
		float x = Mathf.Cos (timeCounter) * width;
		float z = Mathf.Sin (timeCounter) * height;
		float y = 0;



		Vector3 vecOld = transform.position;
		Vector3 vecNew =  new Vector3 (x,y,z);
		float dot = Vector3.Dot (vecOld, vecNew);

		dot = dot / (vecOld.magnitude * vecNew.magnitude);

		float acos = Mathf.Acos (dot);

		float angle = acos * 180 / Mathf.PI;

		transform.Rotate (0, -angle, 0);
		transform.position = (new Vector3(x, y, z));
	}
}
