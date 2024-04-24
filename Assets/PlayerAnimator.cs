using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Walk()
    {
        ResetAnimParams();

        anim.SetBool("Walk", true);        
        return true;

    }

    public bool Idle()
    {
        ResetAnimParams();

        anim.SetBool("Idle", true);        
        return true;

    }

    public bool Sneak()
    {
        ResetAnimParams();

        anim.SetBool("Sneak", true);        
        return true;

    }

    public bool Run()
    {
        ResetAnimParams();

        anim.SetBool("Run", true);
        return true;

    }

    public void ResetAnimParams()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Sneak", false);
        anim.SetBool("Run", false);

    }
    public void TriggerSound()
    {
        Debug.Log("trigger sound");

    }
}
