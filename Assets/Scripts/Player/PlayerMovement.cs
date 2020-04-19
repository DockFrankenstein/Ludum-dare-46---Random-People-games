using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;

    public Rigidbody2D rb;
    
    Vector2 input;

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BeamTrigger"))
            collision.GetComponent<BeamTrigger>().OnPlayerEnter();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BeamTrigger"))
            collision.GetComponent<BeamTrigger>().OnPlayerExit();
    }
}
