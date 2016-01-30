using UnityEngine;
using System.Collections;

public class MainCharacterScript : MonoBehaviour {

	public GameObject mainSprite;
	public Sprite[] sprites;
	private bool walking = false;
	public int walkAnimationSpeed = 20;
	private bool walkLeft = true;
	private int walkWait = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(Input.GetAxis("Vertical"));
		if (Input.GetAxis ("Horizontal") != 0) {
			UpdateWalking ();
		} else if (Input.GetAxis ("Vertical") != 0) {
			UpdateWalking ();
		} else {
			walking = false;
		}
		if (!walking) {
			if (Input.GetKey ("1")) {//} else if (Input.GetButton ("Fire1")) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [1];
			} else if (Input.GetKey ("2")) {//} else if (Input.GetButton ("Fire2")) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [2];
			} else if (Input.GetKey ("3")) {//} else if (Input.GetButton ("Fire3")) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [3];
			} else if (Input.GetKey ("4")) {//} else if (Input.GetButton ("Jump")) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [4];
			} else if (Input.GetKey ("5")) {//} else if (Input.GetButton ("Jump")) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [5];
			} else if (Input.GetKey ("6")) {//} else if (Input.GetButton ("Jump")) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [6];
			} else {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [0];
			}
		}
	}

	void UpdateWalking() {
		if (!walking) {
			walking = true;
			walkWait = 0;
		}
		if (walkWait <= 0) {
			if (walkLeft) {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [7];
			} else {
				mainSprite.GetComponent<SpriteRenderer> ().sprite = sprites [8];
			}
			walkLeft = !walkLeft;
			walkWait = walkAnimationSpeed;
		} else {
			walkWait--;
		}
	}
}
