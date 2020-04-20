using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public Sprite[] openAnimation;
    public float animationSpeed = 0.1f;
    public GameObject BlockCollision;

    public void Open()
    {
        Sprite[] animation = openAnimation;
        BlockCollision.SetActive(false);
        StartCoroutine(animate(animation));
    }

    public void Close()
    {
        Sprite[] animation = new Sprite[openAnimation.Length];
        BlockCollision.SetActive(true);

        for (int i = 0; i < animation.Length; i++)
        {
            animation[i] = openAnimation[animation.Length - 1 - i];
        }

        StartCoroutine(animate(animation));
    }

    private IEnumerator animate(Sprite[] animation)
    {
        for (int i = 1; i < openAnimation.Length; i++)
        {
            GetComponent<SpriteRenderer>().sprite = animation[i];
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
