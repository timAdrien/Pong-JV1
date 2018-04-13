using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Variables

    #region Settings
    [SerializeField]
    private int winPointGoal = 10;

    public void SetWinPointGoal(int winPoint)
    {
        winPointGoal = winPoint;
    }
    #endregion

    #region Game
    [SerializeField]
    private GameObject playerStarting;
    public static bool ballInGame;

    [SerializeField]
    private AudioClip ballSound;
    [SerializeField]
    private AudioClip accelerateSound;
    [SerializeField]
    private AudioClip explosionSound;

    [SerializeField]
    private TextMeshPro leftScore;
    [SerializeField]
    private TextMeshPro rightScore;
    [SerializeField]
    private TextMeshProUGUI winnerText;
    [SerializeField]
    private GameObject winScreen;

    public static int leftScorePoint;
    public static int rightScorePoint;

    [SerializeField]
    private GameObject explodeEffect;

    public static bool canTriggerCollisionPlayer = true;
    public static bool gameEnded = false;

    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject playingBall;

    public GameObject PlayingBall
    {
        get
        {
            return playingBall;
        }

        set
        {
            playingBall = value;
        }
    }

    #endregion

    #endregion

    #region Méthodes Unity
    private void Start()
    {
        GameStartedSound();
        resetGame();
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log(GameObject.Find("GameSettings").GetComponent<GameSettings>().maxPointsToWin);
        SetWinPointGoal(GameObject.Find("GameSettings").GetComponent<GameSettings>().maxPointsToWin);
    }
    #endregion

    #region Méthodes ADDED

    public void resetGame()
    {
        leftScorePoint = 0;
        rightScorePoint = 0;
        ballInGame = false;
        gameEnded = false;
    }

    public void ThrowBall()
    {
        ballInGame = true;
        PlayingBall = Instantiate(ball);
    }

    public void GameStartedSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void BallHit()
    {
        GetComponent<AudioSource>().PlayOneShot(ballSound);
    }

    public void BallExplode()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionSound);
    }

    public void BallAccelerate()
    {
        GetComponent<AudioSource>().PlayOneShot(accelerateSound);
    }

    public void DestroyBall()
    {
        ballInGame = false;

        BallExplode();
        GameObject explosionGO = Instantiate(explodeEffect, PlayingBall.transform.position, PlayingBall.transform.rotation);

        Destroy(PlayingBall);
        Destroy(explosionGO, 3);

        if (!gameEnded)
        {
            ThrowBall();
        }
    }

    public void UpLeftScore()
    {
        int score = Int32.Parse(leftScore.text);
        score += 1;
        leftScore.text = score.ToString();
    }

    public void UpRightScore()
    {
        int score = Int32.Parse(rightScore.text);
        score += 1;
        rightScore.text = score.ToString();
    }

    public void UpScore(string side)
    {
        switch (side)
        {
            case "left":
                leftScorePoint += 1;
                UpLeftScore();
                break;
            case "right":
                rightScorePoint += 1;
                UpRightScore();
                break;
        }

        if (leftScorePoint >= winPointGoal)
        {
            AndTheWinnerIs("Bleu");
        }
        else if (rightScorePoint >= winPointGoal)
        {
            AndTheWinnerIs("Rouge");
        }
    }

    public void AndTheWinnerIs(string winnerColor)
    {
        gameEnded = true;
        winScreen.SetActive(true);
        winnerText.text = winnerColor;
        Destroy(playingBall);
        StartCoroutine(EndGameLoadMenu());
    }

    IEnumerator EndGameLoadMenu()
    {
        yield return new WaitForSeconds(5);
        DontDestroyOnLoad(GameObject.Find("GameSettings"));
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    #endregion

}
