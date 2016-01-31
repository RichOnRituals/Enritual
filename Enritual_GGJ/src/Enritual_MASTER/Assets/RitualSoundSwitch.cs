using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RitualSoundSwitch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> target_audio;
    [SerializeField]
    private GameObject background_music;

	// Use this for initialization
    void OnTriggerEnter(Collider coll)
    {
        foreach(GameObject sounds in target_audio)
        {
            sounds.SetActive(true);
            background_music.SetActive(false);
        }
        Debug.Log("Player has entered the town");
    }

    void OnTriggerExit(Collider coll)
    {
        foreach (GameObject sounds in target_audio)
        {
            sounds.SetActive(false);
            background_music.SetActive(true);
        }
    }
}
