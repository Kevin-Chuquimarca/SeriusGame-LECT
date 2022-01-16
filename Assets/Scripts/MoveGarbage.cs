using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGarbage : MonoBehaviour
{
    public GameObject garbage;
    public Transform trans;
    public Rigidbody2D rg2d;
    public BoxCollider2D boxCldr2d;
    public bool holdingBall = true;
    public float garbageForce = 250f;
    public float distanceGarbage = 2f;
    public Vector3 pos0 = new Vector3(0,-3,0);

    void Start()
    {
        rg2d = garbage.GetComponent<Rigidbody2D>();
        rg2d.gravityScale = 0f;
    }

    void Update()
    {
        Vector3 mousePos2D = mousePositionScale2D();
        if(Input.GetMouseButton(0) && mousePos2D.y<2f)
        {
            trans.position = mousePos2D;
        }
        else
        {
            trans.position = pos0;
        }
    }

    private Vector3 mousePositionScale2D(){
        float scale = 1/52f;
        return new Vector3(Input.mousePosition.x*scale-8.75f, Input.mousePosition.y*scale-4.75f, 0);
    }
}

