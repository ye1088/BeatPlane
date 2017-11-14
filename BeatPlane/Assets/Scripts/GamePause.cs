using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

    int bePressedNum = 0;

    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
		
	}
 

    //void OnPointUpAsButton()
    //{
    //    GameManager._instance.debugLog("GamePause : OnClickButtonHandler");
    //}
    void OnMouseUpAsButton()
    {

        bePressedNum++;
        int pauseIndex = bePressedNum % 2;
        if (1==pauseIndex){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[pauseIndex];
            GameManager._instance.pauseGame();
        }else{
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[pauseIndex];
            GameManager._instance.resumeGame();
        }
        //GameManager._instance.debugLog("GamePause : OnMouseUpAsButton");
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
