using UnityEngine;
using UnityEngine.Events;
public class ActiveMusic : MonoBehaviour
{
    public UnityEvent OnStart;
    void Start()
    {
        OnStart?.Invoke();
    }
}
