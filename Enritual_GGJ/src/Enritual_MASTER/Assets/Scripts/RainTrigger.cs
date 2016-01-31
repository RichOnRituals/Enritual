using UnityEngine;
using System.Collections;

public class RainTrigger : MonoBehaviour {

	public GameObject rain;

	// Use this for initialization
	void Start () {
		rain = GameObject.Find("RainParticles");
		rain.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {

		rain.SetActive(true);
	}
}
