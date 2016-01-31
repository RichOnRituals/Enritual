using UnityEngine;
using System.Collections;

public class AnimateSprite : MonoBehaviour {

	public int wait = 0;
	public int currentNum = 0;
	public Sprite[] sprites;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (wait <= 0) {
			wait = 100;
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [currentNum];
			currentNum++;
			if (currentNum >= sprites.Length) {
				currentNum = 0;
			}
		} else {
			wait--;
		}
	}
}
