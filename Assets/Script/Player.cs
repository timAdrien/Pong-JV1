using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{

    public int points = 0;
    public bool isFrontPlayer;

    private KeyCode Gauche;
    private KeyCode Droite;


    void Update()
    {
        if (!GameManager.gameEnded)
        {
            if (!GameManager.ballInGame && Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().ThrowBall();
            }

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (isFrontPlayer)
            {
                Gauche = KeyCode.Q;
                Droite = KeyCode.D;
            }
            else
            {
                Gauche = KeyCode.LeftArrow;
                Droite = KeyCode.RightArrow;
            }

            if (Input.GetKey(Droite))
            {
                Vector3 v = gameObject.transform.position;
                v.x += (float)0.2;
                if (v.x < 4)
                    gameObject.GetComponent<Rigidbody>().MovePosition(v);
            }

            if (Input.GetKey(Gauche))
            {
                Vector3 v = gameObject.transform.position;
                v.x -= (float)0.2;
                if (v.x > -4)
                    gameObject.GetComponent<Rigidbody>().MovePosition(v);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball" && GameManager.canTriggerCollisionPlayer)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().BallHit();
            GameManager.canTriggerCollisionPlayer = false;
            Debug.Log(collision.contacts[0].thisCollider.name);

            Vector3 velocityBall = collision.gameObject.GetComponent<Rigidbody>().velocity;


            GameObject.Find("GameManager").GetComponent<GameManager>().PlayingBall.GetComponent<BouncyBall>().Z1 += .5f;
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayingBall.GetComponent<BouncyBall>().X1 += .5f;

            float Z = GameObject.Find("GameManager").GetComponent<GameManager>().PlayingBall.GetComponent<BouncyBall>().Z1;
            float X = GameObject.Find("GameManager").GetComponent<GameManager>().PlayingBall.GetComponent<BouncyBall>().X1;

            //Z *= -1;

            //if (collision.contacts[0].thisCollider.name == "Left" && X > 0)
            //{
            //        X *= -1;
            //}

            //if (collision.contacts[0].thisCollider.name == "Right" && X < 0)
            //{
            //    X *= -1;
            //}

            //collision.gameObject.GetComponent<BouncyBall>().X1 = X;
            //collision.gameObject.GetComponent<BouncyBall>().Z1 = Z;

            //collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(X, 0, Z);

            switch (collision.contacts[0].thisCollider.name)
            {
                case "RightBlue":
                    collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-X, 0, -Z);
                    break;
                case "MiddleBlue":
                    //collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(X, 0, Z);
                    break;
                case "LeftBlue":
                    collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(X, 0, -Z);
                    break;
                case "RightRed":
                    collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(X, 0, Z);
                    break;
                case "MiddleRed":
                    //collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(X, 0, Z);
                    break;
                case "LeftRed":
                    collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-X, 0, Z);
                    break;
            }
            //velocityBall = collision.gameObject.GetComponent<Rigidbody>().velocity;
            //Debug.Log(velocityBall);
            //gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(X, 0, Z), ForceMode.Impulse);
            StartCoroutine(WaitSomeTime(.3f));
        }
    }

    public IEnumerator WaitSomeTime(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.canTriggerCollisionPlayer = true;
    }
}
