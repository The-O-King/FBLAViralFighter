using UnityEngine;
using System.Collections;

public class ButtonSceneLoad : MonoBehaviour {

	public string sceneChange;

	void Update () {
		if (GetComponent<InstantGuiButton>().activated)
			Application.LoadLevel (sceneChange);
	}
}
