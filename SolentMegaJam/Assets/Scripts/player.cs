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
    int humanPos;
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

    float oneSec = 1.0f;

  
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

        gameover.gameObject.SetActive(false);
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
        lineRenderer.widthMultiplier = 0.1f;

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
            human.transform.position = Vector2.MoveTowards(human.transform.position, newPos, humanSpeed * Time.deltaTime);

            if (Mathf.Abs(humanPos - currentMove) >= 1)
            {
                newPos = new Vector2(moves[currentMove].position.x, humanY);
            }

            if (human.transform.position == newPos)
            {
                humanMove = false;
                humanPos = currentMove;
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

        if (oneSec <= 0)
        {
            gameManager.GetComponent<StartUp>().AddScore(100);
            oneSec = 1.0f;
        }
        oneSec -= Time.deltaTime;

        score.text = "Score: " + StartUp.score.ToString();

        

     
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
            gameManager.audioSource.Stop();
            
            PlayerPrefs.SetInt("NewScore", StartUp.score);//insert new score
            Time.timeScale = 0;
            gameover.gameObject.SetActive(true);

            

        }
        if (collision.name == "obTrigger")
        {
            if(Random.Range(0, 2) == 1)
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
    

    

 
}
