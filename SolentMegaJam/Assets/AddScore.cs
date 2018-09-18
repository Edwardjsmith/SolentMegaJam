using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    private int newscore;
    private int highscore;

    private int count = 0;

	void Start () //on game end
    {
        //newscore = final score from game once game has ended
        //newscore = PlayerPrefs.GetInt("NewScore")
	}
	
	void Update ()
    {
        while (true)
        {
            highscore = PlayerPrefs.GetInt("Score"+count, 0);

            if (newscore > highscore)
            {
                PlayerPrefs.SetInt("Score"+count, newscore);
                //PlayerPrefs.SetString("Name"+count, name input)
                count = 0;
            }
            else
            {
                count++;
            }
        }
	}
}