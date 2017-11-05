using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int hp = 1;

    public float speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (-5.22f > this.transform.position.y)
        {
            Destroy(this.gameObject);
        }
	}
}
