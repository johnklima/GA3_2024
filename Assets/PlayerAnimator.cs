using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    AnimatorController animController;

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

        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);

        
        return true;

    }

    public bool Idle()
    {
        anim.SetBool("Sneaking", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
        
        return true;

    }

    public bool Sneak()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);

        anim.SetBool("Sneak", true);
        return true;

    }


}
