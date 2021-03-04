using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetroMovement : MonoBehaviour
{
    public float movingSpeed;
    public bool startMovement = false;
    public GameObject missile;
    
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
    }
    public void StartMovement()
    {
        startMovement = true;
    }    
}
