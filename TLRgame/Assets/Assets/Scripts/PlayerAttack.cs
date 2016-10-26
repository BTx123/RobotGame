using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private bool isAttacking = false;

    private float attackTimer = 0;
    private float attackCooldown = 0.3f;

    public Collider2D attackTrigger;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !isAttacking)
        {
            print("Attack");
            isAttacking = true;
            attackTimer = attackCooldown;
            attackTrigger.enabled = true;
        }

        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
