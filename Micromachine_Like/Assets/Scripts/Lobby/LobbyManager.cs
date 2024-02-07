using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    //list of all joined player
    [SerializeField] private List<LobbySetup> _joinedSetups = new List<LobbySetup>();
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    
    //what happen when someone join this game 
    public void OnPlayerjoined(PlayerInput input)
    {
        Debug.Log(input.playerIndex + input.gameObject.name + input.currentControlScheme + input.devices);

        //make a list of vehicules and ready system
        if (input.gameObject.TryGetComponent<LobbySetup>(out var setup))
        {
            
            setup.transform.position = _spawnPoints[input.playerIndex].position;
            
            setup.BindInput(input);
            
            setup.OnReady += CheckEveryonIsReady;
            
            _joinedSetups.Add(setup);
            
           
            DontDestroyOnLoad(setup);
            Debug.Log("1");
        }
    }

    private void CheckEveryonIsReady()
    {
        //check if ther is at leat a single player in game
        if (_joinedSetups.Count < 1)
        {
            return;
        }

        //check if everyone is ready
        bool everyoneIsReady = true;
        foreach (LobbySetup setup in _joinedSetups)
        {
            if (!setup.Ready)
            {
                everyoneIsReady = false;
            }
        }

        //if everybody ready -> launch game
        if (everyoneIsReady)
        {
            foreach (LobbySetup setup in _joinedSetups)
            {
                setup.gameObject.SetActive(false);
            }
            SceneManager.LoadScene("manager");
        }
    }
    
}
