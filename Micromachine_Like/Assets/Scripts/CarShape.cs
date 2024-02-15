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
        _body = Instantiate(_profile.realModel, transform);

        _playerInput.SwitchCurrentControlScheme(setup.ControlScheme, setup.Devices);
    }
}