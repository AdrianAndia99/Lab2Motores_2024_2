using UnityEngine;
public class DestroyAfterAnimation : MonoBehaviour
{
    // Referencia a la animaci�n
    public Animator animator;

    // M�todo que se llama al inicio del juego
    void Start()
    {
        // Obtiene la duraci�n de la animaci�n
        float duration = animator.GetCurrentAnimatorStateInfo(0).length;

        // Destruye el objeto despu�s de que la animaci�n termine
        Destroy(gameObject, duration);
    }
}
