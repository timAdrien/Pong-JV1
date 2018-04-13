using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{

    [SerializeField]
    private Vector3 initialImpulse;
    [SerializeField]
    private Vector3 velocity;

    private float Z;
    private float X;

    public float Z1
    {
        get
        {
            return Z;
        }

        set
        {
            Z = value;
        }
    }

    public float X1
    {
        get
        {
            return X;
        }

        set
        {
            X = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        X1 = Random.Range(-3, 3);
        Z1 = 5;

        X1 *= (Random.value < 0.5) ? 1 : -1;
        Z1 *= (Random.value < 0.5) ? 1 : -1;

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(X1, 0, Z1);

        gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(X1, 0, Z1), ForceMode.Impulse);
    }

    private void Update()
    {
        Vector3 velocityBall = GetComponent<Rigidbody>().velocity;
        float Z = velocityBall.z;
        float X = velocityBall.x;

        // Angle Minimum (Pour éviter balle infini)
        if (X <= 0.5 && X >= -0.5)
            X = 1;

        // Vitesse min
        if (Z <= 3 && Z >= -3)
        {
            if (Z > 0)
            {
                Z = 5;
            }
            else
            {
                Z = -5;
            }
        }

        GetComponent<Rigidbody>().velocity = new Vector3(X, 0, Z);
        GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(X, 0, Z), ForceMode.Impulse);
    }
}
