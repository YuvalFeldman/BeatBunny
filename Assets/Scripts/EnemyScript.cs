using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the behaviour of an enemy.
/// </summary>
public class EnemyScript : MonoBehaviour 
{
	#region Functions

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D collider)
	{
		// Check the collision was with a player
		if (collider.gameObject.layer == Layers.PlayerLayer) 
		{
			var playerHealth = collider.gameObject.GetComponent<HealthScript>();
			if (playerHealth != null) 
			{
				// Damage the player
				playerHealth.Damage(1);
			}
		}
	}

	#endregion
}
