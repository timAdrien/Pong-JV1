using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkLobbyManager {


    float countTimer = 0;

    public override void OnLobbyServerPlayersReady()
    {
        Debug.Log("INSTANTITATEEE");
    }

    void Update()
    {
        if (countTimer == 0)
            return;

        if (Time.time > countTimer)
        {
            countTimer = 0;
            ServerChangeScene(playScene);
        }
        else
        {
            Debug.Log("Counting down " + (countTimer - Time.time));
        }
    }
}
