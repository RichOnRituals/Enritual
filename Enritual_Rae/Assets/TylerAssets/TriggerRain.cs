using UnityEngine;
using System.Collections;

public class TriggerRain : MonoBehaviour, ITriggerable {
	/*
	 * This is a trigger.  You can make a trigger by adding ITriggerable (like above) and TriggerEvent().
	 * The TriggerEvent function just needs to do whatever happens when this trigger is fired.
	 * Then, just add this script to a component and drag that component into a VillageCode's TriggerableItem slot.
	 * When all the village's ICompletionTriggers have become true, it will fire this event.
	 *
	*/

	private ParticleSystem rain;
	private ParticleSystem.EmissionModule emission;

	// get the particle system we want to trigger
	void Start() {
		rain = gameObject.GetComponent<ParticleSystem> ();
		emission = rain.emission;
		emission.enabled = false;
	}

	// when fired, make something cool happen!
	public void TriggerEvent() {
		emission.enabled = true;
	}
}
