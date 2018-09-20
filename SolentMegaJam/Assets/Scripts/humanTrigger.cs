using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanTrigger : MonoBehaviour {

    public GameObject player;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.name == "Human")
        {
            GetComponentInParent<player>().humanMove = true;
            player.GetComponent<player>().newPos = new Vector2(player.GetComponent<player>().moves[player.GetComponent<player>().currentMove].position.x, player.GetComponent<player>().humanY);
        }
    }
    
}
