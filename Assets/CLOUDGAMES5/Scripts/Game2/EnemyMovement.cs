using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] pivotPoints;
    private Rigidbody rb;
    private int currentPivotIndex = 0;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (pivotPoints.Length > 0)
        {
            UpdatePivot();
        }
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (pivotPoints.Length == 0) 
        {
            return;
        }

        Vector3 direction = (pivotPoints[currentPivotIndex].position - transform.position).normalized;

        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pivotPoints[currentPivotIndex].position) < 0.1f)
        {
            UpdatePivot();
        }
    }

    private void UpdatePivot()
    {
        currentPivotIndex = (currentPivotIndex + 1) % pivotPoints.Length;
    }
}