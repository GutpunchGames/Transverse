using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{

    [SerializeField]
    private Vector3 maxSpeed = Vector3.up;

    [SerializeField]
    private float oscillateSpeed = 1;

    void Update()
    {
        Vector3 velocity = (maxSpeed * Mathf.Sin(Time.fixedTime * oscillateSpeed));
        this.transform.position = this.transform.position + velocity * Time.deltaTime;
    }
}
