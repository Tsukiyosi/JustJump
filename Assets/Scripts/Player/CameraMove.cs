using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    #region Variables
    [SerializeField] [Range (3f, 200f)]float mouseSensetivity;
    [SerializeField] GameObject body;
  
    [SerializeField] GameObject head;
    private float xRotation = 0;
    private float yRotation = 0;
   
    private float eulerY = 0;
    private float eulerX = 0;

    private bool isPaused = false;
    #endregion


    #region Mononbehaviour CallBacks
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!isPaused) {
            xRotation = mouseSensetivity * Input.GetAxis("Mouse X") * Time.deltaTime;
            yRotation = mouseSensetivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

            eulerX += xRotation;
            eulerY -= yRotation;
            eulerY = Mathf.Clamp(eulerY, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(eulerY, eulerX, 0f);
            head.transform.rotation = Quaternion.Euler(xRotation, eulerY, 0f);
            body.transform.localRotation = Quaternion.Euler(0f , eulerX, 0f);

        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused){
                isPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else{
                isPaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
            
    }
    #endregion
}
