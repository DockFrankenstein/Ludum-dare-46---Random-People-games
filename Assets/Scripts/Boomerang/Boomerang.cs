using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public GameObject br;
    private PlayerMovement player;

    public float RotationSpeed = 1f;
    public Transform spriteTransform;

    Vector2 vforce;
    Vector2 brakingforce;

    private void Start()
    {
        Throw(600);
    }

    private void Awake()
    {
        Assign();
    }

    private void Assign()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Throw(float force)
    {
        bc.enabled = false;
        vforce.x = -force;
        vforce.y = 0;
        brakingforce.x = +force/10;
        brakingforce.y = 0;
        rb.AddRelativeForce(vforce);
        StartCoroutine(brake());
    }

    private void Update()
    {
        spriteTransform.eulerAngles += new Vector3(0f, 0f,Time.deltaTime * RotationSpeed);
    }

    private IEnumerator brake()
    {
        yield return new WaitForSeconds(0.1f);
        bc.enabled = true;
        yield return new WaitForSeconds(0.4f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce * 2);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce * 2);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce * 2);
        yield return new WaitForSeconds(5f);

        player.isMoving = false;
        Destroy(br);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.isMoving = false;
            bool isActivated = player.pointerAxis.GetComponentInChildren<PlayerBoomerang>().activated;
            if (!isActivated) { player.anim.SetTrigger("Exit"); }

            player.pointerAxis.GetComponentInChildren<PlayerBoomerang>().activated = true;
            player.recieveDamage();
            Destroy(br);
        }
    }
}
