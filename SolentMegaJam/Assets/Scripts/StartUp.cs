using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eGamestates
{
    MENU,GAME,GAMEOVER,QUIT
};

public class StartUp : MonoBehaviour {
    public static int score;
    public int lastscore;
    public int Hiscore;
    //public int lives;
    //public int level;


    public static int scoreTracker;
    //public Vector3 PlayerStart;
    public eGamestates e_Gamestates;
    //public GameObject background;

    //public GameObject lifePickup;
    //public int maxLives;
    //public int pickupScore;
    //public int pickupCounter;

    //public bool UpdateLives = false;


    public AudioSource audioSource;
    public AudioClip[] clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        {
            DontDestroyOnLoad(gameObject);
            Init();
            audioSource.clip = clips[0];
            audioSource.Play();
        }

        GetComponentInChildren<ObstacleSpawn>().gameObject.SetActive(false);

        scoreTracker = score + 1000;
    }

    private void Init()
    {
        Hiscore = 0;
        lastscore = 0;
        score = 0;
        //loadCurrentScene(e_Gamestates);
    }

    

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Cancel"))
        {
            loadScene((int)eGamestates.QUIT);// if esc is pressed exit the game
        }

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex((int)eGamestates.GAME))
        { 
            transform.GetChild(0).gameObject.SetActive(true); //This is the obstacle spawn
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if(score >= scoreTracker)
        {
            scoreTracker = score + 1000;
        }
}

    public void AddScore(int Score)
    {
        score += Score;
    }

    /*public void AddLife()
    {
        lives++;
    }

    public void LoseLife()
    {
        lives--;
    }

    public int GetLives()
    {
        return lives;
    }*/

    /*public void placeBG()
    {
        GameObject.Instantiate(background).transform.SetPositionAndRotation(new Vector3(0,0, 3.6f), Quaternion.Euler(0,0,0));
        GameObject.Instantiate(background).transform.SetPositionAndRotation(new Vector3(0,21.5f, 3.6f), Quaternion.Euler(0,0,0));
    }*/

    /*public void spawnPickup(Vector3 position)
    {
        int choice = Random.Range(1, 2);
        switch(choice)
        {
            case 1:
                resetPickupCounter();
                if (lives < maxLives)
                {
                    Instantiate(lifePickup).transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, 0));
                }
                else
                    AddScore(pickupScore);
                break;
            case 2:
                resetPickupCounter();
                if (lives < maxLives)
                {
                    Instantiate(lifePickup).transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, 0));
                }
                else
                    AddScore(pickupScore);
                break;
            default:
                break;
               
        }
    }*/

    /*public void incrementPickupCounter()
    {
        pickupCounter++;
    }

    public int getPickupCounter()
    {
        return pickupCounter;
    }

    public void resetPickupCounter()
    {
        pickupCounter = 0;
    }

    public int getPickupScore()
    {
        return pickupScore;
    }
    public int getmaxLives()
    {
        return maxLives;
    }*/

    public int GetHisScore()
    {
        return Hiscore;
    }

    public int GetLastScore()
    {
        return lastscore;
    }
    public int GetScore()
    {
        return score;
    }

    /*public void setUpdateScore(bool set)
    {
        UpdateScore = set;
    }

    /*public void setUpdateLives(bool set)
    {
        UpdateLives = set;
    }*/

    /*public bool getUpdateScore()
    {
        return UpdateScore;
    }

    /*public bool getUpdateLives()
    {
        return UpdateLives;
    }*/

    public void loadScene(int states)
    {
        e_Gamestates = (eGamestates)states;
        switch (e_Gamestates)
        {
            case eGamestates.MENU:
                SceneManager.LoadScene("Menu");
                audioSource.clip = clips[0];
                break;
            case eGamestates.GAME:
                SceneManager.LoadScene("Game");
                audioSource.clip = clips[0];
                //lives = 3;
                break;
            case eGamestates.GAMEOVER:
                SceneManager.LoadScene("GameOver");
                audioSource.clip = clips[1];
                
                lastscore = score;
                if (score >= Hiscore)
                {
                    Hiscore = score;
                }
                score = 0;
                //lives = 3;
                break;
            case eGamestates.QUIT:
                Application.Quit();
                break;

            default:
                break;


        }
    }
}
