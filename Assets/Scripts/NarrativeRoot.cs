using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NarrativeRoot : MonoBehaviour
{
    public Transform currentDecision;  //our current position in the tree    

    public void Choice(int index)   //index maps to the button that was pressed
    {                               //or some other mechanism that made a choice
        
        //set all children to false
        foreach (Transform t in currentDecision)
        {
            t.gameObject.SetActive(false);
        }
        //chose the branch assuming it exists
        if (currentDecision.childCount > index)
        {
            currentDecision.GetChild(index).gameObject.SetActive(true);
            currentDecision = currentDecision.GetChild(index);
        }
        else //if no children, check if the component has a "next" node re-entry point
        {
            DialogElement de = currentDecision.GetComponent<DialogElement>();

            if (de.nextNode)
            {
                de.nextNode.GetComponent<DialogElement>().RefreshText();
                currentDecision = de.nextNode;
                currentDecision.gameObject.SetActive(true);

            }

        }
        
    }
}
