using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // var posStart = new Vector3(0,0,0);
        // var mousePos = new Vector3(0,0,0);
        // if(Input.GetMouseButtonDown(0))
        // {
        //     mousePos = Input.mousePosition;
        //     posStart = gameObject.transform.position;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.transform.Translate(0, 250f*Time.deltaTime, 0);
        }
    }
}
