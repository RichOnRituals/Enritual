using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VillageCode : MonoBehaviour {
	/*
	 * This is the VillageCode.  Add it to a village.  Then, add all the villagers to the ICompletionTriggers list.
	 * Also, add an ITriggerable (e.g. object with TriggerRain script) to the TriggerableItem.  When all the ICompletionTriggers
	 * return "true" for IsComplete, the TriggerableItem will be triggered!
	 */

	public GameObject TriggerableItem;
	private ITriggerable Trigger;
	public List<GameObject> CompletionTriggerItems;
	private List<ICompletionTrigger> CompletionTriggers;
	private int wait = 0;

	// Use this for initialization
	void Start () {
		Trigger = TriggerableItem.GetComponent<ITriggerable> ();
		CompletionTriggers = new List<ICompletionTrigger> (CompletionTriggerItems.Capacity);

		foreach (GameObject completionObject in CompletionTriggerItems) {
			CompletionTriggers.Add(completionObject.GetComponent<ICompletionTrigger> ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (wait <= 0) {
			wait = 20;
			bool succeeded = true;
			foreach (ICompletionTrigger completionTrigger in CompletionTriggers) {
				if (completionTrigger.IsComplete() == false) {
					// incomplete, failed!
					succeeded = false;
				}
			}
			if (succeeded) {
				Trigger.TriggerEvent ();
			}
		} else {
			wait--;
		}
	}
}
