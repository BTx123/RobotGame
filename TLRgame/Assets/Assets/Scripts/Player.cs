/* Player
 * Script for Player movement and actions
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
	// Stats
	public int currHealth;
	public int maxHealth = 100;
    public int lastFacing = 1;

	// Floats
	public float speed = 50f;
	public float maxSpeed = 5f;
	public float jumpPower = 150f;
	public float friction = 0.75f;

	// Booleans
	public bool isGrounded;
	public bool isDoubleOK;
	public bool isDead = false;

	// References
	private Rigidbody2D rb2D;
	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		currHealth = maxHealth;
	}

	// Update is called once per frame
	void Update ()
	{
		anim.SetBool("isGrounded", isGrounded);             // associating Grounded from Unity to isGrounded in script
		anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x)); // only a positive value
		anim.SetBool("isDead", isDead);                     // dead when currHealth <= 0
        // Player faces last facing direction when idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            transform.localScale = new Vector3(lastFacing, 1, 1);
        }
		// Walking to the left
		if (Input.GetAxis("Horizontal") < 0)
        {
			transform.localScale = new Vector3 (-1, 1, 1);
            lastFacing = -1;
		}
		// Walking to the right
		if (Input.GetAxis("Horizontal") > 0)
        {
			transform.localScale = new Vector3 (1, 1, 1);
            lastFacing = 1;
		}
        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb2D.AddForce(Vector2.up * jumpPower);
                isDoubleOK = true;
            }
            else
            {
                if (isDoubleOK)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                    rb2D.AddForce(Vector2.up * jumpPower);
                    isDoubleOK = false;
                }
            }
        }
        // Limit health to max possible health
		if (currHealth > maxHealth)
        {
			currHealth = maxHealth;
		}
        // Player dies if health is 0 or less
        else if (currHealth <= 0)
        {
			Die ();
		}
	}

	// FixedUpdated called for physics stuff
	void FixedUpdate ()
	{
		// Fake friction to ease velocity
		Vector3 easeVelocity = rb2D.velocity;
		if (Input.GetAxis("Horizontal") < 1f && Input.GetAxis("Horizontal") > -1f) { // prevent friction from activating when moving
			easeVelocity.x *= friction; // decrease magnitude of x
		}
		easeVelocity.y = rb2D.velocity.y; // friction does not affect jump
		easeVelocity.z = 0.0f; // no z-axis change
		if (isGrounded) {
			rb2D.velocity = easeVelocity;
		}
		// horizontal movement
		float x = Input.GetAxis("Horizontal"); // -1 or +1 for left and right
		rb2D.AddForce (Vector2.right * speed * x); // multiply 2D vector by magnitude (speed) and direction (x)
		// limiting horizontal movement
		if (rb2D.velocity.x > maxSpeed)
        {
			rb2D.velocity = new Vector2 (maxSpeed, rb2D.velocity.y);
		}
		if (rb2D.velocity.x < -maxSpeed)
        {
			rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.y);
		}
	}
    // Player respawns, level restarts
	void Die ()
	{
		isDead = true;
		//yield return new WaitForSeconds (2);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
