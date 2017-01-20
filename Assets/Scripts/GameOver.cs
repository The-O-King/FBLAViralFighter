using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public InstantGuiTextArea score;

	// Update is called once per frame
	void Start () 
	{
		Time.timeScale = 0;
		GetComponentInChildren<InstantGuiTextArea>().rawText = "You Destroyed " + score.GetComponent<Score>().score + " Viruses! \n Press the button to return to the Main Menu";
	}
}