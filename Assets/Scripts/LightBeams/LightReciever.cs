using UnityEngine;
using UnityEngine.Events;

public class LightReciever : MonoBehaviour
{
    public UnityEvent OnLightRecieve;

    void Start()
    {
        if (gameObject.tag != "LightReciever")
            Debug.LogError("All light recievers have to have tag \"LightReciever\" assigned!");
    }

    public void RecieveLight()
    {
        OnLightRecieve.Invoke();
    }
    
}
