using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().buildIndex == 4) {
            PlayerStats.resetStats();
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
