using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    private bool collected;

    void OnTriggerEnter2D(Collider2D other) {
        if (!collected) {
            collected = true;
            LevelManager.manager.score++;
            GetComponent<Animator>().SetBool("destroy", true);
        }
    }
}
