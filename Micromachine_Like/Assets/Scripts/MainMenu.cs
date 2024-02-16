using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    [Header("doc")]
    public UIDocument uiDocument;

    private Button _startButton;
    private Button _quitButton;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        VisualElement Menu = uiDocument.rootVisualElement.Q("Menu");

        if ( Menu != null)
        {
           _startButton = Menu.Q<Button>("Start");
           _startButton?.RegisterCallback<ClickEvent>(LoadGame);

           _quitButton = Menu.Q<Button>("Quit");
           _quitButton?.RegisterCallback<ClickEvent>(EndGame);
        }
    }

    private void OnDisable()
    {
        _startButton?.RegisterCallback<ClickEvent>(LoadGame);
        
    }


    private void LoadGame(ClickEvent evnt)
    {
        Debug.Log("load");
        SceneManager.LoadScene("Lobby");
    }


    private void EndGame(ClickEvent evnt)
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        
        Application.Quit();
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
