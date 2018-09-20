using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

<<<<<<< HEAD
    private int newscore;
=======
    private int newscore = 10;
>>>>>>> origin/NikBranch2
    private int highscore;

    private int count = 0;

	void Start () //on game end
    {
        newscore = StartUp.score;
        //newscore = PlayerPrefs.GetInt("NewScore")

        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(Scoring);
        input.onEndEdit = se;
    }
	
<<<<<<< HEAD
	void Update ()
=======
	public void Scoring (string name)
>>>>>>> origin/NikBranch2
    {
        while (true)
        {
            highscore = PlayerPrefs.GetInt("Score" + count, 0);

            if (newscore > highscore)
            {
                int newhigh = count;
                int count2 = count+1;

                while (PlayerPrefs.GetInt("Score" + count, 0) != 0)//find end of scoreboard
                {
                    count++;
                    count2++;
                }
                while (count != newhigh)//shuffle scoreboard down
                {
                    PlayerPrefs.SetInt("Score" + count2, PlayerPrefs.GetInt("Score" + count));
                    PlayerPrefs.SetString("Name" + count2, PlayerPrefs.GetString("Name" + count));
                    count--;
                    count2--;
                }
<<<<<<< HEAD
                PlayerPrefs.SetInt("Score" + newhigh, newscore); //insert new score
                //PlayerPrefs.SetString("Name"+count, name input) //ask for name
=======
                PlayerPrefs.SetInt("Score" + newhigh, newscore);//insert new score
                PlayerPrefs.SetString("Name" + count, name);//insert name
>>>>>>> origin/NikBranch2
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