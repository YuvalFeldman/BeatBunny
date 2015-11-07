using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text highscoreCountText;
    public Text scoreCountText;
    public Text diamondCountText;
    public HealthScript playerHealth;

    public RectTransform scoreScreen;
    public RectTransform deathScreen;

	// Use this for initialization
	void Start () {
        playerHealth.onPlayerDied.AddListener(HandlePlayerDied);
	}
	
	// Update is called once per frame
	void Update () {
        diamondCountText.text = LevelManager.manager.score.ToString();
	}

    public void HandlePlayerDied() {
        scoreScreen.gameObject.SetActive(false);

        if (LevelManager.manager.highScore < LevelManager.manager.score) {
            LevelManager.manager.highScore = LevelManager.manager.score;
        }

        highscoreCountText.text = LevelManager.manager.highScore.ToString();
        scoreCountText.text = LevelManager.manager.score.ToString();

        deathScreen.gameObject.SetActive(true);
    }

    public void HandleReplayButtonClicked() {
        LevelManager.manager.Save();
        Application.LoadLevel("First");
    }
}
