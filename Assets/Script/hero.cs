using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour {

    public bool isInAnimation = true;
    public int framePersecond = 10;
    public Sprite[] sprites;
    public float timer =0;
    //private bool flag = true;
    private bool isDebug = true;


    void debugLog(string msg)
    {
        if (isDebug)
        {
            Debug.Log("hero : MonoBehaviour : " + msg);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        if (isInAnimation)
        {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1f / framePersecond));
            //debugLog("frameIndex : " + frameIndex);
            int spriteIndex = frameIndex % 2;

            
            //int spriteIndex = 0;
            //if (flag)
            //{
                
            //    spriteIndex = 0;
            //}
            //else
            //{
            //    spriteIndex = 1;
            //}
            //flag = !flag;
            this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        }
	}
}
