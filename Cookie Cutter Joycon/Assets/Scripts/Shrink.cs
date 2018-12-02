﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Shrink : MonoBehaviour
{
	[Range(0, 30)]public float shrinkTime;
    [HideInInspector]
	public PlayerRedController playerRedController;
    private float maxTime = 0;
	
	
	
	void Update () 
	{
		//Shrinks object down by 0.01f and destroys it
		transform.localScale -= (new Vector3(0.01f, 0.01f, 0f) * Time.deltaTime);
		shrinkTime -= Time.deltaTime;
		if (shrinkTime <= maxTime)
        {
            playerRedController.numOfMasksSpawnable++;
            Destroy(gameObject);
		}
		
	}
}
