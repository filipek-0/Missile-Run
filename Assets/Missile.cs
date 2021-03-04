using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Missile : MonoBehaviour
{
    public Rigidbody rigidBody;
    public AudioSource audioSource;
    [SerializeField] float thrustForce = 20f;
    [SerializeField] float rotationForce = 1f;
    [SerializeField] float waitingTime = 2f;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] AudioClip explodeSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem explodeParticle;
    [SerializeField] ParticleSystem winParticle;
    [SerializeField] MeshRenderer baseOfTheMissile;
    [SerializeField] MeshRenderer coneOfTheMissile;

    enum State {Alive, Exploding, Winning};
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.GetComponent<Rigidbody>();
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RespondToInput();
    }

    private void RespondToInput()
    {
        if (state == State.Alive)
        {
            Movement();
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        else
        {
            audioSource.Stop();
            thrustParticle.Stop();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotationForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -rotationForce * Time.deltaTime);
        }
    }

    private void Thrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime); 
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSound);
        }
        thrustParticle.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                Win();
                break;
            default:
                Explode();
                break;
        }
    }
    
    private void Explode()
    {
        state = State.Exploding;
        baseOfTheMissile.enabled = false;
        coneOfTheMissile.enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(explodeSound);
        thrustParticle.Stop();
        explodeParticle.Play();
        rigidBody.constraints = RigidbodyConstraints.None;
        Invoke("ReloadLevel", waitingTime);
    }

    private void Win()
    {
        state = State.Winning;
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        thrustParticle.Stop();
        winParticle.Play();
        Invoke("NextLevel", waitingTime);
    }

    private void ReloadLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void NextLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        var nextScene = currentScene.buildIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(nextScene);
    }
}
