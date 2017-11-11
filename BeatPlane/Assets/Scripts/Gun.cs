using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;

    public float fireRate = 0.4f;

    void fire()
    {
        GameObject.Instantiate(bullet, 
            this.transform.position, Quaternion.identity);
    }


    public void stopFire()
    {
        CancelInvoke("fire");
    }

    public void openFire()
    {
        InvokeRepeating("fire", 0, fireRate);
    }

	// Use this for initialization
	void Start () {
        openFire();
	}


    
	// Update is called once per frame
	void Update () {

	}
}
