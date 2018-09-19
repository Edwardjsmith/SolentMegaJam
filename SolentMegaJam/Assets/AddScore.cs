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
                int newhigh = count;
                int count2 = count+1;

                while (PlayerPrefs.GetInt("Score"+count) != 0)
                {
                    PlayerPrefs.SetInt("Score"+count2, PlayerPrefs.GetInt("Score"+count));
                    count++;
                    count2++;
                }
                PlayerPrefs.SetInt("Score"+newhigh, newscore);
                //PlayerPrefs.SetString("Name"+count, name input)
                count = 0;
                break;
            }
            else
            {
                count++;
            }
        }
	}
}