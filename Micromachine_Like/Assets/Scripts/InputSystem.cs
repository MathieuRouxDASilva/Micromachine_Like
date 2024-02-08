using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public float IsMovingForward = 0f;
    public float IsMovingBackward = 0f;
    public float IsTurningLeft = 0f;
    public float IsTurningRight = 0f;
    [SerializeField] private Rigidbody _rb;

    private int s = 400;
    //input system


    private void Update()
    {
        _rb.velocity += Vector3.forward * (IsMovingForward * Time.deltaTime * 50);
        _rb.velocity += Vector3.right * IsTurningRight;
        
        
        
    }

    public void OnMoveForward(InputValue value)
    {
        IsMovingForward = value.Get<float>();
    }
    private void OnMoveBackward(InputValue value)
    {
        IsMovingBackward = value.Get<float>();
    }
    private void OnTurnLeft(InputValue value)
    {
        IsTurningLeft = value.Get<float>();
    }
    private void OnTurnRight(InputValue value)
    {
        IsTurningRight = value.Get<float>();
    }
    
}
