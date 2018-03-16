using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLord : MonoBehaviour {

    public GameObject pillow;
    public GameObject sheep;
    public GameObject lollypop;
    public Light light;
    public float awakeness = 100;
    public int pillows = 0;
    public int spawnedPillows = 0;
    public int killedSheeps = 0;
    public bool gameOver = false;
    public AudioSource audioSource;
    public AudioClip pillowExplode;

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
        InvokeRepeating("SpawnLollypop", 3.0f, 3.0f);
    }

    private void Update()
    {
        if (gameOver && Input.GetKey(KeyCode.LeftControl))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

    void MakeSleepier()
    {
        ReduceAwakenss(0.5f);        
    }

    public void ReduceAwakenss(float awakenessReduce)
    {        
            float awaknessChanged = awakeness -= awakenessReduce;
            if (awaknessChanged <= 100)
            {
            awakeness = awaknessChanged;
            light.intensity = (awakeness / 100) * 0.5f;            
            CheckDead();
            }
            
        
    }

    void SpawnLollypop()
    {
        if (GameObject.FindGameObjectsWithTag("Lollypop").Length < 3)
        {
            // Spawn
            Debug.Log("Spawn");
            GameObject spawnedLollypop = Instantiate(lollypop, GetRandomLocation(), Quaternion.identity) as GameObject;
        }
    }

    public void CheckDead()
    {
        if (awakeness <= 0)
        {
            gameOver = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().detectCollisions = false;                               
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
            GameObject spawnedPillow = Instantiate(sheep, GetRandomLocation() - new Vector3(0, 4, 0), Quaternion.identity) as GameObject;
        }
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(25, 25, 150, 50), "Pillows: " + pillows);
        GUI.HorizontalSlider(new Rect((Screen.width / 2)-250, Screen.height-25, 500, 50), awakeness, 0.0F, 100.0F);
        GUI.TextField(new Rect(Screen.width - 225, 25, 150, 50), "Score: " + killedSheeps);
        GUI.skin.textField.fontSize = 30;
        GUI.skin.textField.alignment = TextAnchor.MiddleCenter;
        if (gameOver)
        {
            GUI.TextField(new Rect((Screen.width/2)-250, (Screen.height/2)-25, 500, 50), "Game Over! Press left control...");         
        }
    }

    Vector3 GetRandomLocation()
    {
        return new Vector3(Random.Range(-18, 18), 5, Random.Range(-18, 18));
    }

    public void PlayPillowExplode()
    {
        audioSource.clip = pillowExplode;
        audioSource.volume = 1f;
        audioSource.Play();
    }

}
