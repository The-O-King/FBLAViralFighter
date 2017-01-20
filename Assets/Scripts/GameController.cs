using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool paused = false;
	public GameObject[] menues;
	public GameObject pauseMenu;
	public GameObject gameOver;
	public GameObject winnerWindow;

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P)) 
		{
			if(!paused)
			{
				Time.timeScale=0;
				paused = true;
				pauseMenu.SetActive(true);
			}
			else
			{
				Time.timeScale=1;
				paused=false;
				foreach (GameObject p in menues)
					p.SetActive (false);
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();

		if (GameObject.Find("Player") == null)
			gameOver.SetActive (true);
	}

	public void winner()
	{
		Time.timeScale = 0;
		winnerWindow.SetActive(true);
	}
}