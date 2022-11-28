using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public TextMeshProUGUI levelText;

    public void BackToMenu() 
    {
        Time.timeScale = 1f;
        PlayerStats.resetStats();
        LevelStartText.level = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Restart() {
        Resume();
        LevelStartText.level = 1;
        PlayerStats.resetStats();
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
