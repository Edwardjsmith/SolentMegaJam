﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
	}
}
