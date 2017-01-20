using UnityEngine;
using System.Collections;

public class audioPlaying : MonoBehaviour {

	private static audioPlaying instance = null;

	public static audioPlaying Instance 
	{
		get { return instance; }
	}

	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
			return;
		} 
		else 
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
