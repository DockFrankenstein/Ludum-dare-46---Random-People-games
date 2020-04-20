using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public GameObject br;

    Vector2 vforce;
    Vector2 brakingforce;

    void Start()
    {
        Throw(600);
    }

    void Throw(float force)
    {
        bc.enabled = false;
        vforce.x = -force;
        vforce.y = 0;
        brakingforce.x = +force/10;
        brakingforce.y = 0;
        rb.AddRelativeForce(vforce);
        StartCoroutine(brake());
        
    }

    IEnumerator brake()
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
        Destroy(br);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Destroy(br);
        }
    }
}
