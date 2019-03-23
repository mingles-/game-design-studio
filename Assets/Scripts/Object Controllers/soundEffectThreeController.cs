using UnityEngine;
using System.Collections;

public class soundEffectThreeController : MonoBehaviour {

	public GameObject audio1;
	public GameObject audio2;
	public GameObject audio3;
	GameObject[] audioSources;
	GameObject soundEffect;

	// Use this for initialization
	void Start () {
		audioSources = new GameObject[] {audio1, audio2, audio3};
		audio1.SetActive(false);
		audio2.SetActive(false);
		audio3.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

		int i = Random.Range (0, 3);
		soundEffect = audioSources [i];

	}

	void OnTriggerEnter (Collider other ){
		if (other.gameObject.tag == "Player") {
			soundEffect.SetActive(true);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			soundEffect.SetActive(false);
		}
	}


}
