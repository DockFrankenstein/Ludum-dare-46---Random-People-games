using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//Stellan: Whoever made this, I edited it abit please dont get angry 
public class PlayerMovement : MonoBehaviour
{
    [Header("Moovement")]
    public float speed = 0.1f;
    public Transform pointerAxis;

    [Header("Damage")]
    public SpriteRenderer healthBar;
    public SpriteRenderer healthNumber;
    public GameObject damageIndicator;
    public int health = 0;
    public Sprite[] healthBars;
    public Sprite[] healthNumbers;

    private Rigidbody2D rb;

    [HideInInspector]
    public Animator anim;

    private Vector2 target;
    public bool isMoving = false;

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
        ResetHealth();
        Assign();
    }

    private void ResetHealth()
    {
        health = healthBars.Length - 1;
        healthNumber.sprite = healthNumbers[health];
    }

    void Update()
    {
        Move();
        RotatePointer();
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
            isMoving = true;
            anim.SetTrigger("Throw");
        }
    }

    public void RotatePointer()
    {
        Camera cam = Camera.main;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 finalDirection = mousePos - (Vector2)pointerAxis.position;

        float x = pointerAxis.eulerAngles.x;
        float y = pointerAxis.eulerAngles.y;
        float z = -(Mathf.Atan2(finalDirection.x, finalDirection.y) * Mathf.Rad2Deg);

        anim.SetFloat("Point rotation", z);

        pointerAxis.eulerAngles = new Vector3(x, y, z);
    }

    public void recieveDamage()
    {
        health--;

        if (health <= 0)
        {
            LevelManager.current.ReloadScene();
        }

        healthBar.sprite = healthBars[healthBars.Length - health - 1];
        healthNumber.sprite = healthNumbers[health];
        damageIndicator.GetComponent<Animator>().SetTrigger("Show damage");
    }

    private void Move()
    {

        GetInput();
        Animate();

        if (rb != null && isMoving == false)
        { rb.velocity = input * speed; }
        else 
        { rb.velocity = new Vector2(0f, 0f); }
    }
}
