using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_movement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    Rigidbody2D rb;

    public bool isJump;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("run", true);
    }

    // Update is called once per frame
    void Update()
    {
        //animation
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            animator.SetBool("jump", true);
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
        else animator.SetBool("jump", false);

        

        //movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        //rb.velocity = new Vector2(moveHorizontal * speed, transform.position.y);
    }
}
