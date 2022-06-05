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

    public void Start()
    {
        Instance = this;
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        isPaused = false;
    }

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
    }

    public void ReloadLevel()
    {
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        Resume();
    }

    public void GoToMenu()
    {

    }

    public void NextLevel()
    {

    }




}
