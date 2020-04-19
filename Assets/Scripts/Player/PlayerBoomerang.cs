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
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

                float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                Instantiate(boomerang, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(new Vector3(0f, 0f, angle)));
                activated = false;
                StartCoroutine(cooldown());
            }
        }
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(0.0f);
        activated = true;
    }
}
