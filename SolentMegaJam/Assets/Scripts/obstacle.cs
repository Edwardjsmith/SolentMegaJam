using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {

    public enum type { bush, obstacle };

    public type Type;

    public float speed;

    public LayerMask otherEnemy;

    private void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update ()
    {
        
        transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));

        if(StartUp.score == StartUp.scoreTracker)
        {
            speed += 0.2f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "humanTrigger" && collision.gameObject.layer != otherEnemy)
        {
            gameObject.SetActive(false);
        }
        if(collision.gameObject.layer == otherEnemy)
        {
            if (Type == type.obstacle)
           {
               transform.position = ObstacleSpawn.spawnPoints[Random.Range(0, ObstacleSpawn.spawnPoints.Length)].transform.position;
           }
           else if(Type == type.bush)
           {
               transform.position = ObstacleSpawn.spawnPointsFoliage[Random.Range(0, ObstacleSpawn.spawnPointsFoliage.Length)].transform.position;
           }

            Debug.Log("Reset pos");
        }
    }
}
