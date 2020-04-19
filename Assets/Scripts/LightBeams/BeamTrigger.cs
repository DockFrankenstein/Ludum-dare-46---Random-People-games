using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BeamTrigger : MonoBehaviour
{
    bool captureKeysForRotating = false;
    LightTower childTower;

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
            //maybe some keybinds in settings in the future
            if (Input.GetKeyDown(KeyCode.E))
                childTower.RotateBeam90Deg(true);
            else if (Input.GetKeyDown(KeyCode.Q))
                childTower.RotateBeam90Deg(false);
        }
    }


    public void OnPlayerEnter()
    {
        captureKeysForRotating = true;
    }
    public void OnPlayerExit()
    {
        captureKeysForRotating = false;

    }

}
