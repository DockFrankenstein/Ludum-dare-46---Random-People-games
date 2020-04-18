using UnityEngine;
using UnityEngine.Events;

public class LightReciever : MonoBehaviour
{
    public UnityEvent OnLightRecieve;


    public void RecieveLight()
    {
        OnLightRecieve.Invoke();
    }
    
}
