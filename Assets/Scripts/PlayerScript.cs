using UnityEngine;
using System.Collections;
using UnityEngine.Events;

/// <summary>
/// Moves the current game object.
/// </summary>
public class PlayerScript : MonoBehaviour
{

    private readonly int WOOD_UP_LAYER = 13;

	#region Designer Variables

	/// <summary>
	/// Object speed.
	/// </summary>
	public Vector2 speed = new Vector2 (10, 10);

	/// <summary>
	/// The moving direction.
	/// </summary>
	public Vector2 direction = new Vector2 (1, 0);

	/// <summary>
	/// The jump force.
	/// </summary>
	public float jumpForce = 8.0f;

	/// <summary>
	/// Gravity pulls me down...
	/// </summary>
	public float gravity = 30.0f;

	private Vector2 movement;

	private bool makeJump = false;
	private bool isGrounded = false;

	#endregion

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Check if the player is on the ground
		if (isGrounded) 
		{
			movement = new Vector2 (
				speed.x * direction.x, 
				speed.y * direction.y);
			if (makeJump) 
			{
				movement.y = speed.y * jumpForce;
				makeJump = false;
				isGrounded = false;
			}
		}
		movement.y -= gravity * Time.deltaTime;

	}

	void FixedUpdate ()
	{
		// Apply movement to the rigidbody
		gameObject.GetComponent<Rigidbody2D> ().velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		isGrounded = true;

		// Check collision with an enemy
		if (collision.gameObject.layer == Layers.ObstacleLayer) 
		{
			// Player is damaged
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) {
				playerHealth.Damage(1);
			}
		}
		else if(collision.gameObject.layer == Layers.PlatformsLayer)
		{
			isGrounded = true;
		}
	}

	public void Jump ()
	{
		makeJump = true;
	}

	public void Attack()
	{
		var weapon = gameObject.GetComponent<WeaponScript>();
		if (weapon != null) 
		{
			// False because the player is not the enemy - DAH!
			weapon.Attack(false);
		}
	}
}
