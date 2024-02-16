using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSetupp : MonoBehaviour
{
    [SerializeField] private GameObject LosePanel;

    private void OnTriggerEnter(Collider other)
    {
            LosePanel.SetActive(true);
            Time.timeScale = 0f;
    }
    
}
