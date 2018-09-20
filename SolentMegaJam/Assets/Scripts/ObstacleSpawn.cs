using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {
    



    public GameObject[] obstacle;
    public int pooledobstacle = 18;
    List<GameObject> obstaclepool;

    public GameObject[] foliage;
    public int poolFoliage = 18;
    List<GameObject> foliagePool;

    public StartUp GameManager;

    public static Transform[] spawnPoints;

    Transform spawn1;
    Transform spawn2;
    Transform spawn3;

    public static Transform[] spawnPointsFoliage;

    Transform foliageSpawn1;
    Transform foliageSpawn2;


    public static int activeNum;
    int maxNum = 0;
    int spawn;


    public float spawnTimer = 2.0f;
    float origTimer;

    public static int bushActiveNum;
    public float bushSpawnTimer = 0.1f;
    float origBushTimer;
    
    // Use this for initialization
    void Start () {

        origTimer = spawnTimer;
        origBushTimer = bushSpawnTimer;
    
        
        obstaclepool = new List<GameObject>();
        foliagePool = new List<GameObject>();
        for (int i = 0; i < pooledobstacle; i++)
        {
            GameObject obj = (GameObject)Instantiate(obstacle[Random.Range(0, obstacle.Length)]);
            obj.SetActive(false);
            obstaclepool.Add(obj);
        }

        for (int i = 0; i < poolFoliage; i++)
        {
            GameObject obj = (GameObject)Instantiate(foliage[Random.Range(0, foliage.Length)]);
            obj.SetActive(false);
            foliagePool.Add(obj);
        }

        spawnPoints = new Transform[3];
        spawn1 = GameObject.Find("spawn1").transform;
        spawn2 = GameObject.Find("spawn2").transform;
        spawn3 = GameObject.Find("spawn3").transform;

        spawnPoints.SetValue(spawn1, 0);
        spawnPoints.SetValue(spawn2, 1);
        spawnPoints.SetValue(spawn3, 2);

        spawnPointsFoliage = new Transform[2];
        foliageSpawn1 = GameObject.Find("bushSpawn1").transform;
        foliageSpawn2 = GameObject.Find("bushSpawn2").transform;

        spawnPointsFoliage.SetValue(foliageSpawn1, 0);
        spawnPointsFoliage.SetValue(foliageSpawn2, 1);
        
        foreach(GameObject go in foliagePool)
        {
            if (go.activeSelf == false)
            {
                go.transform.position = spawnPointsFoliage[Random.Range(0, spawnPointsFoliage.Length)].transform.position;
            }
        }

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
        spawnBush();

        /*foreach (GameObject go in obstaclepool)
        {
            if (go.activeSelf == false)
            {
                go.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
        }

        foreach (GameObject go in foliagePool)
        {
            if (go.activeSelf == false)
            {
                go.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
        }*/

        if (StartUp.score == StartUp.scoreTracker && origTimer > 1.0f)
        {
            origTimer -= 0.2f;
        }
    }

  
   
    void spawnOb()
    {
        
        if (spawnTimer <= 0)
        {
            maxNum = Random.Range(1, 2);
            do
            {
                spawn = Random.Range(0, 18);
                obstaclepool[spawn].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
                obstaclepool[spawn].gameObject.SetActive(true);
                activeNum++;

            } while (activeNum <= maxNum);

            
            spawnTimer = origTimer;
            
        }
        spawnTimer -= Time.deltaTime;
    }

    void spawnBush()
    {
        if(bushSpawnTimer <= 0)
        {
            maxNum = Random.Range(1, 2);
            do
            {
                spawn = Random.Range(0, 18);


                foliagePool[spawn].gameObject.SetActive(true);
                bushActiveNum++;

            } while (bushActiveNum < maxNum);

            bushSpawnTimer = origBushTimer;
        }

        bushSpawnTimer -= Time.deltaTime;
    }

    void spawnPowerup()
    {
        if (bushSpawnTimer <= 0)
        {
            maxNum = Random.Range(1, 2);
            do
            {
                spawn = Random.Range(0, 18);


                foliagePool[spawn].gameObject.SetActive(true);
                bushActiveNum++;

            } while (bushActiveNum < maxNum);

            bushSpawnTimer = origBushTimer;
        }

        bushSpawnTimer -= Time.deltaTime;
    }
}

