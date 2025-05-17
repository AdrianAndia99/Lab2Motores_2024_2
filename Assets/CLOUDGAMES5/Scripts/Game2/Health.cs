using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int lifeRecover = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ModifyLife(lifeRecover);
            Destroy(gameObject);
        }
    }
}