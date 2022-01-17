using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Garbage : MonoBehaviour
{
    public GameObject garbage;
    public Transform trans;
    public Rigidbody2D rg2d;
    public BoxCollider2D boxCldr2d;
    public Vector3 posI;
    public TextMeshProUGUI txtSocore;
    public int score;
    public Sprite[] sprites;
    public int random;

    void Start()
    {
        rg2d.gravityScale = 0f;
        score = 0;
        posI = new Vector3(0,-3,0);
        random = Random.Range(0,sprites.Length);
        GetComponent<SpriteRenderer>().sprite=sprites[random];
    }

    void Update()
    {
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="YellowContainer")
        {
            score++;
            random = Random.Range(0,sprites.Length);
            GetComponent<SpriteRenderer>().sprite=sprites[random];
            trans.position = posI;
        }
        if(collision.gameObject.tag=="BlueContainer")
        {
            score++;
            score++;
            random = Random.Range(0,sprites.Length);
            GetComponent<SpriteRenderer>().sprite=sprites[random];
            trans.position = posI;
        }
        if(collision.gameObject.tag=="RedContainer")
        {
            score++;
            score++;
            random = Random.Range(0,sprites.Length);
            GetComponent<SpriteRenderer>().sprite=sprites[random];
            trans.position = posI;
        }
        if(collision.gameObject.tag=="GreenContainer")
        {
            score++;
            score++;
            random = Random.Range(0,sprites.Length);
            GetComponent<SpriteRenderer>().sprite=sprites[random];
            trans.position = posI;
        }
    }

    private Vector3 mousePositionScale2D(){
        float scale = 0.016f;
        return new Vector3(Input.mousePosition.x*scale-9.75f, Input.mousePosition.y*scale-4.75f, 0);
    }
}

