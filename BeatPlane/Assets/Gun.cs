using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;

    public float fireRate = 0.2f;

    void fire()
    {
        GameObject.Instantiate(bullet, 
            this.transform.position, Quaternion.identity);
    }

    void openFire()
    {
        InvokeRepeating("fire", 1, fireRate);
    }

	// Use this for initialization
	void Start () {
        openFire();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
