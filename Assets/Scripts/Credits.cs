using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float delay = 0.3f;

    public void MenuButton()
    {
        audioSource.Play();
        Invoke("LoadMenu", delay);
    }
    
    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        audioSource.Play();
        Invoke("QuitGame", delay);
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");  
    }
}
