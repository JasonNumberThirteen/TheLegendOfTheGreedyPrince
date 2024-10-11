using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    public bool isJump;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //animation
        if (Input.GetKey(KeyCode.Space)) animator.SetBool("jump", true);
        else animator.SetBool("jump", false);

        if (rb.velocity.x > 0) animator.SetBool("run", true);
        else animator.SetBool ("run", false);

        //movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveHorizontal * speed, 0);
    }
}
