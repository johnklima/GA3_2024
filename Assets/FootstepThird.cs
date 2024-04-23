using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepThird : MonoBehaviour
{
    public PlayerController controller;                 //set this in editor!!!
    public GameObject[] footsteps = new GameObject[4];  //set this in editor!!!
    public float hitDistance = 0.18f;
    public float hitDistanceOff = 0.2f;
    public GameObject theFootstep;                      //set this in editor!!!

    private FMOD.Studio.EventInstance footSoundInstance;

    private bool isPlaying = false;

    private void Start()
    {
        footSoundInstance = FMODUnity.RuntimeManager.CreateInstance("event:/grass");
    }

    // Update is called once per frame
    void Update()
    {

        //only do this if moving
        if (controller.isMovingLateral)
        {

            footSoundInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Camera.main.gameObject));



            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            //layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 10, layerMask))
            {

                Debug.Log(hit.distance + transform.name);

                if (hit.distance < hitDistance )
                {
                   
                    FMOD.Studio.PLAYBACK_STATE state;
                    footSoundInstance.getPlaybackState(out state);
                    if (state != FMOD.Studio.PLAYBACK_STATE.PLAYING)
                    {
                       // footSoundInstance = FMODUnity.RuntimeManager.CreateInstance("event:/grass");
                        footSoundInstance.start();
                    }
                    /*
                    if (hit.transform.tag == "grass")         //grass
                    {
                        ChangeSound(0);
                    }
                    else if (hit.transform.tag == "dirt")    //dirt 
                    {
                        ChangeSound(1);
                    }
                    else if (hit.transform.tag == "rock")    //rock
                    {
                        ChangeSound(2);
                    }
                    else if (hit.transform.tag == "water")   //water
                    {
                        ChangeSound(3);
                    }

                    Debug.Log(hit.transform.tag);
                    */
                }
                
            }
            else
            {
                //ChangeSound(-1);
                FMOD.Studio.PLAYBACK_STATE state;
                footSoundInstance.getPlaybackState(out state);
                if(state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
                {
                    footSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    footSoundInstance.release();
                   

                }

            }

        }
        else
        {
            FMOD.Studio.PLAYBACK_STATE state;
            footSoundInstance.getPlaybackState(out state);
            if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                footSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                footSoundInstance.release();
                isPlaying = false;

            }
        }




    }
    void ChangeSound(int index)
    {
        //neg one means no sound
        if (index == -1)
        {
            theFootstep.SetActive(false); //set curent to off
            return;                       //exit
        }

        //if the current is not the new sound
        if (theFootstep != footsteps[index])
        {
            //turn off the old sound
            theFootstep.SetActive(false);
        }
        //turn on this sound
        footsteps[index].SetActive(true);
        //set current sound to this sound
        theFootstep = footsteps[index];

    }
    IEnumerator Countdown(float time)
    {
        Debug.Log("countdown");
        yield return new WaitForSeconds(time);

    }
}
