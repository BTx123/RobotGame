using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private bool isAttacking = false;

    private float attackTimer = 0;       // keep track of when next attack can occur
    private float attackCooldown = 0.3f; // minimum time between attacks

    public Collider2D attackTrigger;     // 2D collision box (in front of player) for attacking
    private Animator anim;               // attack animation

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false; // turn off trigger collider
    }

    void Update()
    {
        // Attack when space is pressed
        if (Input.GetKeyDown("space") && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCooldown;
            attackTrigger.enabled = true;
        }
        // If the player is attacking, start cooldown timer and wait until attackTimer reaches 0 before next attack
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
        // Change isAttacking bool in Unity editor for animation based on isAttacking bool in this script
        anim.SetBool("isAttacking", isAttacking);
    }
}
