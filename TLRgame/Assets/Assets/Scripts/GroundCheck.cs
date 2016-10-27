/* GroundCheck
 * Script for setting value of isGrounded using box collider
 */

using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
	private Player player;

	void Start()
	{
		player = gameObject.GetComponentInParent<Player>();
	}
	// true when player collides with collider that is not a trigger
	void OnTriggerEnter2D(Collider2D col)
	{
        if (!col.isTrigger)
        {
            player.isGrounded = true;
        }
	}
    // true whien is contact with collider that is not a trigger
	void OnTriggerStay2D(Collider2D col)
	{
        if (!col.isTrigger)
        {
            player.isGrounded = true;
        }
	}
	// false when player stops colliding with collider that is not a trigger
	void OnTriggerExit2D(Collider2D col)
	{
        if (!col.isTrigger)
        {
            player.isGrounded = false;
        }        
	}
}
