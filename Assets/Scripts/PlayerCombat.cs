using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public int maxHealth = 100;
    int currentHealth;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth < -0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);

        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }

    void Attack()
    {
        anim.SetTrigger("isAttacking");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);   
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
