using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poteau : MonoBehaviour {



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().BallHit();
        }
    }
}
