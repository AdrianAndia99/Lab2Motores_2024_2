using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private int damage;
    private void Start()
    {
        player = PlayerController.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioManagerController.Instance.PlaySfx(5);
            player.Life = player.Life - damage;
            Destroy(this.gameObject);
        }
        else if (collision.tag == "EnemyEliminator")
        {
            Destroy(this.gameObject);
        }
    }
}
