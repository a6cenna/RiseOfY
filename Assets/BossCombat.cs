using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public int damages = 40;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public Vector3 attackOffset;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D[] colInfo = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);

        foreach(Collider2D player in colInfo)
        {
            if (colInfo != null)
            {
                player.GetComponent<playerHealth>().TakeDamage(damages);
            }
        }
        
    }

}
