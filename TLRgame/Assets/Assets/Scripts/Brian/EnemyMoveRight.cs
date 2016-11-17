using UnityEngine;
using System.Collections;

public class EnemyMoveRight : MonoBehaviour {

    Rigidbody2D rb2D;

	// Use this for initialization
	void Awake () {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        rb2D.velocity = new Vector2(10, rb2D.velocity.y);
    }
}
