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


    // Use this for initialization
    void Start () {
        speed = 5;

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

        int spawn = Random.Range(0, obstaclepool.Capacity);

        obstaclepool[spawn].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        obstaclepool[spawn].SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.name == "Doggo" || collision.gameObject.name == "Human" || collision.gameObject.name == "poolDeactivator")
        {
            //Destroy(collision.gameObject);
            obstacle.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            obstacle.SetActive(false);
        }
    }
}

