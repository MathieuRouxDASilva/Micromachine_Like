using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class BonusManager : MonoBehaviour
{
    //wich bonus you get
    public int bonusIndex = 0;
    //all icons
    [SerializeField] private GameObject iconNb1;
    
    //how it work : you get random bonus and set right icon active
    private void OnTriggerEnter(Collider other)
    {
        bonusIndex = 1;
        iconNb1.SetActive(true);
    }

    //if no bonus then no icon
    private void Update()
    {
        if (bonusIndex == 0)
        {
            iconNb1.SetActive(false);
        }
    }
}