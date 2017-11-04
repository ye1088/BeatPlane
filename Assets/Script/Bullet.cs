using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 8;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
        
        if (4.1 < this.transform.position.y)
        {
            Destroy(this.gameObject);
        }

		
	}
}
