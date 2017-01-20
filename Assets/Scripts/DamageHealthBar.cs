using UnityEngine;
using System.Collections;

public class DamageHealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int health = GetComponentInParent<Enemy> ().getHealth();
		transform.localScale = new Vector3 (.3f*(float)health/100.0f, .025f, 1f);
	}
}
