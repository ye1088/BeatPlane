using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {


    public float moveSpeed = 2f;

    private bool isInAnimation = true;

    private Vector3 position;

    private AudioSource mAudio;


	// Use this for initialization
	void Start () {
        mAudio = this.GetComponent<AudioSource>();
        mAudio.Play();
         
	}
	
	// Update is called once per frame
	void Update () {

        position = this.transform.position;
        if (isInAnimation)
        {
            this.transform.position = new Vector3(position.x,position.y + Time.deltaTime * moveSpeed,position.z);
            if (this.transform.position.y > 4.1f)
            {
                Destroy(this.gameObject);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enermy")
        {
            other.SendMessage("beHit");
            Destroy(this.gameObject);
        }
    }
   
}
