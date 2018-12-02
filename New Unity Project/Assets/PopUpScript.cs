using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;

public class PopUpScript : MonoBehaviour {

    public GameObject popUp;

	void Start () 
    {
		
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            popUp.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            popUp.SetActive(false);
        }
    }
}
