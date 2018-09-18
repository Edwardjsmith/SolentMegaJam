using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {
    public float speed;
    public GameObject obstacle;
    public int pooledobstacle = 18;
    List<GameObject> obstaclepool;
    public Vector3 pos;
    public GameObject GameManager;

    Transform[] spawnPoints;

    Transform spawn1;
    Transform spawn2;
    Transform spawn3;

    RaycastHit2D[] rays;



    public static int activeNum;
    int maxNum = 0;
    int spawn;


    public float spawnTimer = 2.0f;
    float origTimer;
    
    // Use this for initialization
    void Start () {

        origTimer = spawnTimer;
    
        obstaclepool = new List<GameObject>();
        for (int i = 0; i < pooledobstacle; i++)
        {
            GameObject obj = (GameObject)Instantiate(obstacle);
            obj.SetActive(false);
            obstaclepool.Add(obj);
        }

        spawnPoints = new Transform[3];
        spawn1 = GameObject.Find("spawn1").transform;
        spawn2 = GameObject.Find("spawn2").transform;
        spawn3 = GameObject.Find("spawn3").transform;

        spawnPoints.SetValue(spawn1, 0);
        spawnPoints.SetValue(spawn2, 1);
        spawnPoints.SetValue(spawn3, 2);

       
        foreach (GameObject go in obstaclepool)
        {
            if (go.activeSelf == false)
            {
                go.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {



        spawnOb();
        


        foreach (GameObject go in obstaclepool)
        {
            if (go.activeSelf == false)
            {
                go.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
        }

      
    }

  
   
    void spawnOb()
    {
        
        if (spawnTimer <= 0)
        {
            maxNum = Random.Range(1, 3);
            do
            {
                spawn = Random.Range(0, 18);
                obstaclepool[spawn].gameObject.SetActive(true);
                activeNum++;

            } while (activeNum <= maxNum);

            
            spawnTimer = origTimer;
            
        }
        spawnTimer -= Time.deltaTime;
    }
}

