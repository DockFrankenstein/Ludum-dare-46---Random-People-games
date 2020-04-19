using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlideAnimation : MonoBehaviour
{
    public Vector2 position = new Vector2(0.5f, 0.5f);

    private RectTransform trans;

    private void Awake()
    {
        Assign();
        Update();
    }

    private void Assign()
    {
        trans = GetComponent<RectTransform>();
    }

    private void Update()
    {
        FitToScreen();
        NewPosition();
    }

    private void NewPosition()
    {
        Vector2 nPosition = new Vector2(Screen.width, Screen.height) * position;

        trans.position = nPosition;
    }

    private void FitToScreen()
    {
        trans.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
