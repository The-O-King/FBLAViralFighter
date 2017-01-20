using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
		
	public int score;

	// Update is called once per frame
	void Update () {
		score = GameObject.Find ("Player").GetComponent<Movement>().score;
		GetComponent<InstantGuiTextArea>().rawText = "Score: " + score;
	}
}
