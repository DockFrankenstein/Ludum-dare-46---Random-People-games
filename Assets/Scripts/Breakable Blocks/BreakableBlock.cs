using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public GameObject debris;
    public GameObject block;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boomerang")
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(debris, new Vector2(transform.position.x + Random.Range(-0.7f, 0.7f), transform.position.y + Random.Range(-0.7f, 0.7f)), Quaternion.identity);
            }
            Destroy(block);
        }
    }

}
