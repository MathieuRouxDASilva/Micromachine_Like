using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbySetup : MonoBehaviour
{

    [SerializeField] private List<LobbyProfile> _profile;
    
    private int _playerIndex;
    private string _controlScheme;
    private InputDevice[] _devices;
    
    //input system for lobby
    public int _modelIndex;
    public bool _ready = false;
    
    
    public void BindInput(PlayerInput input)
    {
        //setup variables
        _playerIndex = input.playerIndex;
        _controlScheme = input.currentControlScheme;
        _devices = input.devices.ToArray();
    }

    void OnChange(InputValue value)
    {
        float v = value.Get<float>();
        if (v == 0f)
        {
            return;
        }

        _modelIndex += (int)v;
        
    }

    void OnSelect(InputValue value)
    {
        _ready = true;
    }
    
}
