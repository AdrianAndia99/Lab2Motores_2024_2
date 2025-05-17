using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 AngleRotations;

    void Update()
    {
        QuaternionRotation();
    }
    private void QuaternionRotation()
    {
        transform.Rotate(AngleRotations * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GainCoin();
            Destroy(gameObject);
        }
    }
}