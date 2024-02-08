using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        List<LobbySetup> _setups = FindObjectsByType<LobbySetup>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .ToList();

        for (int i = 0; i < _setups.Count; i++)
        {
            GameObject newtractor = Instantiate(_prefab);

            if (newtractor.TryGetComponent<CarShape>(out var shape))
            {
                shape.SetProfile(_setups[i]);
            }
        }
    }
}