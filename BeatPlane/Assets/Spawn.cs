using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


    public GameObject littleEnermy;

    public GameObject midEnermy;
     
    public GameObject bigEnermy;

    public GameObject awardBullet;
    public GameObject awardExplode;

    private Vector3 position;
    public float createRate = 20f;



    void createLittleEnermy()
    {
        GameObject.Instantiate(littleEnermy, new Vector3(Random.Range(-2.2f, 2.2f), position.y, position.z), Quaternion.identity);

    }


    void createMidEnermy()
    {
        GameObject.Instantiate(midEnermy, new Vector3(Random.Range(-2.2f, 2.2f), position.y, position.z), Quaternion.identity);

    }

    void createBigEnermy()
    {
        GameObject.Instantiate(bigEnermy, new Vector3(Random.Range(-2.2f, 2.2f), position.y, position.z), Quaternion.identity);

    }

    void createAwardBullet()
    {
        GameObject.Instantiate(awardBullet, new Vector3(Random.Range(-2.2f, 2.2f), position.y, position.z),Quaternion.identity);
    }

    void createAwardExplode()
    {
        GameObject.Instantiate(awardExplode, new Vector3(Random.Range(-2.2f, 2.2f), position.y, position.z), Quaternion.identity);
    }

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("createLittleEnermy", 1, Time.deltaTime * createRate);
        InvokeRepeating("createMidEnermy", 5, Time.deltaTime * createRate*4);
        InvokeRepeating("createBigEnermy", 10, Time.deltaTime * createRate * 8);
        InvokeRepeating("createAwardBullet", 15, Time.deltaTime * createRate * 16);
        InvokeRepeating("createAwardExplode", 20, Time.deltaTime * createRate * 20);
    }
	
	// Update is called once per frame
	void Update () {
        position = this.transform.position;
	}
}
