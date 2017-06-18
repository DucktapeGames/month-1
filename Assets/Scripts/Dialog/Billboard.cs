using UnityEngine;
using System.Collections;
 
public class Billboard : MonoBehaviour {
    public Camera mainCamera;
 
    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }
}