using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransform : MonoBehaviour {


    public static float moveSpeed = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
 
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        Vector3 postion = this.transform.position;
        if (-8.52f > postion.y)
        {
            this.transform.position = new Vector3(postion.x, postion.y + 8.52f * 2,postion.y);
        }
	}
}
