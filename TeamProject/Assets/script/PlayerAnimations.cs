using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        if(dirX > 0f)
        {
            anim.SetBool("walking", true);
            
        } 
        else if(dirX < 0f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
