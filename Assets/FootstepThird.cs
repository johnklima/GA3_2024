using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepThird : MonoBehaviour
{
    public PlayerController controller;                 //set this in editor!!!
    public GameObject[] footsteps = new GameObject[4]; //set this in editor!!!
    public float hitDistance = 0.03f;
    public GameObject theFootstep;                      //set this in editor!!!

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //only do this if moving
        if (controller.isMovingLateral)
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
                //Debug.Log("d = " + hit.distance);

                if (hit.distance < hitDistance)
                {

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

                    //Debug.Log(hit.transform.tag);

                }
                else if(hit.distance > 0.2f)
                {
                    ChangeSound(-1);  //stop sound
                }
                    

            }
            else
            {
                ChangeSound(-1);  //stop sound
            }

        }
        else
        {
            ChangeSound(-1);  //stop sound

        }




    }
    void ChangeSound(int index)
    {

        if(index == -1) 
        {
            theFootstep.SetActive(false);
            return;
        }


        //if the current sound is not the next sound
        if (theFootstep != footsteps[index])
        {
            theFootstep.SetActive(false); //deactivate previous
            
        }
        //set the new active
        footsteps[index].SetActive(true);
        //assign the new
        theFootstep = footsteps[index];
        

    }
    IEnumerator Countdown(float time)
    {
        Debug.Log("countdown");
        yield return new WaitForSeconds(time);

    }
}
