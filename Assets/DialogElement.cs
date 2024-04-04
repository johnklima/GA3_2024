using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogElement : MonoBehaviour
{

    public string elementText;
    public Text textElement;
    public Transform nextNode;


    private void OnEnable()
    {
        RefreshText();
    }
    private void OnDisable()
    {
        
    }

    public void RefreshText()
    {
        textElement.text = elementText;
    }
}

