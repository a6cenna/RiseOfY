using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Slider healthBar;

    public int maxHealth = 700;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.value = currentHealth;    
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth < 0)
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
}
