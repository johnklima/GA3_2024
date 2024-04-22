using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class TeleportConditional : MonoBehaviour
{

    public Transform destination;
    public Transform[] conditions = new Transform[3];
    public int condCount = 0;
    public bool teleport = false;
    Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("player collider " + transform.name);
            player = other.transform;

            //get the player component
            PlayerAchievments achs = player.GetComponent<PlayerAchievments>();
            //stuff this cube tranform, into the list of player achievments
            achs.achievments[achs.emptyAchieve] = transform;
            //increment the next empty achs.
            achs.emptyAchieve++;

            bool sendItAway = false;   //are we ready to hide the trigger?

            //are all conditions met?
            condCount = 0;
            //look at each of my conditions
            for (int i = 0; i < conditions.Length; i++)
            {
                for (int j = 0; j < achs.achievments.Length; j++)
                {
                    if (conditions[i] == achs.achievments[j])
                    {
                        condCount++;
                    }

                }
            }
            //does it have all conditions met?
            if (condCount >= conditions.Length && conditions.Length > 0)
            {

                Debug.Log("conditions met");
                sendItAway = true;   //now okay to hide it

                //got them all
                //now, determine, does it have a destination ?
                if (destination)
                {
                    Debug.Log("have destination");
                    //gameplay issue, depending upon what is controlling my player
                    //move her there, but do I have to tweek it? with this player
                    //controller, I need to teleport the body. I don't rember this 
                    //as a requirement in the past... hmmm, right camera drives player
                    //so I have to handle the teleport AFTER the camera does its usual thing
                    teleport = true;

                }

            }
            
            if (conditions.Length == 0) 
            {
                sendItAway = true;   //this one deos not have any conditions, so just send it
            }


            if (sendItAway)            
            {
                //send it away - send it to hell, IF all conditions met. (it might have none)
                transform.position = new Vector3(transform.position.x, -666.0f, transform.position.z);
                //transform.gameObject.SetActive(false);  //to be or not to be?? best keep it active
                                                          //for at least one frame, to get that late update
            }

        }
    }

    private void LateUpdate()
    {
        //needs to be in late update so the "normal" camera stuff happens, and then it is
        //set up for the next frame.
        if (teleport)
        {
            Debug.Log("lets teleport!!");
            player.GetComponent<PlayerController>().Teleport(destination);
            teleport = false;

        }
    }
}
