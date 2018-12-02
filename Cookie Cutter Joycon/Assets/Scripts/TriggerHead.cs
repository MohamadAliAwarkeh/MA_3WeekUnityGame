using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHead : MonoBehaviour 
{

    void OnTriggerStay2D(Collider2D theCol)
    {
        if (theCol.gameObject.CompareTag("SonObj"))
        {
            //Debug.Log("TEST");
        }
    }

}
