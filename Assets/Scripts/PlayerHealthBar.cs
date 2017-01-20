using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int health = GetComponentInParent<Movement> ().getHealth();
		transform.localScale = new Vector3 (1,(float)health/20.0f, 1f);
	}
}
