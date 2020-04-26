using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChompaAI : MonoBehaviour
{

    Vector3 startPos = new Vector3(0,0,0);
    public bool left = true;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public float distance = 3;

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
            if (transform.position.x < startPos.x - distance){
                left = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            }
        }else{
            transform.position += new Vector3(0.05f, 0, 0);
            if (transform.position.x >= startPos.x){
                gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
                left = true;
            }
        }
    }
}
