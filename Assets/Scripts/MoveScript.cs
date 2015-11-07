using UnityEngine;
using System.Collections;

/// <summary>
/// Moves the current game object.
/// </summary>
public class MoveScript : MonoBehaviour 
{
	#region Designer Variables

	/// <summary>
	/// Object speed.
	/// </summary>
	public Vector2 speed = new Vector2(1, 1);

	/// <summary>
	/// The moving direction.
	/// </summary>
	public Vector2 direction = new Vector2(1, 0);

	private Vector2 movement;

	#endregion

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Calculate the movement in each frame
		// TODO: guess this should be according to the music
		movement = new Vector2(
			speed.x * direction.x, 
			speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		gameObject.GetComponent<Rigidbody2D>().velocity = movement;
	}
}
