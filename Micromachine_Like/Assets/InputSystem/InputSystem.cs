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
    
    
    //input system
    
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
