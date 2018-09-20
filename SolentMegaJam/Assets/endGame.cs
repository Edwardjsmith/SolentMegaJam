using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

      public StartUp gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void changeScene()
    {
        Time.timeScale = 1;
        gm.loadScene(2);
    }
}
