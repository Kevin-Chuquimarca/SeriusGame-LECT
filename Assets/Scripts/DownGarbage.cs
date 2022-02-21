using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DownGarbage : MonoBehaviour
{
    public GameObject garbaje;
    public Transform transforms;
    public Sprite[] sprites;
    public Rigidbody2D rg2d;
    public PolygonCollider2D[] polyColliders;
    public int random;
    public int score;
    public TextMeshProUGUI endScore;
    public float velX = 0.1f;
    public float movX;
    public float inputX;
    public TextMeshProUGUI txtSocore;
    public int bestScore;
    public int localScoreG1;
    public Text totalScore;

    void Start()
    {
        Time.timeScale = 1f;
        score = 0;
        localScoreG1 = PlayerPrefs.GetInt("LocalScoreG1");
        bestScore = PlayerPrefs.GetInt("Highscore");
        transforms.position = new Vector3(0,5,0);
        rg2d.gravityScale=0.1f;
        random = Random.Range(0,sprites.Length);
        GetComponent<SpriteRenderer>().sprite=sprites[random];
        for(int i=0; i<polyColliders.Length; i++)
        {
            polyColliders[i].enabled=true;
        }
        DBManager.countLaunchPlay2=0;
    }

    void Update()
    {
        txtSocore.text = "Score: " + score;
        controlPositionGarvage();
        controlLocalScore();
        showScore();
        DBManager.score2Player = score;
        totalScore.text = (DBManager.score1Player + DBManager.score2Player).ToString();
    }

    void FixedUpdate () {
        float inputX = Input.GetAxis("Horizontal");
        if (inputX>0) {
            movX = transform.position.x + (inputX * velX);
            transforms.position = new Vector3 (movX, transforms.position.y, 0);
        }
        if (inputX<0) {
            movX = transforms.position.x + (inputX * velX);
            transforms.position = new Vector3 (movX, transforms.position.y, 0);
        }
        transform.localScale = new Vector3(0.2f, 0.2f, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DBManager.countLaunchPlay2++;
        if(collision.gameObject.tag=="YellowContainerObj")
        {
            addScore(0,8,random);
        }
        if(collision.gameObject.tag=="RedContainerObj")
        {
            addScore(9,14,random);
        }
        if(collision.gameObject.tag=="GreenContainerObj")
        {
            addScore(15,19,random);
        }
        if(collision.gameObject.tag=="BlueContainerObj")
        {
            addScore(20,26,random);
        }
    }
    private void addScore(int a, int b, int rand)
    {
        if (rand>=a && rand<=b){
            score++;
        }
        newGarbage(rand);
    }

    private void newGarbage(int rand){
        rand = Random.Range(0,sprites.Length);
        random = rand;
        GetComponent<SpriteRenderer>().sprite=sprites[rand];
        transforms.position = new Vector3(0,5,0);
    }

    public void controlPositionGarvage()
    {
        if(transforms.position.y<=-5)
        {
            random = Random.Range(0,sprites.Length);
            newGarbage(random);
        }
    }

    private void controlLocalScore()
    {
        PlayerPrefs.SetInt("LocalScoreG2", score);
    }

    public void showScore ()
    {
        endScore.text = "Score: " + score + " pts";
    }
}
