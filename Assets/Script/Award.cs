using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour {

    public int type = 0; // 0 Gun 1 explode

    public float speed = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (-4.6f > this.transform.position.y)
        {
            Destroy(this.gameObject);
        }
	}
}
