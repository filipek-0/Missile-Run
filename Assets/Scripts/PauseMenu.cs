using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject ControlsMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        gameIsPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
                ControlsMenu.SetActive(false);
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }
    public void LoadMenuFromPause()
    {
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGamefromPause()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
