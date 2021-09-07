using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour 
{
    public Transform TargetTransform;
    private float _speed = 3;

    // Update is called once per frame
    void Update() 
    {
        Rotate();
        Chase();
    }

    private void Chase() 
    {
        Vector3 displacementFromTarget = TargetTransform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * _speed;

        if (displacementFromTarget.magnitude > 1.5) 
        {
            transform.Translate(velocity * Time.deltaTime, Space.World);
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 1000, Space.World); 
    }
}
