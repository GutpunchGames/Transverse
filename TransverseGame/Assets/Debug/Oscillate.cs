using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveSpeed = Vector3.up;

    [SerializeField]
    private float oscillationSpeed = 1;

    void Update()
    {
        Vector3 velocity = moveSpeed * Mathf.Sin(Time.timeSinceLevelLoad * oscillationSpeed);
        this.transform.position += velocity * Time.deltaTime;
    }
}
