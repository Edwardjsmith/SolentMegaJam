using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {

    private int newscore;
    private int highscore;

    private int count = 0;
    private bool loop = true;

    public StartUp gm;

	void Start () //on game end
    {
        //newscore = StartUp.score;
        newscore = PlayerPrefs.GetInt("NewScore");
    }
	
	public void Scoring ()
    {
        newscore = PlayerPrefs.GetInt("NewScore");

        while (loop == true)
        {
            newscore = StartUp.score;
            highscore = PlayerPrefs.GetInt("Score" + count, 0);

            /*if (newscore > highscore)
            {
                int newhigh = count;
                int count2 = count+1;
                Debug.Log("found score position");

                while (PlayerPrefs.GetInt("Score" + count, 0) != 0)//find end of scoreboard
                {
                    count++;
                    count2++;
                    Debug.Log("end loop");
                }
                while (count != newhigh)//shuffle scoreboard down
                {
                    PlayerPrefs.SetInt("Score" + count2, PlayerPrefs.GetInt("Score" + count));
                    PlayerPrefs.SetString("Name" + count2, PlayerPrefs.GetString("Name" + count));
                    count--;
                    count2--;
                    Debug.Log("shuffle loop");
                }
                PlayerPrefs.SetInt("Score" + newhigh, newscore);//insert new score
                PlayerPrefs.GetString("Name" + count, " ");//if name is empty
                PlayerPrefs.SetString("Name" + count, name);//insert name
                count = 0;
                loop = false;
            }
            else
            {
                count++;
            }*/
            Debug.Log("main loop");
        }

        PlayerPrefs.SetFloat("Score0", newscore);//insert new score
        PlayerPrefs.SetString("Name0", name);//insert name
    }
}