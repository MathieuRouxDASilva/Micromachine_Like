using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarShape : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    [SerializeField] private PlayerInput _playerInput;
    private LobbyProfile _profile;


    public void SetProfile(LobbySetup setup)
    {
        //Shape shifting
        _profile = setup.Profile;
        Destroy(_body);
        _body = Instantiate(_profile.model, transform);

        _playerInput.SwitchCurrentControlScheme(setup.ControlScheme, setup.Devices);
    }
}