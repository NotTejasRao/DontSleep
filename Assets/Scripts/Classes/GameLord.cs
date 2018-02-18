using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLord : MonoBehaviour {

    public GameObject pillow;
    public GameObject sheep;
    public float awakeness = 100;
    public int pillows = 0;
    public int spawnedPillows = 0;
    public int killedSheeps = 0;

    void Awake()
    {
        pillows = 0;
        spawnedPillows = 0;
        killedSheeps = 0;
        awakeness = 100;
    }

    void Start()
    {
        InvokeRepeating("MakeSleepier", 1.0f, 1.0f);
        InvokeRepeating("SpawnPillow", 5.0f, 5.0f);
        InvokeRepeating("SpawnSheep", 3.0f, 3.0f);
    }

    void MakeSleepier()
    {
        ReduceAwakenss(1);
    }

    public void ReduceAwakenss(float awakenessReduce)
    {
        awakeness -= awakenessReduce;
        CheckDead();
    }

    public void CheckDead()
    {
        if (awakeness <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
           
        }
    }

    void SpawnPillow()
    {
        if (GameObject.FindGameObjectsWithTag("Pillow").Length < 3)
        {
            // Spawn
            Debug.Log("Spawn");
            GameObject spawnedPillow = Instantiate(pillow, GetRandomLocation(), Quaternion.identity) as GameObject;
        }
    }

    void SpawnSheep()
    {
        for (int i = 0; i < 2+Random.Range(0, killedSheeps/2); i++)
        { 
            GameObject spawnedPillow = Instantiate(sheep, GetRandomLocation(), Quaternion.identity) as GameObject;
        }
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(25, 25, 100, 30), "" + pillows);
        GUI.TextField(new Rect((Screen.width/2)-50, 25, 100, 30), "" + killedSheeps);
        GUI.HorizontalSlider(new Rect(Screen.width-125, 25, 100, 30), awakeness, 0.0F, 100.0F);

    }

    Vector3 GetRandomLocation()
    {
        return new Vector3(Random.Range(-18, 18), 5, Random.Range(-18, 18));
    }

}
