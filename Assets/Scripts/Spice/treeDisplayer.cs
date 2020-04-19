using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeDisplayer : MonoBehaviour
{
    public int OrderInLayerFront = -20, OrderInLayerBack = 5;

    private SpriteRenderer sRenderer;
    private Transform player;

    private void Assign()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Awake()
    {
        Assign();
    }

    private void Update()
    {
        //print(player.position.y + " " + transform.position.y);
        if (player.position.y < transform.position.y)
        { sRenderer.sortingOrder = OrderInLayerFront; }
        else
        { sRenderer.sortingOrder = OrderInLayerBack; }
    }
}
