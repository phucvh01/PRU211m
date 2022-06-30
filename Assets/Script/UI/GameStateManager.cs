using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winGameState;
    public GameObject loseGameState;
    public GameObject pauseGameState;
    public static bool isLost=false;
    public static bool isPause;

    private void Awake()
    {
        isLost = false;
        Debug.Log("have replay");
        loseGameState.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLost == true)
        {
            loseGameState.SetActive(true);
        }
    }
    public void ReplayGame()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        //does static carry out?
        //isLost = false;
        SceneManager.LoadScene("EndlessLevel");
        

    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
