using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonFollow : MonoBehaviour
{

    public Transform son;

    void Start()
    {
        this.transform.position = son.position;
    }

    void Update()
    {
        this.transform.position = son.position;
    }
}
