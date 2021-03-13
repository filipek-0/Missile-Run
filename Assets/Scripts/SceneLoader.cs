using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] float delay = 0.3f;
    public void Start()
    {
        controlsMenu.SetActive(false);
    }
    public void PlayButton()
    {
        Invoke("LoadGame", delay);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Invoke("QuitGame", delay);
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ControlsButton()
    {
        Invoke("LoadControlsMenu", delay);
    }

    private void LoadControlsMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void BackButton()
    {
        Invoke("LoadMainMenu", delay);
    }

    private void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    
}
