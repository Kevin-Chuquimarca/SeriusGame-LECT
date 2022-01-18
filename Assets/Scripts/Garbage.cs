using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Garbage : MonoBehaviour
{
    public GameObject garbage;
    public Transform trans;
    public Rigidbody2D rg2d;
    public Vector3 posI;
    public TextMeshProUGUI txtSocore;
    public TextMeshProUGUI txtTime;
    public float gameTime;
    public Sprite[] sprites;
    public int score;
    public PolygonCollider2D[] polyColliders2d;
    public int random;
    public bool isTopGarbage;

    void Start()
    {
        gameTime = 59;
        rg2d.gravityScale = 0f;
        score = 0;
        posI = new Vector3(0,-3,0);
        random = Random.Range(0,sprites.Length);
        GetComponent<SpriteRenderer>().sprite=sprites[random];
        isTopGarbage = false;
    }

    void Update()
    {
        // gameTime-=1;
        txtTime.text = "Time: " + gameTime;
        txtSocore.text = "Score: " + score;
        Vector3 mousePos2D = mousePositionScale2D();
        if(Input.GetMouseButton(0))
        {
            rg2d.gravityScale = 0f;
            trans.position = mousePos2D;
        }
        else
        {
            rg2d.gravityScale = 1f;
        }
        controlPositionGarvage();
        onOffColliders();
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
        trans.position = posI;
        isTopGarbage = false;
    }

    private Vector3 mousePositionScale2D()
    {
        float scale = 0.016f;
        return new Vector3(Input.mousePosition.x*scale-9.75f, Input.mousePosition.y*scale-4.75f, 0);
    }

    public void controlPositionGarvage()
    {
        if(trans.position.y>=3)
        {
            isTopGarbage = true;
        }
        if(trans.position.y<-5)
        {
            trans.position = posI;
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
}

