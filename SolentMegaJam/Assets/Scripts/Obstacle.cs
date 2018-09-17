using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float speed;
    public GameObject obstacle;
    public int pooledobstacle = 18;
    List<GameObject> obstaclepool;
    public Vector3 pos;
    public GameObject GameManager;
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


    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -12f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        obstacle.SetActive(false);
    }
}

