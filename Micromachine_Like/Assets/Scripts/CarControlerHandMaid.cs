using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CarControlerHandMaid : MonoBehaviour
{
    //moving
    public float isMovingForward = 0f;
    public float maxAcceleration = 30.0f;
    
    //brake/turn
    public float brakeAcceleration = 50.0f;
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;
    public float isTurningRight = 0f;
    public float _isBraking;
    
    //player input stuff
    private float _moveinput;
    private float _steerInput;
    
    //else(public)
    public List<Wheel> wheels;
    public Vector3 centerofMass;
    
    //else(private)
    private Rigidbody _carRb;
    

    //functions that refers to player input
    public void OnMoveForward(InputValue value)
    {
        isMovingForward = value.Get<float>();
    }
    public void OnTurnRight(InputValue value)
    {
        isTurningRight = value.Get<float>();
    }
    public void OnBrake(InputValue value)
    {
        _isBraking = value.Get<float>();
    }

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    //start
    private void Start()
    {
        _carRb = GetComponent<Rigidbody>();
        _carRb.centerOfMass = centerofMass;
    }

    //late update
    private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    //update
    private void Update()
    {
        GetInput();
        AnimateWheels();
    }

    //get inputs
    void GetInput()
    {
        _moveinput = isMovingForward;
        _steerInput = isTurningRight;
    }

    //function that make you move
    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = _moveinput * maxAcceleration * Time.deltaTime * 30;
        }
    }

    //function that makes you turn
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = _steerInput * maxSteerAngle * turnSensitivity;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    //function that animates the wheels
    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
    
    //function that do brake
    void Brake()
    {
        if (_isBraking > 0)
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }
}