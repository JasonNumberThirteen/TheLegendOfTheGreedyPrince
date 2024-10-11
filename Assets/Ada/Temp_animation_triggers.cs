using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_animation_triggers : MonoBehaviour
{
    public bool isJump;
    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) animator.SetBool("jump", true);
        else animator.SetBool("jump", false);
    }
}
