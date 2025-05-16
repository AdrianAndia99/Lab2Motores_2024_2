using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerforatorBullet : MonoBehaviour
{
    private Rigidbody2D _compRigidBody2D;
    [SerializeField] private int speed;
    public int damage;
    private void Awake()
    {
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        AudioManagerController.Instance.PlaySfx(6);
    }
    private void FixedUpdate()
    {
        _compRigidBody2D.linearVelocity = new Vector2(speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
    }
}
