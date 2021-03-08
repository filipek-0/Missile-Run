using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroMovement : MonoBehaviour
{
    public float movingSpeed;
    public bool startMovement = false;
    public bool destroyMetro = false;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (startMovement == true)
        {
            transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
        }
        if (destroyMetro == true)
        {
            GameObject.Destroy(gameObject);
            return;
        }
    }
    public void StartMovement()
    {
        startMovement = true;
    }

    public void StopMovement()
    {
        destroyMetro = true;
    }
}
