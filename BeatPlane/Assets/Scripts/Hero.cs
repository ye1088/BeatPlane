using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public Sprite[] sprites;

    public bool isInAnimation = true;

    public int animationCountPersecond = 10;

    private int animationCount;

    public float totalTime = 0f;

    private int heroIndex = 0;

    private float maxAwardStillTime = 5f;
    private float currentAwardStillTime = 0f;


    public Gun leftGun;
    public Gun rightGun;
    public Gun midGun;

    private SpriteRenderer spriteRenderer;


    private bool isMouseDown = false;

    private Vector3 lastPostion;

    private Vector3 mouseOfs = Vector3.zero;

    private Text bombGUI;

    private int bombNum = 0;

    private Text historyHighScoreTxt;
    private Text currentScoreTxt;


	// Use this for initialization
	void Start () {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        lastPostion = Vector3.zero;
        bombGUI = GameObject.FindGameObjectWithTag("BombNum").GetComponent<Text>();
        historyHighScoreTxt = GameObject.FindGameObjectWithTag("HistoryHighScore").GetComponent<Text>();
        currentScoreTxt = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<Text>();
        historyHighScoreTxt.text = "";
        currentScoreTxt.text = "";
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

            if (currentAwardStillTime > 0)
            {
                currentAwardStillTime -= Time.deltaTime;
                if (currentAwardStillTime == 0)
                {
                    currentAwardStillTime = -1;
                }
            }
            else if (currentAwardStillTime < 0)
            {

                currentAwardStillTime = 0;
                superGun(false);
            }
        }
	}

    private void superGun(bool isIn)
    {
        if (currentAwardStillTime > 0 )
        {
            currentAwardStillTime = maxAwardStillTime;
            return;
        }
        if (isIn)
        {
            leftGun.openFire();
            rightGun.openFire();
            midGun.stopFire();
        }
        else
        {

            leftGun.stopFire();
            rightGun.stopFire();
            midGun.openFire();
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        switch (tag)
        {
            case "Enermy":
                collision.gameObject.SendMessage("toDie");
                heroDied();
                break;
            case "Award":
                getAward(collision);
                break;
            default:
                break;

        }
    }

    private void getAward(Collider2D collision)
    {
        Award.AwardType awardType = collision.GetComponent<Award>().awardType;
        Destroy(collision.gameObject);
        switch (awardType)
        {
            case Award.AwardType.BULLET:
                
                superGun(true);
                currentAwardStillTime = maxAwardStillTime;
                break;
            case Award.AwardType.BOMB:

                addBomb();
                break;
            default:
                break;
        }
        
    }


    private void setBombTxt()
    {
        bombGUI.text = " X  "+bombNum;
    }
    private void addBomb()
    {
        bombNum++;
        setBombTxt();
    }

    private void heroDied()
    {
        GameManager._instance.debugLog("Hero : heroDied");
        bombGUI.text = "";
        GameOver._instance.gameOver(historyHighScoreTxt,currentScoreTxt);
        Destroy(gameObject);
    }
}
