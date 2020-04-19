using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BeamTrigger : MonoBehaviour
{
    bool captureKeysForRotating = false;
    LightTower childTower;

    [Header("KeyBinds")]
    public KeyCode rotateClockwiseKeybind = KeyCode.E;
    public KeyCode rotateAnticlockwiseKeybind = KeyCode.Q;


    private void Start()
    {
        childTower = transform.GetChild(0).GetComponent<LightTower>();

        if (gameObject.tag != "BeamTrigger")
            Debug.LogError("All Beam Triggers have to have tag \"BeamTrigger\" assigned!");

        if (GetComponent<BoxCollider2D>().isTrigger == false)
            Debug.LogError("Make sure to check \"Is Trigger\" on every beam trigger!");
    }

    private void Update()
    {
        if (captureKeysForRotating)
        {
            if (Input.GetKeyDown(rotateClockwiseKeybind))
                childTower.RotateBeam90Deg(true);
            else if (Input.GetKeyDown(rotateAnticlockwiseKeybind))
                childTower.RotateBeam90Deg(false);
        }
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
            captureKeysForRotating = true;
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
            captureKeysForRotating = false;
    }

}
