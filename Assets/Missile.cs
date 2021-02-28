using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour
{
    public Rigidbody rigidbody;
    [SerializeField] float thrustForce = 20f;
    [SerializeField] float rotationForce = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotationForce);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -rotationForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var currentScene = SceneManager.GetActiveScene();
        var nextScene = currentScene.buildIndex + 1;
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly.");
                break;
            case "Finish":
                
                if (nextScene == SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(0);
                }
                SceneManager.LoadScene(nextScene);
                break;
            default:
                SceneManager.LoadScene(currentScene.buildIndex);
                break;
        }
    }
}
