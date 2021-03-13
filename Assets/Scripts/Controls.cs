using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float delay = 0.3f;
    public void ContinueButton()
    {
        audioSource.Play();
        Invoke("Continue", delay);
    }
    
    private void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
