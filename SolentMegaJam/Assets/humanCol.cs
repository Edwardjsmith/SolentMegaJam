﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanCol : MonoBehaviour {

    public player play;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            play.die();
        }
    }
}
