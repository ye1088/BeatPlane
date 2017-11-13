using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public static GameOver _instance;
	// Use this for initialization
	void Start () {
        _instance = this;
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gameOver(Text historyHighScoreTxt,Text currentScoreTxt)
    {
        this.gameObject.SetActive(true);
        int historyHighScore = PlayerPrefs.GetInt("historyHighScore", 0);
        int currentScore = GameManager._instance.score;
        historyHighScoreTxt.text = historyHighScore + "";
        currentScoreTxt.text = currentScore + "";
        if (currentScore > historyHighScore)
        {
            PlayerPrefs.SetInt("historyHighScore", currentScore);
        }
    }
}
