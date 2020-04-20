using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
//KubikZ: Refactorings, key handling, and little repairs
public class Switch : MonoBehaviour
{
    bool isOn;

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    private bool cooldown = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boomerang") && !cooldown)
        { SwitchSwitch(); }
    }

    private void FixedUpdate()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isMoving && cooldown)
        { cooldown = false; }
    }

    void SwitchSwitch()
    {
        cooldown = true;
        if (isOn)
            Deactivate();
        else
            Activate();
    }

    void Activate()
    {
        isOn = true;
        OnActivate.Invoke();
        //TO DO: Change sprite
    }
    void Deactivate()
    {
        isOn = false;
        OnDeactivate.Invoke();
        //TO DO: Change sprite
    }

}
