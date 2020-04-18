using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer), typeof(BoxCollider2D))]
public class LightBeam : Beamable
{
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit2D hit;
        Debug.DrawRay(transform.position, beamDir);

        if (hit = Physics2D.Raycast(transform.position, beamDir, Mathf.Infinity, LayerMask.GetMask("Towers")))
        {
            if (hit.collider.CompareTag("LightTower"))
            {
                lineRenderer.SetPositions(new Vector3[] { transform.position, hit.point });
            }
            else if (hit.collider.CompareTag("LightReciever"))
            {
                lineRenderer.SetPositions(new Vector3[] { transform.position, hit.point });
                hit.collider.GetComponent<LightReciever>().RecieveLight();
            }
        }
        else
        {
            lineRenderer.SetPositions(new Vector3[] { transform.position, GetEdgeOfScreen(transform.position, beamDir, camera) });

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateBeam90Deg(true);
        }

    }

    private void OnMouseDown()
    {
        RotateBeam90Deg(true);
    }



}
