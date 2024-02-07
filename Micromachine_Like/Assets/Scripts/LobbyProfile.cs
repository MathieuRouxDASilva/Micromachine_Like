using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Data/LobbyProfile", fileName = "profile")]
public class LobbyProfile : ScriptableObject
{
    public GameObject model;
    public Sprite modelSprite;
    public string name;
}
