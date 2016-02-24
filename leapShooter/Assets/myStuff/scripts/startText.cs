using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startText : MonoBehaviour {

	private Text text;

	void Start() {

		text = GetComponent<Text> ();
	}

	void OnGUI() {

		text.text = "Destroy all incoming tanks";
		Color color = text.color;
		text.fontSize = 35;
		color.a -= 0.005f;
		text.color = color;
		GUI.backgroundColor = Color.clear;

	}
}