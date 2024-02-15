using UnityEngine;

[CreateAssetMenu(menuName = "Data/LobbyProfile", fileName = "profile")]
public class LobbyProfile : ScriptableObject
{
    public GameObject model;
    //public Sprite modelSprite;
    public string name;
    public GameObject realModel;
}
