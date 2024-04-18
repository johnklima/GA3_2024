using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Footsteps : MonoBehaviour
{
    public PlayerController controller;
    public GameObject footstep;    
   // public FMODUnity.StudioEventEmitter emitter;
    public float hitDistance = 0.6f;
    
    FMOD.Studio.EventInstance footInstance;

    private void Start()
    {
        footInstance = RuntimeManager.CreateInstance("event:/footstep");
        FMOD.ATTRIBUTES_3D attributes = new FMOD.ATTRIBUTES_3D();
        attributes.position.x = transform.position.x;
        attributes.position.y = transform.position.x;
        attributes.position.z = transform.position.x;

        footInstance.set3DAttributes(attributes);
        footInstance.start();
        footInstance.setPaused(false);
    }

    // Update is called once per frame
    void Update()
    {

        FMOD.ATTRIBUTES_3D attributes = new FMOD.ATTRIBUTES_3D();
        attributes.position.x = transform.position.x;
        attributes.position.y = transform.position.y;
        attributes.position.z = transform.position.z;

        footInstance.set3DAttributes(attributes);

        //only do this if moving
        if (controller.isMoving)
        {
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 10, layerMask))
            {
                if (hit.distance < hitDistance)
                {
                    Debug.Log("hit");
                    //footstep.SetActive(true);
                 
                    footInstance.setPaused(false);
                }

            }

        }
        else
        {
            footInstance.setPaused(true);

        }
        
        //find distance between foot and ground prolly via raycast

        //get material of the ground and/or use different layers by type


    }

    IEnumerator Countdown(float time)
    {
        Debug.Log("countdown");        
        yield return new WaitForSeconds(time);
        footstep.SetActive(false);


    }
}
