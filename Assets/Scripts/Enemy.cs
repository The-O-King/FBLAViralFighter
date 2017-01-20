using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 100;
	GameObject target ;
	void Start()
	{
		target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!GameObject.Find ("Game Controller").GetComponent<GameController>().paused)
			transform.position = Vector3.Lerp (transform.position, target.GetComponent<Transform>().position, .01f);
	}

	public int getHealth ()
	{
		return health;
	}
	public void doDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy (gameObject);
			GameObject.Find ("Player").GetComponent<Movement>().score += 1;
		}
	}

	public void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag.Equals("Player"))
		    collisionInfo.gameObject.GetComponent<Movement>().doDamage(10);
	}

	public void OnCollisionStay2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag.Equals("Player"))
			InvokeRepeating("damageOther", 1, 100000000000);
	}

	public void damageOther()
	{
		if (target.gameObject.name.Equals ("Player"))
		    target.GetComponent<Movement>().doDamage (1);
	}
}
