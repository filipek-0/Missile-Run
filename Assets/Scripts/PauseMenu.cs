using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject ControlsMenu;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float delay = 0.3f;

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
        audioSource.Play();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
    }
    public void ResumeGame()
    {
        audioSource.Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }
    public void MenuButton()
    {
        audioSource.Play();
        Time.timeScale = 1f;
        Invoke("LoadMenuFromPause", delay);
    }
    private void LoadMenuFromPause()
    {
        SceneManager.LoadScene(0);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitButton()
    {
        audioSource.Play();
        Time.timeScale = 1f;
        Invoke("QuitGameFromPause", delay);
    }
    private void QuitGameFromPause()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void ControlsButton()
    {
        audioSource.Play();
    }
}
