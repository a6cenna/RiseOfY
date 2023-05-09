using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public int damage = 15;
    public float speed = 20f;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy!=null)
        {
            enemy.TakeDamage(damage);
        }
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        BossHealth boss = hitInfo.GetComponent<BossHealth>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
