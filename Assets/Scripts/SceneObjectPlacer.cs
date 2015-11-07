using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneObjectPlacer : MonoBehaviour {

    public GameObject[] platformPrefabs;
    public GameObject upPlatformPrefab;
    public GameObject downPlatformPrefab;

    public List<Transform> platforms;
    public List<Transform> upPlatforms;
    public List<Transform> downPlatforms;
   
    private List<float> platformWidths;
    private float upPlatformWidth;
    private float downPlatformWidth;
    private int numOfPlatforms = 2;
    private int counterEnd = 6;
    private Transform lastPlacedPlatform;

    private int platformCounter;
    private int placedPlatforms;

    private readonly int WOOD_LAYER = 13;
    private readonly int OBSTACLE_LAYER = 12;
    private readonly int TURTLE_LAYER = 11;
    private readonly int PLATFORM_LAYER = 10;

    private float spawnedPlatformTime;

    public bool isNextPlatformUp;
    public bool isNextPlatformDown;
    private bool lastPlatformWasDown;

    private int upPlatformCount;
    private int downPlatformCount;

	// Use this for initialization
	void Start () {
        initializePlatforms();
	}

    // Update is called once per frame
    void Update() {

    }

    private void initializePlatforms() {

        platforms = new List<Transform>();
        platformWidths = new List<float>();

        upPlatformWidth = (float)upPlatforms[0].GetComponent<SpriteRenderer>().bounds.size.x - 0.05f;
        downPlatformWidth = (float)downPlatforms[0].GetComponent<SpriteRenderer>().bounds.size.x - 0.05f;

        foreach (GameObject platformPrefab in platformPrefabs) {
            for (int i = 0; i < numOfPlatforms; i++) {
                placedPlatforms++;
                GameObject platform = Instantiate(platformPrefab);
                platforms.Add(platform.transform);
                // the -0.05f is a hack because otherwise the sprites have spaces between them
                platformWidths.Add((float)platform.GetComponent<SpriteRenderer>().bounds.size.x - 0.05f);
                if (placedPlatforms < 4) {
                    if (lastPlacedPlatform != null) {
                        platform.transform.position = new Vector2(lastPlacedPlatform.position.x + platformWidths[i], lastPlacedPlatform.position.y);
                        lastPlacedPlatform = platform.transform;
                    }
                    else {
                        platform.transform.position = new Vector2(-4f, -1.5f);
                        lastPlacedPlatform = platform.transform;
                    }
                }
                else {
                    platform.transform.position = new Vector2(1000, 1000);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.layer == OBSTACLE_LAYER) {
            // Move Obstacles to some point
        }
        else if (other.gameObject.layer == TURTLE_LAYER) {
            // Move Turtles to some point
        }
        else if (other.gameObject.layer == PLATFORM_LAYER) {

            if (!(Time.time - spawnedPlatformTime > 1.5f)) {
                return;
            }
            else {
                spawnedPlatformTime = Time.time;
            }

            if (isNextPlatformDown) {
                if (downPlatformCount == counterEnd) {
                    downPlatformCount = 0;
                }
                
                if (lastPlatformWasDown) {
                    downPlatforms[downPlatformCount].position = new Vector2(lastPlacedPlatform.position.x + downPlatformWidth + 1.3f, lastPlacedPlatform.position.y - 1.15f);
                }
                else {
                    downPlatforms[downPlatformCount].position = new Vector2(lastPlacedPlatform.position.x + downPlatformWidth + 1.3f, lastPlacedPlatform.position.y - 1.15f);
                }

                lastPlatformWasDown = true;
                lastPlacedPlatform = downPlatforms[downPlatformCount];
                downPlatformCount++;
            }
            else if (isNextPlatformUp) {
                if (upPlatformCount == counterEnd) {
                    upPlatformCount = 0;
                }
                if (lastPlatformWasDown) {
                    upPlatforms[upPlatformCount].position = new Vector2(lastPlacedPlatform.position.x + upPlatformWidth, lastPlacedPlatform.position.y + 1.2f);
                }
                else {
                    upPlatforms[upPlatformCount].position = new Vector2(lastPlacedPlatform.position.x + upPlatformWidth, lastPlacedPlatform.position.y + 1.2f);
                }
                
                lastPlatformWasDown = false;
                lastPlacedPlatform = upPlatforms[upPlatformCount];
                upPlatformCount++;
            }
            else {
                if (platformCounter == counterEnd) {
                    platformCounter = 0;
                }

                if (lastPlatformWasDown) {
                    platforms[platformCounter].position = new Vector2(lastPlacedPlatform.position.x + platformWidths[platformCounter], lastPlacedPlatform.position.y);
                }
                else {
                    platforms[platformCounter].position = new Vector2(lastPlacedPlatform.position.x + platformWidths[platformCounter], lastPlacedPlatform.position.y);
                }

                lastPlacedPlatform = platforms[platformCounter];
                
                platformCounter++;
                lastPlatformWasDown = false;
            }
        }
    }
}
