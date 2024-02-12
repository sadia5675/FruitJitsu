using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 newCameraPosition;
    public Vector3 newCameraRotation;
    Vector3 basePos,baseRot;

    Boolean isOnGameCamera = false;

    void Start()
    {
        basePos=Camera.main.transform.position;
        baseRot = Camera.main.transform.eulerAngles;
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(1))//rechte maustaste
        {
            
            if(!isOnGameCamera) {
                // Change camera position
            Camera.main.transform.position = newCameraPosition;

            // Change camera rotation
            Camera.main.transform.eulerAngles = newCameraRotation;
            isOnGameCamera = true;
            } else {
                 // Change camera position
            Camera.main.transform.position = basePos;

            // Change camera rotation
            Camera.main.transform.eulerAngles = baseRot;
            isOnGameCamera = false;
            }
            
        }
    }
}
