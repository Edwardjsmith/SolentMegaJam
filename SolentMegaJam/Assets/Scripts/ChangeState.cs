using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {
    public GameObject GameManager;
    private StartUp component;
    public eGamestates state; 
	// Use this for initialization
	void Start () {
        component = GameManager.GetComponent<StartUp>();
	}
	
	// Update is called once per frame
	public void changeState() {
        component.loadScene((int)state);
	}
}
