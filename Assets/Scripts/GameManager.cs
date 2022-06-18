using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;
    private bool isPaused;
    public static GameManager Instance;

    private int pointCount;
    private int erroCount;
    private int lifeCount;

    private void Awake()
    {
        RestartScoreValue();
    }

    public void Start()
    {
        Instance = this;
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        isPaused = false;

        Score.Instance.StartScore();
    }

    #region Reset Score Value

    private void RestartScoreValue()
    {
        erroCount = 0;
        lifeCount = 7;
        pointCount = 0;
    }

    public int GetErroScoreValue()
    {
        return erroCount;
    }
    public int GetLifeScoreValue()
    {
        return lifeCount;
    }

    public int GetPointScoreValue()
    {
        return pointCount;
    }

    #endregion

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        isPaused = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    //    Spawner.Instance.DestroyOBJList();
    }

    public void ReloadLevel()
    {
        // need to reset variables/values lifes etc
        //destroy old objects
        EditorSceneManager.LoadScene(0);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        RestartScoreValue();
        Resume();
    }

    public void GoToMenu()
    {

    }

    public void NextLevel()
    {

    }

    /*
    public void gameStatus()
    {
        if (isGameRunning)
        {
            GameRun();
        }
        if (isGamePaused)
        {
            GamePause();
        }
        if (isGameEnd)
        {
            GameEnds();
        }
    } */

    public void GameRun()
    {
        Resume();
    }
    public void GamePause()
    {
        Pause();
    }

    public void GameStart()
    {

    }

    public void GameEnds()
    {

    }




}
