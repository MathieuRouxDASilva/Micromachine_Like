using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyManager : MonoBehaviour
{
    public void OnPlayerjoined(PlayerInput input)
    {
        Debug.Log(input.playerIndex + input.gameObject.name + input.currentControlScheme + input.devices);


        if (input.gameObject.TryGetComponent<LobbySetup>(out var setup))
        {
            setup.BindInput(input);
        }
    }
}
