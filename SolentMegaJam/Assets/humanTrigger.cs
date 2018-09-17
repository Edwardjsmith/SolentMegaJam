using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanTrigger : MonoBehaviour {


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.name == "Human")
        {
            GetComponentInParent<player>().humanMove = true;
        }
    }
    
}
