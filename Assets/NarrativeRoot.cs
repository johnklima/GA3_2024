using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NarrativeRoot : MonoBehaviour
{
    public GameObject currentDecision;
    
    
    public void ChoiceA()
    {
        currentDecision.transform.GetChild(1).gameObject.SetActive(false);
        currentDecision.transform.GetChild(0).gameObject.SetActive(true);
        currentDecision = currentDecision.transform.GetChild(0).gameObject;
    }

    public void ChoiceB()
    {
        currentDecision.transform.GetChild(0).gameObject.SetActive(false);
        currentDecision.transform.GetChild(1).gameObject.SetActive(true);
        currentDecision = currentDecision.transform.GetChild(1).gameObject;

    }

}
