using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchManager : MonoBehaviour
{
    #region Variables
    [SerializeField] public Transform l_Cathcher;
    [SerializeField] public Transform r_Cathcher;
    private GameObject catchableObj;

    private bool isCatchable;
    #endregion
    
    #region Monobehaviour CallBacks
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isCatchable){
            l_Cathcher.position = catchableObj.transform.position;
            r_Cathcher.position = catchableObj.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Catchable")){
            isCatchable = true;
            catchableObj = other.gameObject;
        }
            
        else {
            isCatchable = false;
        }
    }

    #endregion
}
