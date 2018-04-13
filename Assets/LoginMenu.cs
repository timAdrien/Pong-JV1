using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviour {

    public InputField maxPointsToWin;

    public GameObject mainSide;
    public GameObject reglesMenu;
    public GameObject buttonsMenu;
    public GameObject optionsMenu;
    public GameObject gameSettings;

    private GameObject gameSettingsGO;

    public void Start()
    {
        if (GameObject.Find("GameSettings") == null)
        {
            gameSettingsGO = Instantiate(gameSettings);
            gameSettingsGO.name = "GameSettings";
        }
    }

    public void OnLevelWasLoaded(int level)
    {
        if (gameSettingsGO == null)
            gameSettingsGO = GameObject.Find("GameSettings");
    }

    public void Login_Play()
    {
        DontDestroyOnLoad(gameSettingsGO);
        SceneManager.LoadScene("PongScene", LoadSceneMode.Single);
    }

    public void Login_Quit()
    {
        Application.Quit();
    }

    public void Login_Options()
    {
        maxPointsToWin.text = gameSettingsGO.GetComponent<GameSettings>().maxPointsToWin.ToString();
        buttonsMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Login_Options_ChangePointsToWin()
    {
        gameSettingsGO.GetComponent<GameSettings>().maxPointsToWin = int.Parse(maxPointsToWin.text);
    }

    public void Login_Options_Back()
    {
        buttonsMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Login_Regles()
    {
        mainSide.SetActive(false);
        reglesMenu.SetActive(true);
    }

    public void Login_Regles_Back()
    {
        mainSide.SetActive(true);
        reglesMenu.SetActive(false);
    }
}