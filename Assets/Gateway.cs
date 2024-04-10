using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter emitter;

    public NarrativeRoot narrativeRoot;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player trigger enter" + transform.name);
            narrativeRoot.Choice(index);
            StartCoroutine(Countdown(0.25f));

        }
    }
    IEnumerator Countdown(float time)
    {
        Debug.Log("countdown");
        yield return new WaitForSeconds(time);
        emitter.SetParameter("Parameter" + index, 0);
    }
}
