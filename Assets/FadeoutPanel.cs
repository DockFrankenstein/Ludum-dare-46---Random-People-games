using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeoutPanel : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.parent.gameObject);   
    }
}
