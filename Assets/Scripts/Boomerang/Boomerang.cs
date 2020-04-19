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
        Throw(600, new Vector2(0,0));
    }

    void Throw(float force, Vector2 direction)
    {
        bc.enabled = false;
        vforce.x = force;
        vforce.y = 0;
        brakingforce.x = -force/10;
        brakingforce.y = 0;
        rb.AddRelativeForce(vforce);
        StartCoroutine(brake());
        
    }

    IEnumerator brake()
    {
        yield return new WaitForSeconds(0.5f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        yield return new WaitForSeconds(0.1f);
        rb.AddRelativeForce(brakingforce);
        bc.enabled = true;
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
        yield return new WaitForSeconds(10f);
        Destroy(br);
    }
}
