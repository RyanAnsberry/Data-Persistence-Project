using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text PlayerNameInput;
    public Text HighScoreText;

    private void Start()
    {
        SetHighScore();
    }

    private void SetHighScore()
    {
        int highScore = PlayerDataManager.Instance.HighScore;
        string currentLeader = PlayerDataManager.Instance.CurrentLeader;
        HighScoreText.text = $"High Score : {currentLeader} : {highScore}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
        PlayerDataManager.Instance.PlayerName = PlayerNameInput.text;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
