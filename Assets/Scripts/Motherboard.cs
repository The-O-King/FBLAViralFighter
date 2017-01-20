using UnityEngine;
using System.Collections;

public class Motherboard : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionInfo)
	{
		if (collisionInfo.gameObject.name.Equals ("Player"))
			GameObject.Find ("Game Controller").GetComponent<GameController>().winner();
	}
}
