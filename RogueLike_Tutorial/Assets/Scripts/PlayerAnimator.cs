using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    PlayerMovement pm;
    SpriteRenderer sr;
    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.moveDir.x !=0 || pm.moveDir.y !=0){
            anim.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else{
            anim.SetBool("Move",false); 
        }
    }
    void SpriteDirectionChecker(){
        if(pm.moveDir.x< 0){
            sr.flipX = true;
        }
        else{
            sr.flipX=false;
        }

    }
}
