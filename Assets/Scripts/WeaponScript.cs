using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the behaviour of a weapon.
/// </summary>
public class WeaponScript : MonoBehaviour 
{
	#region Designer Variables

	/// <summary>
	/// The damage inflicted by the weapon.
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Cooldown in seconds between two shots.
	/// </summary>
	public float hittingRate = 0.25f;

	public float range = 100f;                      // The distance the gun can fire.

	#endregion

	#region Private Variables

	private float hitCooldown;

	/// <summary>
	/// A raycast hit to get information about what was hit.
	/// </summary>
	RaycastHit2D hitInformation;                            
    
    #endregion

	#region Properties

	public bool IsAttacking { get; set; }

	public bool CanAttack
	{
		get
		{
			return hitCooldown <= 0f;
		}
	}

	#endregion

	#region Functions
    
    // Use this for initialization
	void Start () 
	{
		hitCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hitCooldown > 0) 
		{
			hitCooldown -= Time.deltaTime;
		}
	}

	void StopAnimation()
	{
		Animator animator = gameObject.GetComponent<Animator>();
		if (animator != null) 
		{
			animator.SetBool("attack", false);
		}
	}

	#endregion

	#region Public Functions

	public void Attack(bool isEnemy)
	{
		if (CanAttack) 
		{
			hitCooldown = hittingRate;

			// Set the animation
			IsAttacking = true;
			Animator animator = gameObject.GetComponent<Animator>();
			if (animator != null) 
			{
				animator.SetBool("attack", true);

				// Stop the animation after a time
				Invoke("StopAnimation", 0.2f);
			}

            if (!GetComponent<HealthScript>().died) {

                hitInformation = Physics2D.Raycast(
                    new Vector2(transform.position.x, transform.position.y),
                    Vector2.right,
                    range);
                if (hitInformation) {
                    // Try and find an EnemyHealth script on the gameobject hit.
                    EnemyHealth enemyHealth = hitInformation.collider.GetComponent<EnemyHealth>();

                    // If the EnemyHealth component exist...
                    if (enemyHealth != null) {
                        // ... the enemy should take damage.
                        enemyHealth.Damage(1);
                    }
                }
            }
        }
    }
    
    #endregion
}
