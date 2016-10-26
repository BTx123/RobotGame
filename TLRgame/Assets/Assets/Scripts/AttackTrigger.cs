using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int damage = 20;

    // On attack trigger collision with enemy collision box, 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", damage);
        }
    }
}
