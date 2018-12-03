using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{

    public float controlTime;

    private Canvas canvas;
    private float maxTime = 0;

    void Start()
    {
        canvas = this.GetComponent<Canvas>(); 
    }

    void Update ()
    {
        controlTime -= Time.deltaTime;
        if (controlTime <= maxTime)
        {
            canvas.enabled = false;
        }
	}
}
