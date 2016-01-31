using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerRiver: MonoBehaviour, ITriggerable {
	/*
	 * This is a trigger.  You can make a trigger by adding ITriggerable (like above) and TriggerEvent().
	 * The TriggerEvent function just needs to do whatever happens when this trigger is fired.
	 * Then, just add this script to a component and drag that component into a VillageCode's TriggerableItem slot.
	 * When all the village's ICompletionTriggers have become true, it will fire this event.
	 *
	*/

	public List<GameObject> WaterTiles;
	public int WaterAnimateTime = 100;
	private int waterWait = 0;
	private bool playWater = false;
	private int currentWater = 0;

	// get the particle system we want to trigger
	void Start() {
		waterWait = WaterAnimateTime;
		foreach (GameObject tile in WaterTiles) {
			tile.SetActive (false);
		}
	}

	void Update() {
		if (playWater && currentWater < WaterTiles.Count) {
			if (waterWait <= 0) {
				waterWait = WaterAnimateTime;
				WaterTiles [currentWater].SetActive (true);
				currentWater++;
			} else {
				waterWait--;
			}
		}
	}

	// when fired, make something cool happen!
	public void TriggerEvent() {
		playWater = true;
	}
}

