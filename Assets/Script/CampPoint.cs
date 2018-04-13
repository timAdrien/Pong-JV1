using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CampPoint : MonoBehaviour { 

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            if (this.name == "CampJoueur1")
                GameObject.Find("GameManager").GetComponent<GameManager>().UpScore("right");
            else
                GameObject.Find("GameManager").GetComponent<GameManager>().UpScore("left");

            GameObject.Find("GameManager").GetComponent<GameManager>().DestroyBall();
        }
    }
}
