using UnityEngine;
using System.Collections;

public class soundEffectThreeInteract : MonoBehaviour {

	public GameObject audio1;
	public GameObject audio2;
	public GameObject audio3;
	GameObject[] audioSources;
	GameObject soundEffect;
	public bool done;
	// Use this for initialization
	void Start () {
		done = false;
		soundEffect = audio1;
		audioSources = new GameObject[] {audio1, audio2, audio3};
		audio1.SetActive(false);
		audio2.SetActive(false);
		audio3.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (!done) {
			audio1.SetActive(false);
			audio2.SetActive(false);
			audio3.SetActive(false);

			int i = Random.Range (0, 3);
			soundEffect = audioSources [i];
			soundEffect.SetActive (true);
			done = true;
		} else {
			done = false;
			gameObject.SetActive (false);
		}
	}

}
