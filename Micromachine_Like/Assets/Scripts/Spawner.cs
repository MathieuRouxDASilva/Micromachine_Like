using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        List<LobbySetup> _setup = FindObjectsByType<LobbySetup>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .ToList();

        for (int i = 0; i < _setup.Count; i++)
        {
            GameObject newtractor = Instantiate(_prefab);

            if (newtractor.TryGetComponent<CarShape>(out var shape))
            {
                shape.SetProfile(_setup[i]);
            }
        }
    }


    public void OnPlayerJoined(PlayerInput input)
    {
        Debug.Log("olololololololol");
    }
}