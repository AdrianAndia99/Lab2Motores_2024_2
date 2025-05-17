using UnityEngine;
public class DestroyAfterAnimation : MonoBehaviour
{
    // Referencia a la animación
    public Animator animator;

    // Método que se llama al inicio del juego
    void Start()
    {
        // Obtiene la duración de la animación
        float duration = animator.GetCurrentAnimatorStateInfo(0).length;

        // Destruye el objeto después de que la animación termine
        Destroy(gameObject, duration);
    }
}
