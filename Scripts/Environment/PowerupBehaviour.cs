using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{

    Vector3 startPos;
    public float height;
    bool headingUp;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= startPos.y){
            headingUp = true;
        }else if (transform.position.y >= startPos.y + height){
            headingUp = false;
        }

        if (headingUp){
            transform.position += new Vector3(0, 0.01f, 0);
        }else{
            transform.position += new Vector3(0, -0.01f, 0);
        }
    }

    void OnEnterCollision(){
        Destroy(gameObject);
    }
}
