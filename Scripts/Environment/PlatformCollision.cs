using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "character"){
            collision.gameObject.GetComponent<Movement>().comingDown = false;
        }
    }

    void OnCollisionStay(Collision collision){
        if (collision.gameObject.name == "character"){
            collision.gameObject.GetComponent<Movement>().comingDown = false;
        }
    }
}
