using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBullet : MonoBehaviour
{
    private Rigidbody2D _compRigidBody2D;
    [SerializeField] private int speed;
    public int damage;
    public float angle; // �ngulo para las balas laterales
    public GameObject bulletPrefab; // Prefab de la bala

    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AudioManagerController.Instance.PlaySfx(8);
        // Bala central
        _compRigidBody2D.linearVelocity = new Vector2(speed, 0);

        // Balas laterales
        float radianAngle = angle * Mathf.Deg2Rad;
        GameObject bullet1 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -angle));
        bullet1.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed * Mathf.Cos(radianAngle), speed * Mathf.Sin(radianAngle));
        bullet2.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed * Mathf.Cos(radianAngle), -speed * Mathf.Sin(radianAngle));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
    }
}
