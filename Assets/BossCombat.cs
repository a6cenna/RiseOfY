using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public int damages = 40;
    public float attackRange = 1f;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint1;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPrefab2;
    [SerializeField] private Boss boss;

    public LayerMask attackMask;

    public void Attack()
    {
        Collider2D[] colInfo = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackMask);

        foreach(Collider2D player in colInfo)
        {
            if (colInfo != null)
            {
                player.GetComponent<playerHealth>().TakeDamage(damages);
            }
        }
        
    }

    void Shoot()
    {
        boss.LookAtPlayer();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Shoot");
    }
    void LShoot()
    {
        boss.LookAtPlayer();
        Instantiate(bulletPrefab2, firePoint1.position, firePoint.rotation);
        Debug.Log("Shoot");
    }
    void SpikeSa()
    {
        boss.LookAtPlayer();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spike");
        foreach(GameObject spike in gameObjects)
        {
            spike.GetComponent<Spike>().SpikeS();
        }
    }

    void SpikeFa()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject spike in gameObjects)
        {
            spike.GetComponent<Spike>().SpikeF();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
