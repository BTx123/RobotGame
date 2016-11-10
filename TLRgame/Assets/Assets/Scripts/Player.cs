/* Player
 * Script for Player movement and actions
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool facingRight = true;
	public float speed = 50f;
    public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 150f;
    public float friction = 0.8f;
	public bool isGrounded;
	public bool isDoubleOK;
	public bool isDead = false;
    public Stat health;
    public Stat exp;

    private Rigidbody2D rb2D;
	private Animator anim;

    public void Awake()
    {
        health.Initialize();
        exp.Initialize();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update ()
	{
		anim.SetBool("isGrounded", isGrounded);
		anim.SetBool("isDead", isDead);

        // Reduce health test
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10;
        }
        // Limit health to max possible health
        if (health.currentVal > health.maxVal)
        {
			health.currentVal = health.maxVal;
		}
        // Player dies if health is 0 or less
        else if (health.currentVal <= 0)
        {
			Die ();
		}
        // EXP
        if (exp.currentVal >= exp.maxVal)
        {
            Upgrade();
        }
	}

	// FixedUpdated called for physics stuff
	void FixedUpdate ()
	{
		// Horizontal movement
		float x = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(x));

        rb2D.AddForce(Vector2.right * x * moveForce);

        // Fake friction to ease velocity
        Vector2 easeVelocity = rb2D.velocity;
        if (x < 1f && x > -1f)
        {
            easeVelocity.x *= friction; // decrease magnitude of x
        }
        easeVelocity.y = rb2D.velocity.y; // friction does not affect jump
        if (isGrounded)
            rb2D.velocity = easeVelocity;
        
        // Limit speed
        if (rb2D.velocity.x > maxSpeed)
            rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity.y);
        if (rb2D.velocity.x < -maxSpeed)
            rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.y);

        // Flip direction of player
        if (x < 0 && facingRight)
            Flip();
        if (x > 0 && !facingRight)
            Flip();

        // Jumping and double jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb2D.AddForce(Vector2.up * jumpForce);
                isDoubleOK = true;
            }
            else
            {
                if (isDoubleOK)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                    rb2D.AddForce(Vector2.up * jumpForce);
                    isDoubleOK = false;
                }
            }
        }
    }

    // Changes direction player is facing
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Damage(int dmg)
    {
        health.CurrentVal -= dmg;
    }

    void Upgrade()
    {
        return;
    }

    // Player respawns, level restarts
	void Die ()
	{
		isDead = true;
		//yield return new WaitForSeconds (2);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
