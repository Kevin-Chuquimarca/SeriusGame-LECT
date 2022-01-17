using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGarbage : MonoBehaviour
{
    public GameObject garbage;
    public Transform trans;
    public Rigidbody2D rg2d;
    public BoxCollider2D boxCldr2d;
    public Vector3 posI = new Vector3(0,-3,0);
    public Vector3 pos0 = new Vector3(0,0,0);
    public Vector3 pos1 = new Vector3(0,0,0);
    // public Vector3 posF = new Vector3(0,0,0);
    public Vector3 speed = new Vector3(0,0,0);
    public float auxTime = 0;

    void Start()
    {
        rg2d = garbage.GetComponent<Rigidbody2D>();
        rg2d.gravityScale = 0f;
    }

    void Update()
    {
        Vector3 mousePos2D = mousePositionScale2D();
        if(Input.GetMouseButton(0) && mousePos2D.y<4f)
        {
            if(auxTime==0){
                pos0 = mousePositionScale2D();
            }
            rg2d.gravityScale = 0f;
            auxTime += Time.deltaTime;
            trans.position = mousePos2D;
        }
        else
        {
            rg2d.gravityScale = 1f;
            // pos1 = mousePositionScale2D();
            // speed = getSpeedMouse(pos1, pos0, auxTime);
            auxTime = 0;
        }
    }

//metodo no funcional cuando el mouse se mueve muy rapido
    // private void OnMouseOver() {
    //     Vector3 mousePos2D = mousePositionScale2D();
    //     if(Input.GetMouseButton(0) && mousePos2D.y<4f)
    //     {
    //         if(auxTime==0){
    //             pos0 = mousePositionScale2D();
    //         }
    //         rg2d.gravityScale = 0f;
    //         auxTime += Time.deltaTime;
    //         trans.position = mousePos2D;
    //     }
    //     else
    //     {
    //         rg2d.gravityScale = 1f;
    //         // pos1 = mousePositionScale2D();
    //         // speed = getSpeedMouse(pos1, pos0, auxTime);
    //         auxTime = 0;
    //     }
    // }

    private Vector3 mousePositionScale2D(){
        float scale = 0.016f;
        return new Vector3(Input.mousePosition.x*scale-9f, Input.mousePosition.y*scale-4.75f, 0);
    }

    private Vector3 getSpeedMouse(Vector3 mousePosF, Vector3 mousePosI, float time){
        return new Vector3(mousePosF.x-mousePosI.x,mousePosF.y-mousePosI.y,mousePosF.z-mousePosI.z)*(1/time);
    }
}

