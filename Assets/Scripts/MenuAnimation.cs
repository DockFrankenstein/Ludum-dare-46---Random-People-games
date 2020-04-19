using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public GameObject[] treePrefab;
    public float minSpeed = 1f;
    public float maxSpeed = 2f;

    [Space]

    public float minWaitTime = 0f;
    public float maxWaitTime = 0.5f;

    private void Awake()
    {
        StartCoroutine(theAnimation());
    }

    private IEnumerator theAnimation()
    {
        while (true)
        {
            StartCoroutine(oneAnimation());
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    private IEnumerator oneAnimation()
    {
        GameObject newPrefab = treePrefab[Random.Range(0, treePrefab.Length)];

        GameObject GO = Instantiate(newPrefab, transform);

        float speed = Random.Range(minSpeed, maxSpeed);
        GO.GetComponent<Animator>().speed = speed;
        yield return new WaitForSeconds(maxSpeed * 2);
        Destroy(GO);
    }
}
