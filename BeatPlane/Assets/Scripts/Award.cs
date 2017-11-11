﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour {

   

    private float moveSpeed = 4f;
     
    public enum AwardType
    {
        BULLET,
        BOMB
    }

    public AwardType awardType = AwardType.BULLET;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
	}
}
