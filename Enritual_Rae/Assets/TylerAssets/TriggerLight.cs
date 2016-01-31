using UnityEngine;
using System.Collections;

public class TriggerLight : MonoBehaviour, ITriggerable {
	/*
	 * This is a trigger.  You can make a trigger by adding ITriggerable (like above) and TriggerEvent().
	 * The TriggerEvent function just needs to do whatever happens when this trigger is fired.
	 * Then, just add this script to a component and drag that component into a VillageCode's TriggerableItem slot.
	 * When all the village's ICompletionTriggers have become true, it will fire this event.
	 *
	*/

	private Light myLight;

	// Get the component we want to interact with
	void Start () {
		myLight = gameObject.GetComponent<Light> ();
	}

	// when fired, make something cool happen!
	public void TriggerEvent() {
		myLight.enabled = true;
	}
}
