using UnityEngine;
using System.Collections;

/// <summary>
/// Handle hitpoints and damage.
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    #region Designer Variables

    /// <summary>
    /// Total hitpoints.
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Enemy or player?
    /// </summary>

    #endregion

    #region Functions

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        // Is this a hit?
        /*WeaponScript weapon = collider.gameObject.GetComponent<WeaponScript>();
        if (weapon != null) 
        {
            Damage(weapon.damage);
        }*/
    }

    private void Die() {
        GetComponent<Collider2D>().enabled = false;
        var animators = GetComponentsInChildren<Animator>();
        foreach (var item in animators) {
            item.SetBool("dead", true);
        }
    }

    #endregion

    #region Public Functions

    /// <summary>
    /// Inflict damage and check if the object should be destroyed.
    /// </summary>
    public void Damage(int damageCount) {
        hp -= damageCount;

        if (hp <= 0) {
            // DIE
                Invoke("Die", 0.30f);
        }
    }

    #endregion
}
