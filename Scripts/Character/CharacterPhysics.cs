﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Movement>().comingDown && !this.GetComponent<Movement>().jumping){
            transform.position += new Vector3(0, -0.15f, 0);
        }
    }
    
}