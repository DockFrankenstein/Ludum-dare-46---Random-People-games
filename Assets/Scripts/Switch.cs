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

    public Sprite activated;
    public Sprite deactivated;
    public SpriteRenderer targetGraphic;

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
        targetGraphic.sprite = activated;
    }
    void Deactivate()
    {
        isOn = false;
        OnDeactivate.Invoke();
        targetGraphic.sprite = deactivated;
    }

}
