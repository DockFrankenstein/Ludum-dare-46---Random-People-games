using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoomerang : MonoBehaviour
{
    public GameObject boomerang;
    public bool activated = true;

    private PlayerMovement player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (activated)
            {
                player.RotatePointer();

                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

                float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                Instantiate(boomerang, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(new Vector3(0f, 0f, angle)));
                activated = false;
                //StartCoroutine(cooldown());
            }
        }
        
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    /*private IEnumerator cooldown()
    {
        yield return new WaitForSeconds(3.0f);

        if (!activated) 
        { 
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().anim.SetTrigger("Exit");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isMoving = false;
        }
        activated = true;
    }*/
}
