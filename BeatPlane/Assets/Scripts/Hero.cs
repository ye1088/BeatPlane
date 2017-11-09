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


    private bool isMouseDown = false;

    private Vector3 lastPostion;

    private Vector3 mouseOfs = Vector3.zero;


	// Use this for initialization
	void Start () {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        lastPostion = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

        if (isInAnimation)
        {
            totalTime += Time.deltaTime;
            animationCount =(int) ( totalTime / (1f / animationCountPersecond));
            heroIndex = animationCount % 2;
            spriteRenderer.sprite = sprites[heroIndex];

            if (Input.GetMouseButtonDown(0))
            {
                isMouseDown = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDown = false;
                lastPostion = Vector3.zero;
            }

            if (isMouseDown)
            {
                if (Vector3.zero == lastPostion)
                {
                    lastPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                else
                {
                    mouseOfs = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastPostion;
                    this.transform.position += mouseOfs;
                    lastPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    checkIsOutAndFix();
                }
            }
        }
	}

    void checkIsOutAndFix()
    {
        if (this.transform.position.x < -2.1f)
        {
            this.transform.position = new Vector3(-2.1f,this.transform.position.y,this.transform.position.z);
        }


        if (this.transform.position.x > 2.1f)
        {
            this.transform.position = new Vector3(2.1f, this.transform.position.y, this.transform.position.z);
        }


        if (this.transform.position.y < -3.82f)
        {
            this.transform.position = new Vector3(this.transform.position.x, -3.82f, this.transform.position.z);
        }

        if (this.transform.position.y > 3.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x, 3.5f, this.transform.position.z);
        }
    }
}
