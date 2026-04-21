using UnityEngine;
using UnityEngine.Events;

public class TargetInteract : MonoBehaviour
{
    public UnityEvent onVuruldu;
    public GameObject patlamaEfekti; 

    public void Activate()
    {
        
        if (patlamaEfekti != null)
        {
            Instantiate(patlamaEfekti, transform.position, transform.rotation);
        }

        onVuruldu.Invoke();
    }
}