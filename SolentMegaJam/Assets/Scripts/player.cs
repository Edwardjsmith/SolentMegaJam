using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public LayerMask obstacle;

    public float moveSpeed = 10.0f;
    public float humanSpeed;
    public GameObject human;

    StartUp gameManager;

    Transform middleMove;
    Transform rightMove;
    Transform leftMove;

    public Transform[] moves;
    public int spacing = -2;

    public int currentMove;
    int oldMove;

    public float humanY;

    public Text score;

    public bool humanMove = false;

   
    public string lineSortingLayer;
    public int lineOrderInLayer;

    public Vector3 newPos;

    LineRenderer lineRenderer;

    public GameObject collar;

    public Image gameover;

    AudioSource source;
    public AudioClip[] effects;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        gameover.color = new Color(gameover.color.r, gameover.color.g, gameover.color.b, 0);
        gameManager = GameObject.Find("gameManager").GetComponent<StartUp>();
        moves = new Transform[3];

        leftMove = GameObject.Find("moveLeft").transform;
        middleMove = GameObject.Find("moveMiddle").transform;
        rightMove = GameObject.Find("moveRight").transform;


        moves.SetValue(leftMove, 0);
        moves.SetValue(middleMove, 1);
        moves.SetValue(rightMove, 2);


        currentMove = 1;
        transform.position = moves[currentMove].position;
        humanY = moves[currentMove].position.y + spacing;
        human.transform.position = new Vector2(moves[currentMove].position.x, humanY);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material.color = Color.black;
        lineRenderer.widthMultiplier = 0.2f;

        lineRenderer.sortingLayerName = lineSortingLayer;
        lineRenderer.sortingOrder = lineOrderInLayer;

    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, collar.transform.position);
        lineRenderer.SetPosition(1, human.transform.GetChild(0).transform.position);

        if (humanMove)
        {
            /*if (!hasMove)
            {
                newPos = new Vector2(moves[currentMove].position.x, humanY);
                hasMove = true;
            }*/


            human.transform.position = Vector2.MoveTowards(human.transform.position, newPos, humanSpeed * Time.deltaTime);

            if (human.transform.position == newPos)
            {
                humanMove = false;
            }
        }
        
        if (Input.GetKeyDown("left"))
        {
            moveLeft();
        }
        if (Input.GetKeyDown("right"))
        {
            moveRight();
        }

        transform.position = Vector2.MoveTowards(transform.position, moves[currentMove].position, moveSpeed * Time.deltaTime);

        gameManager.GetComponent<StartUp>().AddScore(1);
        score.text = StartUp.score.ToString();
    }

    void moveLeft()
    {

        oldMove = currentMove;
        if (!inBounds(currentMove - 1, moves))
        {
            currentMove = oldMove;
        }
        else
        {
            currentMove--;
        }

    }
    void moveRight()
    {
        oldMove = currentMove;
        if (!inBounds(currentMove + 1, moves))
        {
            currentMove = oldMove;
        }
        else
        {
            currentMove++;
        }
    }

    private bool inBounds(int index, Transform[] array)
    {
        return (index >= 0) && (index < array.Length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            //StartCoroutine(doFade());

            if(source.isPlaying)
            {
                source.Stop();
            }

            source.clip = effects[2];
            source.Play();
            //gameManager.audioSource.Play();
        }
        if(collision.name == "obTrigger")
        {
            if(Random.Range(0, 1) == 1)
            {
                source.clip = effects[1];
                source.Play();
            }
            else
            {
                source.clip = effects[0];
                source.Play();
            }

            
        }

    
    }

        


    

    IEnumerator doFade()
    {
        float a = 0;
        while(gameover.color.a < 1)
        {
            a += Time.deltaTime;
            gameover.color = new Color(gameover.color.r, gameover.color.g, gameover.color.b, a);
        }
        yield return null;
    }
}
