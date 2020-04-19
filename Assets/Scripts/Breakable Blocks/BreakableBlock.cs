using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public GameObject boomerang;
    public GameObject debris;
    public GameObject block;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Boomerang")
        {
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), transform.position));
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), transform.position));
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), transform.position));
            Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), transform.position));
            Destroy(block);
            Destroy(boomerang);
        }
    }

}
