using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    public GameObject boomerang;
    public bool activated = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (activated)
            {
                Vector3 targetDirection = new Vector3(Input.mousePosition.x, Input.mousePosition.x, 0);
                Instantiate(boomerang, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                activated = false;
                StartCoroutine(cooldown());
            }
        }
        
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(0.0f);
        activated = true;
    }
}
