using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPopUp : MonoBehaviour
{

    public GameObject controlPopUp;
    public GameObject mainMenu;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            controlPopUp.SetActive(true);
            mainMenu.SetActive(false);
        }
	}
}
