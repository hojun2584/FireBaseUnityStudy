using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CameraController : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    [SerializeField]
    Transform targetTrans;
    

    public void Awake()
    {
        camera = GetComponent<Camera>();
    }

    Vector3 GetDirection( Vector3 targetPos)
    {
        return targetPos - transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        camera.transform.LookAt( targetTrans );
    }
}
