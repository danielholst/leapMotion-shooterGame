using UnityEngine;
using System.Collections;

// To quit game when escape is pressed
public class endScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp (KeyCode.Escape)) {
			print ("Quit");
			Application.Quit ();
		}
	}
}
