using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogElement : MonoBehaviour
{

    public string elementText;
    public Text textElement;
    
    
    private void OnEnable()
    {
        textElement.text = elementText;
    }
    private void OnDisable()
    {
        
    }
}

