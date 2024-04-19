using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class TeleportConditional : MonoBehaviour
{

    public Transform destination;
    public Transform[] conditions = new Transform[3];
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            Debug.Log("player collider " + transform.name);
            
            //get the player component
            PlayerAchievments achs = other.transform.GetComponent<PlayerAchievments>();
            //stuff this cube tranform, into the list of player achievments
            achs.achievments[achs.emptyAchieve] = transform;
            //increment the next empty achs.
            achs.emptyAchieve++;

            //send it away - send it to hell
            transform.position = new Vector3(transform.position.x, -666.0f, transform.position.z);
            transform.gameObject.SetActive(false);

        }
    }
}
