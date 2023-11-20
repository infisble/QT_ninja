using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        if(dirX > 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = false;

        } 
        else if(dirX < 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
