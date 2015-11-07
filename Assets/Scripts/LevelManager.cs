using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System; 
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary;

public class LevelManager : MonoBehaviour {

	public static LevelManager manager;
	public int highScore;
    public int score;

	private string fileEnding = ".dat";
	
	void Awake () {


        if (manager == null) {
            manager = this;
        }
        else if (manager != this) {
            Destroy(gameObject);
        }

		highScore = Load ();

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}

    void Start() {
    }

	//Overwrites data, need to fix
	public void Save()
	{	
		BinaryFormatter bFormatter = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/ApplicationInfo" + fileEnding);
		LevelData dataToSave = new LevelData ();

		dataToSave.highScore = highScore;

		bFormatter.Serialize (file, dataToSave);
		file.Close ();
	}

	public int Load()
	{
		if (File.Exists (Application.persistentDataPath + "/ApplicationInfo" + fileEnding)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/ApplicationInfo" + fileEnding, FileMode.Open);

			LevelData dataToLoad = (LevelData)bf.Deserialize (file);
			this.highScore = dataToLoad.highScore;
			file.Close ();
			return highScore;
		} else {
			return 0;
		}
	}
}

[Serializable]
class LevelData{
	public int level;
    public float expBarFillAmount;
	public int highScore;
	public int talentPoints;
	public float experience;
	public bool notFirstPlayEver;
	public bool mute;
    public float freezeDuration;
    public float invinciDuration;
    public bool[] talents;
    public int numOfDeaths;
	//public int adCount;

	// Data about upgradeable things
	public int chargeDistance;

}