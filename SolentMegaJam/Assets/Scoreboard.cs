using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour {

    private int highscore;
    private string highname;

    private int count = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        highscore = PlayerPrefs.GetInt("Score" + count, 0);
        highname = PlayerPrefs.GetString("Name" + count);
    }
}
