using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().BallAccelerate();
            Vector3 vel = collision.gameObject.GetComponent<Rigidbody>().velocity;
            if (transform.name == "WallRight")
            {
                if (vel.z > 0)
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-4, 0, 4), ForceMode.VelocityChange);
                else
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(4, 0, -4), ForceMode.VelocityChange);
            }
            else
            {
                if (vel.z > 0)
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(4, 0, 4), ForceMode.VelocityChange);
                else
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-4, 0, -4), ForceMode.VelocityChange);
            }
        }
    }
}
