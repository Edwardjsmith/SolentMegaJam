using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    public ScrollRect ScrollView;
    public GameObject ScoreContent;
    public GameObject HighScorePrefab;

    private int highscore;
    private string highname;

    private int count = 0;

    void Start ()
    {
        PlayerPrefs.SetInt("Score0", 50);
        PlayerPrefs.SetString("Name0", "Weeee");

        while (PlayerPrefs.GetInt("Score" + count, 0) != 0)
        {
            highscore = PlayerPrefs.GetInt("Score" + count, 0);
            highname = PlayerPrefs.GetString("Name" + count);

            GameObject HighScoreObj = Instantiate(HighScorePrefab);
            HighScoreObj.transform.SetParent(ScoreContent.transform, false);
            HighScoreObj.transform.Find("Score").gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("Score" + count).ToString();
            HighScoreObj.transform.Find("Name").gameObject.GetComponent<Text>().text = PlayerPrefs.GetString("Name" + count);

            count++;
        }
    }
	
	void Update ()
    {
        
    }
}
