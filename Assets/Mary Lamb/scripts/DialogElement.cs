using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogElement : MonoBehaviour
{

    [TextArea(10,10)]public string elementText;
    public Text textElement;
    public Transform nextNode;

    public Text buttonText;

    

    public void RefreshText()
    {
        //keep telling the story!
        textElement.text = textElement.text + " " + elementText;
        
    }
    public void RefreshButton()
    {
        if(buttonText != null)
        {
            buttonText.text = elementText;
        }
        
    }
}

