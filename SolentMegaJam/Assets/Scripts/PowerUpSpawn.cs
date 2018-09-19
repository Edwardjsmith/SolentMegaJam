using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour {
    
    public GameObject PowerUp;
    public int pooledPowerUp = 12;
    List<GameObject> PowerUppool;
    
    // Use this for initialization
    void Start () {
        
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

