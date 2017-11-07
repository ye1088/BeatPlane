using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public Sprite[] sprites;

    public bool isInAnimation = true;

    public int animationCountPersecond = 10;

    private int animationCount;

    public float totalTime = 0f;

    private int heroIndex = 0;

    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isInAnimation)
        {
            totalTime += Time.deltaTime;
            animationCount =(int) ( totalTime / (1f / animationCountPersecond));
            heroIndex = animationCount % 2;
            spriteRenderer.sprite = sprites[heroIndex];
        }
	}
}
