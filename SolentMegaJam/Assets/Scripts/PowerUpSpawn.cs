using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour {
    public float speed;
    public GameObject PowerUp;
    public int pooledPowerUp = 12;
    List<GameObject> PowerUppool;
    public Vector3 pos;
    public GameObject GameManager;
    // Use this for initialization
    void Start () {
        speed = 3;

        PowerUppool = new List<GameObject>();
        for (int i = 0; i < pooledPowerUp; i++);
        {
            GameObject obj = (GameObject)Instantiate(PowerUp);
            obj.SetActive(false);
            PowerUppool.Add(obj);
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -12f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        PowerUp.SetActive(false);
    }
}

