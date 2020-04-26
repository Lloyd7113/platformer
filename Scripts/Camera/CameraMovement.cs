using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Vector3 defaultPos;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("character").transform;
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yVal = player.position.y;
        if (yVal < defaultPos.y){
            yVal = defaultPos.y;
        }

        transform.position = new Vector3(player.position.x, yVal, defaultPos.z);
    }
}
