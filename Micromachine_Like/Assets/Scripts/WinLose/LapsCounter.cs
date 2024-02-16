using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LapsCounter : MonoBehaviour
{
    public int LapCount = 0;
    [SerializeField] private GameObject WinPanel;
    public TextMeshProUGUI LapCounter;
    private void OnTriggerEnter(Collider other)
    {
        if (LapCount == 2)
        {
            WinPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LapCount++;
        LapCounter.text = LapCount.ToString();
    }
}
