using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float moveSpeed = 7f;

    private Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        position = this.transform.position;

        if (-8.52f > position.y)
        {
            this.transform.position = new Vector3(position.x,position.y + 8.52f * 2,position.z);
        }
	}
}
