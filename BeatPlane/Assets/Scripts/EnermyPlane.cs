using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyPlane : MonoBehaviour {

    public float moveSpeed = 2f;

    public int hp = 1;
    public bool isInAnimation = true;
     
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isInAnimation)
        {

            
            this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (-5.5f > this.transform.position.y)
            {
                Destroy(this.gameObject);
            }
        }
	}
}
