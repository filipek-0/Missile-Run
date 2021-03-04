using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform missile;
    [SerializeField] Transform beginningOfTheScene;
    [SerializeField] Transform endOfTheScene;
    
    [SerializeField] Vector3 offsetValue;
    [SerializeField] Vector3 offset;

    [SerializeField] MeshRenderer baseOfTheMissile;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = missile.position + offset;
    }

    // Update is called once per frame
    void Update()   
    {
        if(baseOfTheMissile.enabled == true)
        {
            transform.position = missile.position + offset;
            transform.LookAt(missile);
            ShowMap();
        }
        else
        {
            return;
        }
    }

    private void ShowMap()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Vector3 centerOftheScene;
            centerOftheScene = endOfTheScene.position / 2;
            Vector3 mapOffset;
            Vector3 offsetConstant = new Vector3();
            offsetConstant.z = -centerOftheScene.x;
            mapOffset = offsetConstant + offsetValue;
            print(mapOffset);
            transform.position = centerOftheScene + mapOffset;
            transform.LookAt(centerOftheScene);
        }
    }
}
