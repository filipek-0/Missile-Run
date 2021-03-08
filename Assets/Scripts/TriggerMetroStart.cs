using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMetroStart : MonoBehaviour
{
    public MetroMovement metroMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        metroMovement.GetComponent<MetroMovement>().StartMovement();
    }
}
