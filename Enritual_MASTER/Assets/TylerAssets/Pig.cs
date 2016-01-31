using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pig : MonoBehaviour, ITriggerable {


	public List<Sprite> runSprites;
	public int RunAnimateTime = 20;
	private bool isRunning = false;
	private int currentFrame = 0;
	private int runWait = 0;
	private SpriteRenderer PigSprite;

	// Use this for initialization
	void Start () {
		if(PigSprite == null)
		{
			PigSprite = gameObject.GetComponent<SpriteRenderer>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			if (runWait <= 0) {
				runWait = RunAnimateTime;
				PigSprite.sprite = runSprites[currentFrame];
				currentFrame++;
				if (currentFrame >= runSprites.Count) {
					currentFrame = 0;
				}
			} else {
				runWait--;
			}
		}
	}

	public void TriggerEvent() {
		isRunning = true;
	}
}
