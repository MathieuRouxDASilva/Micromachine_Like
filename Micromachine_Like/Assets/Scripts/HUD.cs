using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{

    public UIDocument _uiDocument;
    
    
    // Start is called before the first frame update
    void Start()
    {
        VisualElement HUD = _uiDocument.rootVisualElement.Q("L");

        if (HUD != null)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
