using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


    public float fireRate = 0.2f;

    public bool isDebug = true;
    public GameObject bullet;

    public void debugLog(string msg)
    {
        if (isDebug)
        {
            Debug.Log(msg);
        }
    }

    public void fire()
    {
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        
    }

    public void openFire()
    {
        InvokeRepeating("fire", 1, fireRate);
    }

	// Use this for initialization
	void Start () {
        debugLog("start");
        openFire();
	}
	 
}
