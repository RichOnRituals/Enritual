using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void MainMenuPress() {
		Debug.Log ("The main menu script was called.");
		Application.LoadLevel(0);
		Debug.Log("The first level in the build should be called.");
	}
	
	public void PlayPress() {
		Application.LoadLevel (1);
	}

	public void CreditsPress() {
		Application.LoadLevel (2);
	}

	public void ExitPress() {
		Application.Quit ();
	}

}