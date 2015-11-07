using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Remoting.Channels;

[RequireComponent(typeof(AudioSource))]
public class SoundAnalizer : MonoBehaviour
{

    #region public Parameters

    // A reference to the cube prefab
    public GameObject[] treeArray;

    #endregion

    #region private Paremters

    // Clip audioSource
    private AudioSource audioSource;

    // The array of data analized from the song.
    private float[] audioArray = new float[64];

    // The speed at which the cubes will fall back to earth
    private Vector3 gravity = new Vector3(0.0f, 0.25f, 0.0f);

    // An array holding the different cubes instantiated
    private GameObject[] cubeGameObjectsArray;

    // holds data on the current cubes position
    private Vector3 cubePosition;

    private float spectrumAverage = 0;

    #endregion

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumArray = getSpectrumData();
        animatedTrees(spectrumArray);
        getMidAverage(spectrumArray);
    }

    #region spectrum
    private float[] getSpectrumData()
    {
        float[] returnArray = new float[64];
        // get the spectrum for the current audio
        audioSource.GetSpectrumData(returnArray, 0, FFTWindow.BlackmanHarris);

        return returnArray;
    }

    private int getMidAverage(float[] spectrumArray)
    {
        int sum = 0;
        for (int i = 25; i < 35; i++)
        {
            sum += (int)Mathf.Clamp(spectrumArray[i] * (50 + i * i), 0, 50);
        }
        sum /= 10;
        return sum;
    }
    #endregion
    #region cubes
    private void initializeCubes()
    {
        // init the array that will hold all the cubes
        cubeGameObjectsArray = new GameObject[audioArray.Length];

        // create all the cubes and add them to the array
        for (int cubeCount = 0; cubeCount < audioArray.Length; cubeCount++)
        {
            cubeGameObjectsArray[cubeCount] = Instantiate(treeArray[cubeCount], new Vector3(-audioArray.Length / 2 + cubeCount, 0, 0), Quaternion.identity) as GameObject;
        }
    }

    private void animatedTrees(float[] spectrumDisplay)
    {
        for (int i = 0; i < treeArray.Length; i++)
        {
            // Set the new position for the current cube
            cubePosition.Set(treeArray[i].transform.position.x, (int)Mathf.Clamp(spectrumDisplay[i + 5] * (50 + i * i), 0, 4) - 5, treeArray[i].transform.position.z);

            // if the desired cube position is greater than the transform change it, else let it go down
            if (cubePosition.y >= treeArray[i].transform.position.y)
            {
                // Set the cube to the new Y position  
                treeArray[i].transform.position = cubePosition;
            }
            else
            {
                // let the cube fall
                treeArray[i].transform.position -= gravity;
            }
        }
    }
    #endregion
}
