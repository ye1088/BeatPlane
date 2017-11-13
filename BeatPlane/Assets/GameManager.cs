using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    private bool isDebug = true;
    public int score = 0;

    private Text scoreGUI;
    


    private void Awake()
    {
        scoreGUI = GameObject.FindGameObjectWithTag("ScoreGUI").GetComponent<Text>();
        
    }


    public void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }
    // Use this for initialization
    void Start () {
        _instance = this;

        

    }
	
	// Update is called once per frame
	void Update () {
        scoreGUI.text = "Score: " + score;

    }


    public void debugLog(string msg)
    {
        if (isDebug)
        {
            Debug.Log(msg);
        }
    }
}
