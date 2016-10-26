using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    int currHealth = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
    // Called when player hits enemy, subtracts health from enemy and plays damaged animation
    void Damage(int damage)
    {
        currHealth -= damage;
        // TODO: red flash animation
        gameObject.GetComponent<Animation>().Play("DamageRedFlash");
    }
}
