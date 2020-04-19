using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//Stellan: Whoever made this, I edited it abit please dont get angry 
public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isMoving = false;
    private Vector2 target;

    private void Assign()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private Vector2 input;
    private Vector2 mousePos;
    private Vector2 direction;

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
        if (isMoving)
        {
            anim.SetFloat("X", rb.velocity.x);
            anim.SetFloat("Y", rb.velocity.y);
        }
    }

    private void GetInput()
    {
        //keyboard input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        //Mouse Input
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            target = mousePos;
            direction = (target - rb.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
            isMoving = true;
        }
        if (Vector2.Distance(target,rb.position) < 0.1f)
        {
            isMoving = false;
        }
    }

    private void Move()
    {

        GetInput();
        Animate();

        if (rb != null && isMoving == false)
        { rb.velocity = input * speed; }
    }
}
