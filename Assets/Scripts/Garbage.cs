using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Garbage : MonoBehaviour
{
    public GameObject garbage;
    public Transform transforms;
    public Rigidbody2D rg2d;
    public Vector3 posI;    
    public TextMeshProUGUI txtSocore;
    public TextMeshProUGUI txtTime;
    public float gameTime;
    public float countTime;
    public Sprite[] sprites;
    public int score;
    public PolygonCollider2D[] polyColliders2d;
    public int random;
    public bool isTopGarbage;
    public int bestScore;

    void Start()
    {
        gameTime = 59;
        countTime = 0;
        rg2d.gravityScale = 0f;
        score = 0;
        posI = new Vector3(0,-3,0);
        random = Random.Range(0,sprites.Length);
        GetComponent<SpriteRenderer>().sprite=sprites[random];
        isTopGarbage = false;
        bestScore = PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        txtSocore.text = "Score: " + score;
        if(Input.GetMouseButton(0))
        {
            rg2d.gravityScale = 0f;
        }
        else
        {
            rg2d.gravityScale = 1f;
        }
        controlPositionGarvage();
        onOffColliders();
        controlHighScore();
    }

    private void OnMouseDrag() {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objPosition = Camera.main.ScreenToViewportPoint(mousePosition);
        objPosition.x = objPosition.x*20-10f;
        objPosition.y = objPosition.y*10-5f;
        transforms.position = objPosition;  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="YellowContainer")
        {
            addScore(0,2,random);
        }
        if(collision.gameObject.tag=="RedContainer")
        {
            addScore(3,5,random);
        }
        if(collision.gameObject.tag=="GreenContainer")
        {
            addScore(6,8,random);
        }
        if(collision.gameObject.tag=="BlueContainer")
        {
            addScore(9,11,random);
        }
    }

    private void addScore(int a, int b, int rand)
    {
        if (rand>=a && rand<=b){
            score++;
        }
        rand = Random.Range(0,sprites.Length);
        random = rand;
        GetComponent<SpriteRenderer>().sprite=sprites[rand];
        transforms.position = posI;
        isTopGarbage = false;
    }

    public void controlPositionGarvage()
    {
        if(transforms.position.y>=3)
        {
            isTopGarbage = true;
        }
        if(transforms.position.y<-5)
        {
            transforms.position = posI;
        }
    }

    private void onOffColliders()
    {
        if(isTopGarbage)
        {
            for(int i=0; i<polyColliders2d.Length; i++)
            {
                polyColliders2d[i].enabled=true;
            }
        }
        else
        {
            for(int i=0; i<polyColliders2d.Length; i++)
            {
                polyColliders2d[i].enabled=false;
            }
        }
    }

    private void controlHighScore()
    {
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}

