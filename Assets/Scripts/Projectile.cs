using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	int bounce = 0;

	void Update()
	{
		if (bounce > 2)
			Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.gameObject.tag.Equals ("Enemy"))
		{
			collisionInfo.gameObject.GetComponent<Enemy>().doDamage(10);
			Destroy(gameObject);
		}
		bounce++;
	}
}