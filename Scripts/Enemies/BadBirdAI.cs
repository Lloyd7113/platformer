using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBirdAI : MonoBehaviour
{

    Vector3 startPos = new Vector3(0,0,0);
    public bool left = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (left){
            transform.position += new Vector3(-0.05f, 0, 0);
            if (transform.position.x < startPos.x -4){
                left = false;
            }
        }else{
            transform.position += new Vector3(0.05f, 0, 0);
            if (transform.position.x >= startPos.x){
                left = true;
            }
        }
    }
}
