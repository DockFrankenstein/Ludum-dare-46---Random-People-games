using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;

    private Rigidbody2D rb;
    private Animator anim;

    private void Assign()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private Vector2 input;

    private void Awake()
    {
        Assign();
    }

    void Update()
    {
        Move();
    }

    private void Animate()
    {
        if (anim != null)
        {
            anim.SetFloat("X", input.x);
            anim.SetFloat("Y", input.y);
        }
    }

    private void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        GetInput();
        Animate();

        if (rb != null)
        { rb.velocity = input * speed; }
    }
}
