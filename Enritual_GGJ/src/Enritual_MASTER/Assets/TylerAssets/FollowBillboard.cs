using UnityEngine;
using System.Collections;

public class FollowBillboard : MonoBehaviour {

	public GameObject myCamera;

	void Start() {
		if (myCamera == null) {
			myCamera = GameObject.FindWithTag ("Player");
		}
	}

	void Update()
	{
		transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.forward,
			myCamera.transform.rotation * Vector3.up);
	}
}