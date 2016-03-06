using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Shows a text at the start of the game

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

		if (color.a < 0f)
			Destroy (gameObject);

	}
}