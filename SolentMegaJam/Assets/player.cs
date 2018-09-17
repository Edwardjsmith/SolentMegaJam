using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float humanSpeed;
    public GameObject human;

    Transform middleMove;
    Transform rightMove;
    Transform leftMove;

    public Transform[] moves;
    public int spacing = -2;

    public int currentMove;

    float humanY;
	// Use this for initialization
	void Start ()
    {
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

        human.transform.position = Vector3.MoveTowards(human.transform.position, new Vector3(moves[currentMove].position.x, humanY,
            moves[currentMove].position.z), humanSpeed * Time.deltaTime);

        moveLeft();
        moveRight();
	}

    void moveLeft()
    {
        if(Input.GetKeyDown("left") && moves[currentMove - 1] != null )
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
        if (Input.GetKeyDown("right") && moves[currentMove + 1] != null)
        {
            currentMove++;
        }
        else
        {
            return;
        }
    }
}
