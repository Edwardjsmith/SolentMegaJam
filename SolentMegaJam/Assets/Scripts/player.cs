using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float humanSpeed;
    public GameObject human;

    GameObject gameManager;

    Transform middleMove;
    Transform rightMove;
    Transform leftMove;

    public Transform[] moves;
    public int spacing = -2;

    public int currentMove;
    int oldMove;

    float humanY;

    public Text score;

    public bool humanMove = false;

    public string lineSortingLayer;
    public int lineOrderInLayer;

    Vector3 newPos;

    LineRenderer lineRenderer;

    public GameObject collar;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("gameManager");
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
	void Update ()
    {
        lineRenderer.SetPosition(0, collar.transform.position);
        lineRenderer.SetPosition(1, human.transform.GetChild(0).transform.position);

        if (humanMove)
        {

            
                newPos = new Vector2(moves[currentMove].position.x, humanY);

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
        if(collision.GetComponent<obstacle>())
        {
            //gameManager.GetComponent<StartUp>().loadScene(2);
        }
        
    }
}
