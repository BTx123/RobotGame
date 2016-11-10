// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/adding-ui-level-transitions

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float levelStartDelay = 2f;
    public static GameManager instance = null;
    private LevelManager levelScript;

    private Text levelText;
    private GameObject levelImage;
    private int level = 1;
    //private List<Enemy> enemies;
    private bool doingSetup;

    void Awake()
    {
        // only one instance of GameManger possible
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        // don't destroy this when reloading scene
        DontDestroyOnLoad(gameObject);
        //enemies = new List<Enemy>();
    }

    private void OnLevelWasLoaded()
    {
        level++;
        InitGame();
    }

    // Start game
    void InitGame()
    {
        doingSetup = true;
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Day " + level;
        levelImage.SetActive(true);
        // call HideLevelImage function with a delay
        Invoke("HideLevelImage", levelStartDelay);
    }

    // Hide levelImage and set setup to false
    void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    void Update()
    {
        //update enemy movement
    }

    //public void AddEnemytToList(Enemy script)
    //{
    //    enemies.add(script);
    //}

    public void GameOver()
    {
        // change levelText to reflect loss
        levelText.text = "You have failed.";
        levelImage.SetActive(true);
        // disable GameManager
        enabled = false;
    }
}