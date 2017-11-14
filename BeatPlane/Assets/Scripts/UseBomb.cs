using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBomb : MonoBehaviour {


    private Text bombGUI;

    private int bombNum = 0;

	// Use this for initialization
	void Start () {
        bombGUI = GameObject.FindGameObjectWithTag("BombNum").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager._instance.heroDied)
        {
            bombGUI.text = "";
        }
	}

    private void setBombTxt()
    {
        bombGUI.text = " X  " + bombNum;
    }
   
    public void addBomb()
    {
        bombNum++;
        setBombTxt();
    }

    public void useBomb()
    {
        if (bombNum > 0)
        {
            bombNum--;
            setBombTxt();
            GameManager._instance.isUseBomb = true;
            Invoke("setIsUseBombFalse", 0.5f);
        }
        
    }

   

    private void setIsUseBombFalse()
    {
        GameManager._instance.isUseBomb = false;
    }
    void OnMouseUpAsButton()
    {
        GameManager._instance.debugLog("UseBomb : OnMouseUpAsButton");
        useBomb();
    }
}
