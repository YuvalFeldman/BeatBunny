using UnityEngine;
using System.Collections;
using UnityEngine.Events;

/// <summary>
/// Handle hitpoints and damage.
/// </summary>
public class HealthScript : MonoBehaviour 
{

    [System.Serializable]
    public class PlayerDiedEvent : UnityEvent { }
    public PlayerDiedEvent onPlayerDied;

	#region Designer Variables

	/// <summary>
	/// Total hitpoints.
	/// </summary>
	public int hp = 1;

    public bool died;

	#endregion

	#region Functions

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		// Is this a hit?
		/*WeaponScript weapon = collider.gameObject.GetComponent<WeaponScript>();
		if (weapon != null) 
		{
			Damage(weapon.damage);
		}*/
	}

	private void Die()
	{
        died = true;
        GetComponent<Animator>().SetBool("dead", true);
        GetComponent<PlayerScript>().speed = new Vector2(0, 0);
        GetComponent<PlayerScript>().direction = new Vector2(0, 0);
        Invoke("PlayerDiedEventMethod", 1.2f);
        
	}

    private void PlayerDiedEventMethod() {
        onPlayerDied.Invoke();
    }

	#endregion

	#region Public Functions

	/// <summary>
	/// Inflict damage and check if the object should be destroyed.
	/// </summary>
	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if(hp <= 0) 
		{
            if (!died) {
                Die();
            }
		}
	}

	#endregion
}
