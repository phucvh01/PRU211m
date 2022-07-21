using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPause = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
          
        

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        if (GameIsPause == false) 
        { 
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        }
        else
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPause = false;
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu.....");
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game .....");
        Application.Quit();
    }

}
