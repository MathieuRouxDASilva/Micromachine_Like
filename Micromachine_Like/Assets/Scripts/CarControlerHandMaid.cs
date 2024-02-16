using UnityEngine;
using System;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
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
    public float isBraking;

    //player input stuff
    private float _moveinput;
    private float _steerInput;

    //else(public)
    public List<Wheel> wheels;
    public Vector3 centerofMass;
    
    //else(private)
    private Rigidbody _carRb;
    public BonusManager bonus;

    //Bonus input
    private float _isUsing = 0;
    private bool _usingBonus = false;
    public float _timer = 3;

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
        isBraking = value.Get<float>();
    }

    public void OnUseItem(InputValue value)
    {
        _isUsing = value.Get<float>();
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
        bonus = GameObject.Find("Boost").GetComponent<BonusManager>();
    }

    //late update
    private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
        UseBonus();
    }

    //update
    private void Update()
    {
        GetInput();
        AnimateWheels();
        SplitCamera();
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
            if (_usingBonus)
            {
                wheel.wheelCollider.motorTorque = _moveinput * maxAcceleration * Time.deltaTime * 30 * 2;
            }
            else
            {
                wheel.wheelCollider.motorTorque = _moveinput * maxAcceleration * Time.deltaTime * 30;
            }
        }
    }

    //function that makes you turn
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var steerAngle = _steerInput * maxSteerAngle * turnSensitivity;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngle, 0.6f);
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
        if (isBraking > 0)
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


    void UseBonus()
    {
        //for first bonus (speed boost)
        if (bonus.bonusIndex == 1 && _isUsing > 0)
        {
            _usingBonus = true;
            bonus.bonusIndex = 0;
        }

        if (_usingBonus)
        {
            _timer -= 1 * Time.deltaTime;
            if (_timer <= 0)
            {
                _usingBonus = false;
                _timer = 3f;
            }
        }
    }

    //get the player camera
    public int cameraNumber;

    //get the two cinemachine virtual camera
    public CinemachineVirtualCamera backCamera;

//set the layer of both the virtual camera depending on the player
    void SplitCamera()
    {
        backCamera.gameObject.layer = LayerMask.NameToLayer("CamPlayer" + (cameraNumber + 1));
    }
}