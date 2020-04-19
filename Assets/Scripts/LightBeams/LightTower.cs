using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(BoxCollider2D))]
public class LightTower : MonoBehaviour
{
    protected LineRenderer lineRenderer;
    public Camera playerCamera;

    public Vector2 beamOrigin = new Vector2();
    public Vector2 beamDir = new Vector2(1, 0);

    public bool lit = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (gameObject.tag != "LightTower" && !lit)
            Debug.LogError("All light towers have to have tag \"LightTower\" assigned!");
    }

    void Update()
    {
        if (lit)
            UpdateBeam();
    }

    public void UpdateBeam()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        try
        {
            RaycastHit2D hit;
            Debug.DrawRay(transform.position, beamDir);

            if (hit = Physics2D.Raycast(transform.position, beamDir, Mathf.Infinity))
            {
                if (!hit.collider.CompareTag("Player"))
                {
                    lineRenderer.SetPositions(new Vector3[] { transform.position, transform.position });

                    if (hit.collider.CompareTag("LightTower"))
                        hit.collider.GetComponent<LightTower>().Enlighten();
                    else if (hit.collider.CompareTag("LightReciever"))
                        hit.collider.GetComponent<LightReciever>().RecieveLight();
                }
                else
                {
                    hit.collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                    UpdateBeam();
                    hit.collider.gameObject.layer = LayerMask.NameToLayer("Default");
                }
            }
            else
                lineRenderer.SetPositions(new Vector3[] { transform.position, GetEdgeOfScreen(transform.position, beamDir) });
        }
        finally
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    
    public void RotateBeam90Deg(bool clockwise)
    {
        beamDir = RotateVector(beamDir, clockwise);
        transform.GetChild(0).Rotate(0, 0, 90 * (clockwise ? 1 : -1));

        UpdateBeams();
    }
    
    protected void UpdateBeams()
    {
        foreach (GameObject towerObject in GameObject.FindGameObjectsWithTag("LightTower"))
        {
            var lightTower = towerObject.GetComponent<LightTower>();

            lightTower.Delighten();
        }
    }
    public void Enlighten()
    {
        lit = true;
    }
    public void Delighten()
    {
        lit = false;
        lineRenderer.SetPositions(new Vector3[] { new Vector3(), new Vector3() });
    }

    protected Vector2 RotateVector(Vector2 vector, bool clockwise)
    {
        if (clockwise)
        {
            if (vector.y != 0)
                return new Vector2(vector.y, 0);
            else
                return new Vector2(0, -vector.x);
        }
        else
        {
            if (vector.y != 0)
                return new Vector2(-vector.y, 0);
            else
                return new Vector2(0, vector.x);
        }
    }
    protected Vector2 GetEdgeOfScreen(Vector2 origin, Vector2 dir)
    {
        if (dir.x != 0)
            return playerCamera.ScreenToWorldPoint(
                new Vector3(Screen.width * Mathf.Sign(dir.x), playerCamera.WorldToScreenPoint(origin).y));
        else
            return playerCamera.ScreenToWorldPoint(
                new Vector3(playerCamera.WorldToScreenPoint(origin).x, Screen.height * Mathf.Sign(dir.y)));
    }
}
