using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

	private int points;
	private Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
		points = 0;
	}
	
	// Update is called once per frame
	void OnGUI() {
	
		text.text = "Tanks destroyed: " + points;

	}

	public void increasePoints() {
		points++;
	}

	public int getPoints() {
		return points;
	}

	public void setScore(int s) {
		points = s;
	}
}
