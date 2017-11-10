using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyPlane : MonoBehaviour {

    public float moveSpeed = 2f;

    public int hp = 1;
    public bool isInAnimation = true;

    public Sprite[] dieAnimationSprites;

    private float dieAnimationTime = 0.3f;
    private float hasDiedTime = 0f;

    public EnemyType enemyType = EnemyType.LITTLE;

    public enum EnemyType
    {
        LITTLE,
        MID,
        BIG
    }
     
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

    void beHit()
    {
        hp--;
        if (hp <= 0)
        {
            toDie();
            
        }
    }

    private void toDie()
    {
        InvokeRepeating("dieAnimation", 0, Time.deltaTime);
         
    }

    private void dieAnimation(){
        hasDiedTime += Time.deltaTime;
        int dieAnimationIndex = (int)(hasDiedTime / (dieAnimationTime / dieAnimationSprites.Length)) % dieAnimationSprites.Length;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dieAnimationSprites[dieAnimationIndex];
        if (hasDiedTime >= dieAnimationTime)
        {
            CancelInvoke("toDie");
            Destroy(this.gameObject);
        }
    }
}
