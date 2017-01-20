using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour {
	
	
	public GameObject Shot1;
	public GameObject Shot0;
	public int speed;
	public int jumpHeight;
	public int health;
	public int score;
	public bool isGrounded;
	public GameObject FireBall;
	public int fireVelocity;
	private Animator playerAnim;
	public bool facingRight = true;
	
	public AudioClip key1;
	public AudioClip key2;
	public AudioClip key3;
	public AudioClip key4;
	public AudioClip key5;
	public AudioClip key6;


	void FixedUpdate ()
	{
		movement();
		jumping();
		grounded();
		directionFacing();
		shootProjectile();
	}
	
	void movement() 
	{
		playerAnim = GetComponent<Animator> ();
		if(isGrounded)
		{
			if (Input.GetButton("Horizontal"))
			{
				rigidbody2D.velocity =  Vector2.right * Input.GetAxisRaw ("Horizontal") * speed;
				playerAnim.SetFloat ("walking", 1);
			}
			else
			{
				rigidbody2D.velocity = Vector2.zero;
				playerAnim.SetFloat ("walking", 0);
			}
		}
		else
		{
			rigidbody2D.velocity = new Vector3(Input.GetAxisRaw ("Horizontal") * (speed), rigidbody2D.velocity.y);
		}
	}

	void jumping() 
	{
		playerAnim = GetComponent<Animator> ();
		if (isGrounded && Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0) 
		{
			rigidbody2D.AddForce(Vector2.up * jumpHeight + rigidbody2D.velocity.normalized);
			playerAnim.SetFloat ("jumping", 1);
		}
	}

	void grounded()
	{
		isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 5.2f), 1.0f, 1 << 8);
		if (isGrounded == true) 
		{
			playerAnim.SetFloat ("jumping", 0);
		}
	}
	
	void directionFacing()
	{
		if (Input.GetAxisRaw ("Horizontal") < 0)
		{
			transform.localScale = new Vector3(-.75f, .75f, 1);
			facingRight = false;
		}
		else if (Input.GetAxisRaw ("Horizontal") > 0)
		{
			transform.localScale = new Vector3(.75f, .75f, 1);
			facingRight = true;
		}
	}

	public void doDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public int getHealth()
	{
		return health;
	}
	public void shootProjectile()
	{

		if (Input.GetKey (KeyCode.T)) {
						playerAnim.SetFloat ("shooting", 1);
						int projectileSound = Random.Range (1, 7);
						switch (projectileSound) {
						case 1:
								audio.clip = key1;
								break;
						case 2:
								audio.clip = key2;
								break;
						case 3:
								audio.clip = key3;
								break;
						case 4:
								audio.clip = key4;
								break;
						case 5:
								audio.clip = key5;
								break;
						case 6:
								audio.clip = key6;
								break;
						}
						audio.Play ();
						int projectile = Random.Range (1, 3); // creates a number between 1 and 2
						GameObject fire;
						if (facingRight) {
								if (projectile == 1)
										fire = Instantiate (Shot1, transform.position + new Vector3 (1.3f, 1.7f, 0), Quaternion.Euler (new Vector3 (0, 0, 0f))) as GameObject;
								else
										fire = Instantiate (Shot0, transform.position + new Vector3 (1.3f, 1.7f, 0), Quaternion.Euler (new Vector3 (0, 0, 0f))) as GameObject;
				
								fire.rigidbody2D.velocity = Vector2.right * fireVelocity;
						} else {
								if (projectile == 1)
										fire = Instantiate (Shot1, transform.position + new Vector3 (-1.3f, 1.7f, 0), Quaternion.Euler (new Vector3 (0, 0, 0f))) as GameObject;
								else
										fire = Instantiate (Shot0, transform.position + new Vector3 (-1.3f, 1.7f, 0), Quaternion.Euler (new Vector3 (0, 0, 0f))) as GameObject;
				
								fire.rigidbody2D.velocity = Vector2.right * fireVelocity * -1;
						}
				} else
						playerAnim.SetFloat ("shooting", 0);
	}
}