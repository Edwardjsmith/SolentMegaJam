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


    Vector3 newPos;

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
        human.transform.position = new Vector3(moves[currentMove].position.x, humanY, moves[currentMove].position.z);



    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, moves[currentMove].position, moveSpeed * Time.deltaTime);

        if (humanMove)
        {

            
                newPos = new Vector3(moves[currentMove].position.x, humanY,
                moves[currentMove].position.z);

                human.transform.position = Vector3.MoveTowards(human.transform.position, newPos, humanSpeed * Time.deltaTime);

                if (human.transform.position == newPos)
                {
                    humanMove = false;
                }
            

        }

        moveLeft();
        moveRight();

        gameManager.GetComponent<StartUp>().AddScore(1);
        score.text = gameManager.GetComponent<StartUp>().score.ToString();
    }

    void moveLeft()
    {
        oldMove = currentMove;
        if (Input.GetKeyDown("left") && moves[currentMove - 1] != null )
        {
            currentMove--;
        }
        else
        {
            return;
        }
       
    }
    void moveRight()
    {
        oldMove = currentMove;
        if (Input.GetKeyDown("right") && moves[currentMove + 1] != null)
        {
            currentMove++;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<obstacle>())
        {
            //gameManager.GetComponent<StartUp>().loadScene(2);
        }
        
    }
}
