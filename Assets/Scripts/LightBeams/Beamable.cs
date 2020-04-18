using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Beamable : MonoBehaviour
{
    protected LineRenderer lineRenderer;
    public Camera camera;
    public Vector2 beamDir = new Vector2(1, 0);



    protected void RotateBeam90Deg(bool clockwise)
    {
        beamDir = RotateVector(beamDir, clockwise);
        transform.GetChild(0).Rotate(0, 0, 90 * (clockwise ? 1 : -1));
    }


    protected Vector2 GetEdgeOfScreen(Vector2 origin, Vector2 dir, Camera camera)
    {
        if (dir.x != 0)
            return camera.ScreenToWorldPoint(
                new Vector3(Screen.width * Mathf.Sign(dir.x), camera.WorldToScreenPoint(origin).y));
        else
            return camera.ScreenToWorldPoint(
                new Vector3(camera.WorldToScreenPoint(origin).x, Screen.height * Mathf.Sign(dir.y)));

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

}
