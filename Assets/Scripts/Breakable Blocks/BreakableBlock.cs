using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public GameObject debris;
    public GameObject block;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Boomerang")
        {
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.identity, transform);
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.identity, transform);
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.identity, transform);
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.identity, transform);
            Destroy(block);
        }
    }

}
