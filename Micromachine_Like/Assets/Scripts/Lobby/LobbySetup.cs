using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbySetup : MonoBehaviour
{

    [SerializeField] private List<LobbyProfile> _profile = new List<LobbyProfile>();
    [SerializeField] private GameObject _body;

    public Action OnReady;
    
    private int _playerIndex;
    private string controlScheme;
    private InputDevice[] devices;
    
    //input system for lobby
    public int _modelIndex;
    private bool _ready = false;
    public bool Ready => _ready;
    public LobbyProfile Profile => _profile[_modelIndex];
    public string ControlScheme => controlScheme;
    public InputDevice[] Devices => devices;

    private void Start()
    {
        LoadNewModel();
    }
    private void OnChange(InputValue value)
    {
        float v = value.Get<float>();
        if (Mathf.Abs(v) == 1f)
        {
            _modelIndex += Mathf.FloorToInt(v);

            if (_modelIndex < 0)
            {
                _modelIndex = _profile.Count - 1;
            }
            else if(_modelIndex >= _profile.Count)
            {
                _modelIndex = 0;
            }
        }
        
        LoadNewModel();
    }

    private void OnConfirm(InputValue value)
    {
        _ready = true;
        OnReady?.Invoke();
    }
    
    private void LoadNewModel()
    {
        Destroy(_body);
        _body = Instantiate(_profile[_modelIndex].model, transform);
        Debug.Log("instanciate" + _body);
    }

    public void BindInput(PlayerInput input)
    {
        //setup variables
        _playerIndex = input.playerIndex;
        controlScheme = input.currentControlScheme;
        devices = input.devices.ToArray();
    }
    
}
