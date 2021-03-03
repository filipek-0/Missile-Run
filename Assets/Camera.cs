using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform missile;
    public Transform centerOfTheMap;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 mapOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = missile.position + offset;
    }

    // Update is called once per frame
    void Update()   
    {
        transform.position = missile.position + offset;
        transform.LookAt(missile);
        ShowMap();
    }

    private void ShowMap()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            transform.position = centerOfTheMap.position + mapOffset;
            transform.LookAt(centerOfTheMap);
        }
    }
}
