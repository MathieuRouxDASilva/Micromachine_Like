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
        
        //add a new culling mask depending on wich car it is
        _playerInput.camera.cullingMask |= 1 << LayerMask.NameToLayer("CamPlayer" + (setup._playerIndex + 1));

        //get each player and set they player index
        CarControlerHandMaid carController = _body.GetComponent<CarControlerHandMaid>();
        carController.cameraNumber = setup._playerIndex;
    }
}