using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {

    private int newscore;
    private int highscore;

    private int count;
    private bool loop = true;

    public StartUp gm;

	void Start () //on game end
    {
        newscore = PlayerPrefs.GetInt("NewScore");
    }
	
	public void Scoring ()
    {
        newscore = PlayerPrefs.GetInt("NewScore");
        count = PlayerPrefs.GetInt("Count", 0) + 1;

        PlayerPrefs.SetInt("Score"+count, newscore);//insert new score
        PlayerPrefs.SetString("Name"+count, name);//insert name
        PlayerPrefs.SetInt("Count", count);
    }
}