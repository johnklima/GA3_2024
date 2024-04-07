using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* This module handles dialog tree behaviour. To enable re-entrant dialog, the DialogElement
 * has an additional reference, which one could imagine as just another child empty in the
 * scene graph. As a scene graphic is "acyclic" we need to provide an "out point" to somewhere else
 * in the scene graph, thus making a DAG into DCG 
 * (Directed Acyclic Graph, into a Directed Cyclic Graph."
*/

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
            DialogElement de = currentDecision.GetComponent<DialogElement>();
            de.RefreshText();
        }
        else
        //if no children, check if the component has a "next" node re-entry point
        //which is the equavalent to having one more child
        {
            DialogElement de = currentDecision.GetComponent<DialogElement>();

            //does this have a "re-entrant" child node?
            if (de.nextNode)
            {
                de.nextNode.GetComponent<DialogElement>().RefreshText();
                currentDecision = de.nextNode;
                currentDecision.gameObject.SetActive(true);

            }

        }
        
    }
}
